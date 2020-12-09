using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using static QUANGHANH2.Controllers.Camera.Quyetdinh.ChonThietBiController;

namespace QUANGHANH2.Controllers.Camera.Quyetdinh.SuaChua
{
    public class ThemController : Controller
    {
        [Auther(RightID = "193")]
        [Route("camera/sua-chua-chon")]
        [HttpPost]
        public ActionResult Index(string abc)
        {
            var listConvert = JArray.Parse(abc).Select(x => x.ToString());
            List<string> room_id = new List<string>();

            foreach (JToken item in listConvert)
            {
                room_id.Add(item.ToString());
            }
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var result = (from a in db.Rooms
                              where room_id.Contains(a.room_id.ToString())
                              join r in db.Rooms on a.room_id equals r.room_id
                              join d in db.Departments on r.department_id equals d.department_id
                              where r.camera_available < r.camera_quantity && r.camera_quantity != 0
                              select new RoomList
                              {
                                  room_id = a.room_id,
                                  room_name = a.room_name,
                                  department_name = d.department_name,
                                  department_id = r.department_id,
                                  camera_available = r.camera_available,
                                  camera_quantity = r.camera_quantity
                              }).ToList();
                ViewBag.DataThietBi = result;

                List<Supply> supplies = db.Supplies.Select(x => new
                {
                    x.supply_id,
                    x.supply_name
                }).ToList().Select(x => new Supply
                {
                    supply_id = x.supply_id,
                    supply_name = x.supply_name
                }).ToList();

                List<Department> departments = db.Departments.Select(x => new
                {
                    x.department_id,
                    x.department_name
                }).ToList().Select(x => new Department
                {
                    department_id = x.department_id,
                    department_name = x.department_name
                }).ToList();

                ViewBag.ListSelected = abc;
                ViewBag.Supplies = supplies;
                ViewBag.Departments = departments;
            }
            return View("/Views/Camera/Quyetdinh/SuaChua/Them.cshtml");
        }

        [Auther(RightID = "193")]
        [Route("camera/sua-chua-chon/add")]
        [HttpPost]
        public ActionResult Add(string out_in_come, string data, string department_id, string reason)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary
                    {
                        documentary_type = 8,
                        date_created = DateTime.Now,
                        person_created = Session["Name"] + ""
                    };
                    documentary.reason = reason;
                    documentary.out_income = out_in_come;
                    documentary.department_id_to = department_id;
                    documentary.documentary_status = 1;
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string room_id = item.Value["id"].ToString();
                        string repair_requirement = (string)item.Value["repair_requirement"];
                        string datestring = (string)item.Value["finish_date_plan"];

                        CameraRepairDetail drd = new CameraRepairDetail
                        {
                            documentary_camera_repair_status = 0,
                            documentary_id = documentary.documentary_id,
                            room_id = room_id,
                            broken_camera_quantity = (int)item.Value["broken_camera_quantity"],
                            repair_requirement = repair_requirement,
                            note = (string)item.Value["note"],
                            department_id = (string)item.Value["department_id"]
                        };
                        DBContext.CameraRepairDetails.Add(drd);
                        DBContext.SaveChanges();
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        foreach (JObject jObject in vattu)
                        {
                            string supply_id = (string)jObject["supply_id"];
                            int quantity = (int)jObject["quantity"];
                            RepairCamera sde = new RepairCamera
                            {
                                documentary_id = documentary.documentary_id,
                                room_id = room_id,
                                supply_id = supply_id,
                                quantity_plan = quantity
                            };
                            DBContext.RepairCameras.Add(sde);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true });
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return Json(new { success = false });
                }
            }
        }

        //[Auther(RightID = "193")]
        [Route("phong-cdvt/quyet-dinh/camera/them/export")]
        [HttpGet]
        public ActionResult ExportQuyetDinh(string out_in_come, string data, string department_id_to, string reason)
        {
            using (QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities())
            {
                try
                {
                    Department department = DBContext.Departments.Find(department_id_to);
                    if (department == null)
                    {
                        return Json(new { success = false, message = "Mã phòng ban không tồn tại" }, JsonRequestBehavior.AllowGet);
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
                            docText = regexText.Replace(docText, reason);

                            regexText = new Regex("%px%");
                            docText = regexText.Replace(docText, department.department_id.Contains("PX") ? department.department_name.Substring(11) : department.department_name);

                            regexText = new Regex("%loaiquyetdinh%");
                            docText = regexText.Replace(docText, "quyết định sửa chữa camera");

                            regexText = new Regex("%nguon%");
                            docText = regexText.Replace(docText, out_in_come);

                            using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                            {
                                sw.Write(docText);
                            }
                            /////////////////////////////////////////////////////////////////////
                            JArray json = JArray.Parse(data);
                            Table table =
                            doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(1);
                            foreach (JObject item in json)
                            {
                                string equipmentId = item["attachTo"].Type == JTokenType.Null ? item["equipmentId"].ToString() : item["equipmentId"].ToString() + $" ({item["attachTo"]})";

                                if (item["supply"] != null)
                                {
                                    AppendRow((JObject)item["supply"], equipmentId, table, true);
                                }
                                if (item["equipment"] != null)
                                {
                                    AppendRow((JObject)item["equipment"], equipmentId, table, false);
                                }
                                doc.MainDocumentPart.Document.Save();
                            }
                            stream.Position = 0;
                            string handle = Guid.NewGuid().ToString();
                            TempData[handle] = stream.ToArray();

                            if (TempData[handle] != null)
                            {
                                byte[] output = TempData[handle] as byte[];
                                return File(output, "application/vnd.ms-excel", "Quyết định sửa chữa.docx");
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

        private void AppendRow(JObject vattu, string equipmentId, Table table, bool isSupply)
        {
            QuangHanhManufacturingEntities DBContext = new QuangHanhManufacturingEntities();
            foreach (var jObject in vattu)
            {
                string id = jObject.Key;
                int quantity = int.Parse(jObject.Value.ToString());
                string name, unit;

                if (isSupply)
                {
                    Supply s = DBContext.Supplies.Find(id);
                    name = s.supply_name;
                    unit = s.unit;
                }
                else
                {
                    Equipment e = DBContext.Equipments.Find(id);
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
                tc7.Append(new Paragraph(new Run(new Text(""))));
                tr.Append(tc7);

                table.Append(tr);
            }
        }
    }
}