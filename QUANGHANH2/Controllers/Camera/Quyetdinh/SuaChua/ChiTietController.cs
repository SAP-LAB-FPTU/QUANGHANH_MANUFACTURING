using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using DocumentFormat.OpenXml.Wordprocessing;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.Camera
{
    public class ChiTietController : Controller
    {
        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/quyet-dinh/sua-chua/chi-tiet")]
        public ActionResult Index()
        {
            int id = int.Parse(Request["id"]);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                string documentary_code = db.Documentaries.Find(id).documentary_code;
                ViewBag.documentary_code = documentary_code;

                var listRooms = (from r in db.Rooms
                                 join d in db.Documentary_camera_repair_details on r.room_id equals d.room_id
                                 join depa in db.Departments on r.department_id equals depa.department_id
                                 select new RoomDetail
                                 {
                                     room_id = r.room_id,
                                     room_name = r.room_name,
                                     department_name = depa.department_name,
                                     broken_camera_quantity = d.broken_camera_quantity,
                                     repair_requirement = d.repair_requirement,
                                     note = d.note
                                 }).ToList();
                ViewBag.listRooms = listRooms;

                var listSupplies = (from r in db.Supply_Documentary_Camera
                                    join s in db.Supplies on r.supply_id equals s.supply_id
                                    select new
                                    {
                                        room_id = r.room_id,
                                        supply_id = r.supply_id,
                                        quantity_plan = r.quantity_plan,
                                        supply_name = s.supply_name
                                    }).ToList();

                JObject temp = new JObject();
                foreach (var room in listRooms)
                {
                    JArray list = new JArray();
                    for (int i = 0; i < listSupplies.Count; i++)
                    {
                        var supply = listSupplies[i];
                        if (supply.room_id.Equals(room.room_id))
                        {
                            list.Add(JToken.FromObject(new
                            {
                                supply_id = supply.supply_id,
                                supply_name = supply.supply_name,
                                quantity_plan = supply.quantity_plan
                            }));
                        }
                    }
                    temp.Add(room.room_id.ToString(), list);
                }
                ViewBag.listSupplies = temp.ToString();
            }
            return View("/Views/Camera/Quyetdinh/SuaChua/ChiTiet.cshtml");
        }

        public class RoomDetail : Documentary_camera_repair_details
        {
            public string room_name { get; set; }
            public string department_name { get; set; }
        }

        [Route("camera/quyet-dinh/export-word")]
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