using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.SuaChua
{
    public class ThemController : Controller
    {
        [Auther(RightID = "83")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/them")]
        public ActionResult Index(string selected)
        {
            try
            {
                ViewBag.selected = selected;

                JObject convertedJson = JObject.Parse(selected);

                List<_Equipment> listEquip = new List<_Equipment>();

                foreach (var item in convertedJson)
                {
                    if (item.Value.HasValues)
                        foreach (var i in (JObject)item.Value)
                        {
                            listEquip.Add(new _Equipment
                            {
                                attachTo = item.Key,
                                equipmentId = i.Key,
                                quantity = int.Parse(i.Value.ToString())
                            });
                        }
                    else
                        listEquip.Add(new _Equipment
                        {
                            attachTo = null,
                            equipmentId = item.Key,
                            quantity = 1
                        });
                }

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    List<string> listId = listEquip.Select(x => x.equipmentId).Distinct().ToList();

                    var dict = db
                        .Equipments
                        .Where(x => listId.Contains(x.equipmentId))
                        .Select(x => new { x.equipmentId, x.equipment_name })
                        .AsEnumerable()
                        .ToDictionary(d => d.equipmentId, d => d.equipment_name);

                    listEquip.ForEach(x => x.equipment_name = dict[x.equipmentId]);

                    JArray output = new JArray();
                    foreach (var item in listEquip)
                    {
                        output.Add(new JObject {
                            { "equipmentId", item.equipmentId },
                            { "attachTo", item.attachTo },
                            { "quantity", item.quantity },
                        });
                    }

                    ViewBag.DataThietBi = listEquip;
                    ViewBag.output = output;

                    List<Department> departments = db.Departments.ToList();

                    ViewBag.Departments = departments;
                }
                return View("/Views/CDVT/Quyetdinh/SuaChua/Them.cshtml");
            }
            catch (Exception ex)
            {
                new MyError().AddError(ex, selected);
                return Redirect("/phong-cdvt/quyet-dinh/sua-chua/chon-thiet-bi");
            }
        }

        public class _Equipment
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public string attachTo { get; set; }
            public int quantity { get; set; }
        }

        [Auther(RightID = "83")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/them")]
        [HttpPost]
        public ActionResult Add(string out_in_come, string data, string department_id_to, string reason)
        {
            JArray json = JArray.Parse(data);
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary
                    {
                        documentary_type = 1,
                        department_id_to = department_id_to,
                        date_created = DateTime.Now,
                        person_created = Session["Name"] + "",
                        reason = reason,
                        out_in_come = out_in_come,
                        documentary_status = 1
                    };
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();

                    // Vị trí của thiết bị con được lấy theo vị trí của thiết bị to
                    List<string> list = new List<string>();
                    foreach (JObject item in json)
                    {
                        list.Add(item["attachTo"].Type == JTokenType.Null ? item["equipmentId"].ToString() : item["attachTo"].ToString());
                    }

                    var dict = (from e in DBContext.Equipments
                                join d in DBContext.Departments on e.department_id equals d.department_id
                                where list.Contains(e.equipmentId)
                                select new
                                {
                                    e.equipmentId,
                                    d.department_id
                                })
                        .Select(x => new { x.equipmentId, x.department_id })
                        .AsEnumerable()
                        .ToDictionary(d => d.equipmentId, d => d.department_id);

                    foreach (JObject item in json)
                    {
                        DateTime finish_date_plan = DateTime.ParseExact((string)item["date"], "dd/MM/yyyy", null);
                        string equipmentId = item["attachTo"].Type == JTokenType.Null ? item["equipmentId"].ToString() : item["attachTo"].ToString();
                        string equipmentId_dikem = item["attachTo"].Type == JTokenType.Null ? null : item["equipmentId"].ToString();

                        Documentary_repair_details drd = new Documentary_repair_details
                        {
                            department_id_from = dict[equipmentId],
                            equipment_repair_status = 0,
                            repair_type = item["type"].ToString(),
                            repair_reason = item["reason"].ToString(),
                            finish_date_plan = finish_date_plan,
                            documentary_id = documentary.documentary_id,
                            equipmentId = equipmentId,
                            equipmentId_dikem = equipmentId_dikem,
                            isVisible = true,
                            quantity = int.Parse(item["quantity"].ToString())
                        };
                        DBContext.Documentary_repair_details.Add(drd);
                        DBContext.SaveChanges();

                        JObject vattu = (JObject)item["supply"];
                        foreach (var jObject in vattu)
                        {
                            Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment
                            {
                                documentary_id = documentary.documentary_id,
                                equipmentId = equipmentId,
                                equipmentId_dikem = equipmentId_dikem,
                                supply_id = jObject.Key,
                                quantity_plan = int.Parse(jObject.Value.ToString()),
                            };
                            DBContext.Supply_Documentary_Equipment.Add(sde);
                        }
                        DBContext.SaveChanges();

                        JObject thietbi = (JObject)item["equipment"];
                        if (thietbi != null)
                        {
                            foreach (var jObject in thietbi)
                            {
                                Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment
                                {
                                    documentary_id = documentary.documentary_id,
                                    equipmentId = equipmentId,
                                    equipmentId_dikem = equipmentId_dikem ?? jObject.Key,
                                    quantity_plan = int.Parse(jObject.Value.ToString()),
                                };
                                DBContext.Supply_Documentary_Equipment.Add(sde);
                            }
                            DBContext.SaveChanges();
                        }
                    }

                    transaction.Commit();
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
        }

        private class _Location
        {
            public string equipmentId { get; set; }
            public string department_id { get; set; }
        }

        [Auther(RightID = "83")]
        [Route("phong-cdvt/quyet-dinh/sua-chua/export")]
        [HttpGet]
        public ActionResult ExportQuyetDinh()
        {
            string data = Request["data"];
            string title = Request["title"];
            string department_id = Request["department_id"];
            string documentary_type = Request["documentary_type"];
            string name = Request["fileName"];
            string resource = Request["resource"];

            using (QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities())
            {
                try
                {
                    Department department = DBContext.Departments.Find(department_id);
                    if (department == null)
                    {
                        return Json(new { success = false, message = "Mã phòng ban không tồn tại" }, JsonRequestBehavior.AllowGet);
                    }

                    DocumentaryType type = DBContext.DocumentaryTypes.Find(int.Parse(documentary_type));
                    if (type == null)
                    {
                        return Json(new { success = true, message = "Loại quyết định không tồn tại" }, JsonRequestBehavior.AllowGet);
                    }

                    //string Flocation = "/doc/CDVT/QD/quyetdinh.docx";
                    string fileName = HostingEnvironment.MapPath("/doc/CDVT/QD/quyetdinh-template.docx");
                    byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
                    using (var stream = new MemoryStream())
                    {
                        stream.Write(byteArray, 0, byteArray.Length);
                        using (var doc = WordprocessingDocument.Open(stream, true))
                        {
                            ////////////////////////////////////replace/////////////////////////////////
                            string docText = null;
                            using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                            {
                                docText = sr.ReadToEnd();
                            }

                            Regex regexText = new Regex("%ngay%");
                            docText = regexText.Replace(docText, DateTime.Now.Day.ToString());

                            regexText = new Regex("%thang%");
                            docText = regexText.Replace(docText, DateTime.Now.Month.ToString());

                            regexText = new Regex("%nam%");
                            docText = regexText.Replace(docText, DateTime.Now.Year.ToString());

                            regexText = new Regex("%noidung%");
                            docText = regexText.Replace(docText, title);

                            regexText = new Regex("%px%");
                            docText = regexText.Replace(docText, department.department_id.Contains("PX") ? department.department_name.Substring(11) : department.department_name);

                            regexText = new Regex("%loaiquyetdinh%");
                            docText = regexText.Replace(docText, type.documentary_name.Substring(11, type.documentary_name.Length - 19));

                            regexText = new Regex("%nguon%");
                            docText = regexText.Replace(docText, resource);

                            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                            {
                                sw.Write(docText);
                            }
                            /////////////////////////////////////////////////////////////////////
                            JObject json = JObject.Parse(data);
                            Table table =
                            doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(1);
                            foreach (var item in json)
                            {
                                string equipmentId = (string)item.Value["id"];
                                if (item.Value["vattu"] != null)
                                {
                                    AppendRow((JArray)item.Value.SelectToken("vattu"), equipmentId, table);
                                }
                                if (item.Value["duphong"] != null)
                                {
                                    AppendRow((JArray)item.Value.SelectToken("duphong"), equipmentId, table);
                                }
                                if (item.Value["dikem"] != null)
                                {
                                    AppendRow((JArray)item.Value.SelectToken("dikem"), equipmentId, table);
                                }
                                doc.MainDocumentPart.Document.Save();
                            }
                            stream.Position = 0;
                            string handle = Guid.NewGuid().ToString();
                            TempData[handle] = stream.ToArray();

                            if (TempData[handle] != null)
                            {
                                byte[] output = TempData[handle] as byte[];
                                return File(output, "application/vnd.ms-excel", name);
                            }
                            else
                            {
                                return new EmptyResult();
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    if (e is FormatException)
                        return Json(new { success = false, message = "Loại quyết định không tồn tại" }, JsonRequestBehavior.AllowGet);
                    return Json(new { success = false, message = "Có lỗi xảy ra" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        private void AppendRow(JArray vattu, string equipmentId, Table table)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            foreach (JObject jObject in vattu)
            {
                string supply_id = (string)jObject["supply_id"];
                int quantity = (int)jObject["quantity"];
                Supply s = DBContext.Supplies.Find(supply_id);
                TableRow tr = new TableRow();

                TableCell tc1 = new TableCell();
                tc1.Append(new Paragraph(new Run(new Text("1"))));
                tr.Append(tc1);

                TableCell tc2 = new TableCell();
                tc2.Append(new Paragraph(new Run(new Text(equipmentId))));
                tr.Append(tc2);

                TableCell tc3 = new TableCell();
                tc3.Append(new Paragraph(new Run(new Text(s.supply_name))));
                tr.Append(tc3);

                TableCell tc4 = new TableCell();
                tc4.Append(new Paragraph(new Run(new Text(s.unit))));
                tr.Append(tc4);

                TableCell tc5 = new TableCell();
                tc5.Append(new Paragraph(new Run(new Text(quantity.ToString()))));
                tr.Append(tc5);

                TableCell tc6 = new TableCell();
                tc6.Append(new Paragraph(new Run(new Text(""))));
                tr.Append(tc6);

                TableCell tc7 = new TableCell();
                tc7.Append(new Paragraph(new Run(new Text(""))));
                tr.Append(tc7);

                table.Append(tr);
            }
        }
    }
}