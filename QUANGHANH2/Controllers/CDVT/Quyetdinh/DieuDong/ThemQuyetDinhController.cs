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
using System.Web.SessionState;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh.DieuDong
{
    [SessionState(SessionStateBehavior.Default)]
    public class DieudongchonController : Controller
    {
        private readonly QUANGHANHABCEntities db = new QUANGHANHABCEntities();

        [Auther(RightID = "87")]
        [Route("phong-cdvt/dieu-dong-chon")]
        [HttpGet]
        public ActionResult Index(String selectListJson)
        {
            var listSelected = selectListJson;
            db.Configuration.LazyLoadingEnabled = false;

            var result = (from e in db.Equipments
                          where listSelected.Contains(e.equipmentId)
                          join d in db.Departments on e.department_id equals d.department_id
                          join c in db.Status on e.current_Status equals c.statusid
                          select new equipmentExtend
                          {
                              equipmentId = e.equipmentId,
                              equipment_name = e.equipment_name,
                              department_name = d.department_name,
                              department_id = e.department_id,
                              current_Status = e.current_Status,
                              statusname = c.statusname,

                          }).ToList();
            ViewBag.DataThietBi = result;

            List<Supply> supplies = db.Supplies.ToList();
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
                                  where a.isAttach == true && listSelected.Contains(b.equipmentId)
                                  select new MiniEquipment
                                  {
                                      equipmentId = a.equipmentId,
                                      equipment_name = a.equipment_name
                                  }).ToList();
            ViewBag.Supplies = supplies;
            ViewBag.Departments = departments;
            ViewBag.equipAttached = equipAttached1.Union(equipAttacked2).ToList();
            return View("/Views/CDVT/Work/dieu_dong_va_chon.cshtml");
        }

        public class MiniEquipment
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
        }

        [Auther(RightID = "87")]
        [Route("phong-cdvt/dieu-dong-chon")]
        [HttpPost]
        public ActionResult Add(string out_in_come, string data, string department_id, string reason)
        {
            string department_id_to = Request["department_id_to"];
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary
                    {
                        documentary_type = 3,
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
                        string department_detail = (string)item.Value["department_detail"];
                        string equipment_moveline_reason = (string)item.Value["equipment_moveline_reason"];
                        string datestring = (string)item.Value["date_to"];
                        DateTime date_to = DateTime.ParseExact(datestring, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        Documentary_moveline_details drd = new Documentary_moveline_details();
                        Equipment e = db.Equipments.Find(equipmentId);
                        drd.department_id_from = e.department_id;
                        drd.equipment_moveline_status = 0;
                        drd.department_detail = department_detail;
                        drd.date_to = date_to;
                        drd.equipment_moveline_reason = equipment_moveline_reason;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        db.Documentary_moveline_details.Add(drd);
                        db.SaveChanges();
                        JArray thietbi = (JArray)item.Value.SelectToken("thietbi");
                        foreach (JObject jObject in thietbi)
                        {
                            string equipmentId_dikem = (string)jObject["equipmentId"];
                            int quantity_dikem = (int)jObject["quantity_dikem"];
                            int quantity_duphong = (int)jObject["quantity_duphong"];
                            Supply_Documentary_Equipment sde1 = new Supply_Documentary_Equipment
                            {
                                documentary_id = documentary.documentary_id,
                                equipmentId = equipmentId,
                                equipmentId_dikem = equipmentId_dikem,
                                quantity_plan = quantity_dikem,
                                supplyStatus = "dikem"
                            };
                            db.Supply_Documentary_Equipment.Add(sde1);
                            Supply_Documentary_Equipment sde2 = new Supply_Documentary_Equipment
                            {
                                documentary_id = documentary.documentary_id,
                                equipmentId = equipmentId,
                                equipmentId_dikem = equipmentId_dikem,
                                quantity_plan = quantity_duphong,
                                supplyStatus = "duphong"
                            };
                            db.Supply_Documentary_Equipment.Add(sde2);
                            db.SaveChanges();
                        }
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        foreach (JObject jObject in vattu)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            Supply_Documentary_Equipment sde = new Supply_Documentary_Equipment
                            {
                                documentary_id = documentary.documentary_id,
                                equipmentId = equipmentId,
                                supply_id = supply_id,
                                quantity_plan = quantity,
                                supplyStatus = null
                            };
                            db.Supply_Documentary_Equipment.Add(sde);
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();

                    transaction.Commit();

                    return Json(new { success = true, message = "Tạo quyết định thành công, đang chuyển hướng" });
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                    throw e;

                }
            }
        }

        [Auther(RightID = "87")]
        [Route("phong-cdvt/dieu-dong-chon/getdata")]
        [HttpPost]
        public ActionResult GetData(string equipmentId)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var output = db.Supply_DiKem.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
            return Json(output);
        }

        [Auther(RightID = "87")]
        [Route("phong-cdvt/dieu-dong-chon/export")]
        [HttpGet]
        public ActionResult Export()
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
                                    AppendRow((JArray)item.Value.SelectToken("vattu"), equipmentId, table, "vattu");
                                }
                                if (item.Value["thietbi"] != null)
                                {
                                    AppendRow((JArray)item.Value.SelectToken("thietbi"), equipmentId, table, "thietbi");
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
                        quantity = (int)jObject["quantity"];
                        name = s.supply_name;
                        unit = s.unit;
                    }
                    else
                    {
                        Equipment e = db.Equipments.Find((string)jObject["equipmentId"]);
                        int dikem = (int)jObject["quantity_dikem"];
                        int duphong = (int)jObject["quantity_duphong"];
                        quantity = dikem + duphong;
                        name = e.equipment_name;
                        unit = "Cái";
                        note = dikem + " đi kèm";
                        if (duphong != 0)
                            note += ", " + duphong + " dự phòng";
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