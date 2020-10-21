using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json.Linq;
using QUANGHANH_MANUFACTURING.Models;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.Quyetdinh.DieuChinh
{
    public class ThemCaiTienController : Controller
    {
        private readonly QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

        [Auther(RightID = "85")]
        [Route("phong-cdvt/quyet-dinh/dieu-chinh/them")]
        [HttpGet]
        public ActionResult Index(String selected)
        {
            ViewBag.selected = selected;

            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<equipmentExtend> result = (from e in db.Equipments
                                                where selected.Contains(e.equipmentId)
                                                join d in db.Departments on e.department_id equals d.department_id
                                                join c in db.Status on e.current_Status equals c.statusid
                                                select new equipmentExtend
                                                {
                                                    equipmentId = e.equipmentId,
                                                    equipment_name = e.equipment_name,
                                                    statusname = c.statusname,
                                                    department_id = e.department_id,
                                                }).ToList();
                ViewBag.DataThietBi = result;

                List<Supply_DiKem> vatTuDiKem = (from s in db.Supply_DiKem
                                                 where selected.Contains(s.equipmentId)
                                                 select s).ToList().Select(s => new Supply_DiKem
                                                 {
                                                     equipmentId_dikem = s.equipmentId_dikem,
                                                     equipmentId = s.equipmentId,
                                                 }).OrderBy(l => l.equipmentId).ToList();

                List<Department> departments = db.Departments.ToList();
                var equipAttached1 = (from a in db.Equipments
                                      join b in db.Supply_DiKem on a.equipmentId equals b.equipmentId_dikem into newlist
                                      from c in newlist.DefaultIfEmpty()
                                      where c.equipmentId_dikem == null && a.isAttach == true
                                      select new MiniEquipment
                                      {
                                          equipmentId = a.equipmentId,
                                          equipment_name = a.equipment_name
                                      }).ToList();
                var equipAttacked2 = (from a in db.Equipments
                                      join b in db.Supply_DiKem on a.equipmentId equals b.equipmentId_dikem
                                      where a.isAttach == true && selected.Contains(b.equipmentId)
                                      select new MiniEquipment
                                      {
                                          equipmentId = a.equipmentId,
                                          equipment_name = a.equipment_name
                                      }).ToList();
                ViewBag.equipAttached = equipAttached1.Union(equipAttacked2).ToList();
                ViewBag.vatTuDiKem = vatTuDiKem;
                ViewBag.supply_inverse = db.Supplies.Take(10).ToList();
                ViewBag.Departments = departments;
            }
            return View("/Views/CDVT/Quyetdinh/DieuChinh/Them.cshtml");
        }

        public class MiniEquipment
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
        }

        [Auther(RightID = "85")]
        [Route("phong-cdvt/cai-tien-chon/add")]
        [HttpPost]
        public ActionResult Add(string out_in_come, string data, string reason)
        {
            string department_id_to = Request["department_id_to"];
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary
                    {
                        documentary_type = 7,
                        department_id_to = department_id_to,
                        date_created = DateTime.Now,
                        person_created = Session["Name"] + "",
                        reason = reason,
                        out_in_come = out_in_come,
                        documentary_status = 1
                    };
                    db.Documentaries.Add(documentary);
                    db.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string equipmentId = (string)item.Value["id"];
                        Documentary_Improve_Detail drd = new Documentary_Improve_Detail();
                        Equipment e = db.Equipments.Find(equipmentId);
                        drd.department_id_from = e.department_id;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        db.Documentary_Improve_Detail.Add(drd);
                        db.SaveChanges();
                        JArray thietbi = (JArray)item.Value.SelectToken("thietbi");
                        foreach (JObject jObject in thietbi)
                        {
                            Supply_Documentary_Improve_Equipment sde1 = new Supply_Documentary_Improve_Equipment
                            {
                                documentary_improve_id = drd.documentary_improve_id,
                                equipmentId = (string)jObject["equipmentId"],
                                quantity_before = (int)jObject["quantity_before"],
                                quantity_after = (int)jObject["quantity_after"]
                            };
                            db.Supply_Documentary_Improve_Equipment.Add(sde1);
                            db.SaveChanges();
                        }
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        foreach (JObject jObject in vattu)
                        {
                            Supply_Documentary_Improve_Equipment sde = new Supply_Documentary_Improve_Equipment
                            {
                                documentary_improve_id = drd.documentary_improve_id,
                                supply_id = (string)jObject["supply_id"],
                                quantity_before = (int)jObject["quantity_before"],
                                quantity_after = (int)jObject["quantity_after"]
                            };
                            db.Supply_Documentary_Improve_Equipment.Add(sde);
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();

                    transaction.Commit();

                    return Json(new { success = true, message = "Tạo quyết định thành công, đang chuyển hướng" });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });

                }
            }
        }

        [Auther(RightID = "87")]
        [Route("phong-cdvt/quyet-dinh/dieu-chinh/them/export")]
        [HttpGet]
        public ActionResult ExportQuyetDinh(string data, string department_id_to, string reason)
        {
            string type = Request["Isimprove"] == "true" ? "cải tiến" : "thu hồi";
            using (QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities())
            {
                try
                {
                    Department department = DBContext.Departments.Find(department_id_to);
                    if (department == null)
                    {
                        return new HttpStatusCodeResult(400);
                    }

                    string fileName = HostingEnvironment.MapPath("/doc/CDVT/QD/quyetdinh-dieudong-template.docx");
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
                            docText = regexText.Replace(docText, reason);

                            regexText = new Regex("%px%");
                            docText = regexText.Replace(docText, department.department_id.Contains("PX") ? department.department_name.Substring(11) : department.department_name);

                            regexText = new Regex("%loaiquyetdinh%");
                            docText = regexText.Replace(docText, type);

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
                                bool added = false;
                                string equipmentId = (string)item.Value["id"];
                                if (item.Value["vattu"] != null && item.Value["vattu"].HasValues)
                                {
                                    AppendRow((JArray)item.Value.SelectToken("vattu"), equipmentId, table, "vattu");
                                    added = true;
                                }
                                if (item.Value["thietbi"] != null && item.Value["thietbi"].HasValues)
                                {
                                    AppendRow((JArray)item.Value.SelectToken("thietbi"), equipmentId, table, "thietbi");
                                    added = true;
                                }
                                if (!added)
                                {
                                    TableRow tr = new TableRow();

                                    TableCell tc1 = new TableCell();
                                    tc1.Append(new Paragraph(new Run(new Text("1"))));
                                    tr.Append(tc1);

                                    TableCell tc2 = new TableCell();
                                    tc2.Append(new Paragraph(new Run(new Text(equipmentId))));
                                    tr.Append(tc2);

                                    TableCell tc3 = new TableCell();
                                    tc3.Append(new Paragraph(new Run(new Text(""))));
                                    tr.Append(tc3);

                                    TableCell tc4 = new TableCell();
                                    tc4.Append(new Paragraph(new Run(new Text(""))));
                                    tr.Append(tc4);

                                    TableCell tc5 = new TableCell();
                                    tc5.Append(new Paragraph(new Run(new Text(""))));
                                    tr.Append(tc5);

                                    TableCell tc6 = new TableCell();
                                    tc6.Append(new Paragraph(new Run(new Text(""))));
                                    tr.Append(tc6);

                                    TableCell tc7 = new TableCell();
                                    tc7.Append(new Paragraph(new Run(new Text(""))));
                                    tr.Append(tc7);

                                    table.Append(tr);
                                }
                                doc.MainDocumentPart.Document.Save();
                            }
                            stream.Position = 0;
                            string handle = Guid.NewGuid().ToString();
                            TempData[handle] = stream.ToArray();

                            if (TempData[handle] != null)
                            {
                                byte[] output = TempData[handle] as byte[];
                                return File(output, "application/vnd.ms-excel", $"Quyết định {type}.docx");
                            }
                            else
                            {
                                return new HttpStatusCodeResult(400);
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    return new HttpStatusCodeResult(400);
                }
            }
        }

        private void AppendRow(JArray vattu, string equipmentId, Table table, string type)
        {
            foreach (JObject jObject in vattu)
            {
                try
                {
                    int quantity;
                    string name;
                    string unit;
                    string note = "";
                    if (type == "vattu")
                    {
                        Supply s = db.Supplies.Find((string)jObject["supply_id"]);
                        quantity = (int)jObject["quantity_after"];
                        name = s.supply_name;
                        unit = s.unit;
                    }
                    else
                    {
                        Equipment e = db.Equipments.Find((string)jObject["equipmentId"]);
                        quantity = (int)jObject["quantity_after"];
                        name = e.equipment_name;
                        unit = "Cái";
                    }
                    TableRow tr = new TableRow();

                    TableCell tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text("1"))));
                    tr.Append(tc1);

                    TableCell tc2 = new TableCell();
                    tc2.Append(new Paragraph(new Run(new Text(equipmentId))));
                    tr.Append(tc2);

                    TableCell tc3 = new TableCell();
                    tc3.Append(new Paragraph(new Run(new Text(name))));
                    tr.Append(tc3);

                    TableCell tc4 = new TableCell();
                    tc4.Append(new Paragraph(new Run(new Text(unit))));
                    tr.Append(tc4);

                    TableCell tc5 = new TableCell();
                    tc5.Append(new Paragraph(new Run(new Text(quantity.ToString()))));
                    tr.Append(tc5);

                    TableCell tc6 = new TableCell();
                    tc6.Append(new Paragraph(new Run(new Text(""))));
                    tr.Append(tc6);

                    TableCell tc7 = new TableCell();
                    tc7.Append(new Paragraph(new Run(new Text(note))));
                    tr.Append(tc7);

                    table.Append(tr);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}