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
    public class ChitietSuachuaCamController : Controller
    {
        [Auther(RightID = "193")]
        [HttpGet]
        public ActionResult LoadPage(String id)
        {
            ViewBag.id = id.ToString().Split('^')[0];

            return View("/Views/Camera/Chi_tiet_sua_chua.cshtml");
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public class CameraDetail: Room
        {
            public string reason { get; set; }
            public int documentary_id { get; set; }
            public string idAndEquip { get; set; }
        }

        [HttpPost]
        public ActionResult Detail()
        {
            string requestID = Request["sessionId"];
            int id = Int32.Parse(requestID);
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                try
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    string query = "select c.camera_id, c.camera_name, r.room_name, doc.reason, docCam.documentary_id from Documentary_camera_repair_details docCam join " +
                        "Documentary doc on doc.documentary_id = docCam.documentary_id join Camera c on c.camera_id = docCam.camera_id join " +
                        "Room r on r.room_id = c.room_id join Department d on d.department_id = r.department_id where docCam.documentary_id = @requestID";
                    List<CameraDetail> documentariesList = db.Database.SqlQuery<CameraDetail>(query, new SqlParameter("requestID", requestID)).ToList();
                    int totalrows = documentariesList.Count;
                    int totalrowsafterfiltering = documentariesList.Count;

                    //sorting
                    documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<CameraDetail>();
                    //paging

                    documentariesList = documentariesList.Skip(start).Take(length).ToList<CameraDetail>();
                    Console.WriteLine(Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet));

                    var js = Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                    var result = new JavaScriptSerializer().Serialize(js.Data);
                    ViewBag.count = 0;
                    return js;
                }catch(Exception e)
                {
                    e.Message.ToString();
                    return null;
                }
            }
        }

        [Route("camera/GetSupply")]
        [HttpPost]
        public ActionResult GetSupply(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("select s.supply_id, s.supply_name, sdc.quantity_plan, sdc.supplyStatus from Supply_Documentary_Camera sdc join Supply s on sdc.supply_id = s.supply_id where documentary_id = @documentary_id and sdc.camera_id = @equipmentId",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                return Json(new
                {
                    success = false,
                    data = supplies,
                    message = "Không có vật tư nào!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new
                {
                    success = true,
                    data = supplies
                }, JsonRequestBehavior.AllowGet);

        }
        public class Supply_Detail
        {
            public string supply_id { get; set; }
            public string supply_name { get; set; }
            public int quantity_plan { get; set; }
            public string supplyStatus { get; set; }
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