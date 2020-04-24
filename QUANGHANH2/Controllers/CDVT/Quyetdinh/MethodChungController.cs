using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh
{
    public class MethodChungController : Controller
    {
        [HttpPost]
        public ActionResult GetSmallEquip(string equipmentId)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var data = (from a in db.Equipments
                                join b in db.Supply_DiKem on a.equipmentId equals b.equipmentId_dikem
                                where a.isAttach == true && b.equipmentId.Equals(equipmentId) && b.quantity > 0
                                select new
                                {
                                    a.equipmentId,
                                    a.equipment_name,
                                    b.quantity,
                                }).ToList();
                    return Json(new { success = true, data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [Route("phong-cdvt/quyet-dinh/update")]
        [HttpPost]
        public ActionResult Update()
        {
            int documentary_id = int.Parse(Request["documentary_id"]);
            string documentary_code = Request["documentary_code"];
            string reason = Request["reason"];
            string out_in_come = Request["out_in_come"];
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {

                        if (db.Documentaries.Where(x => x.documentary_code == documentary_code).FirstOrDefault() != null)
                            return Json(new { success = false, message = "Số quyết định đã tồn tại" });
                        Documentary doc = db.Documentaries.Find(documentary_id);
                        if (doc == null)
                            return Json(new { success = false, message = "Quyết định không tồn tại" });
                        doc.documentary_code = documentary_code == "" ? null : documentary_code;
                        doc.reason = reason;
                        doc.out_in_come = out_in_come;

                        if (doc.documentary_code != null)
                        {
                            Notification noti = new Notification();
                            noti.description = "";
                            switch (doc.documentary_type)
                            {
                                case 1:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 3
where equipmentId in
(select equipmentId from Documentary_repair_details where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    noti.description = "sua chua";
                                    break;
                                case 2:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 5
where equipmentId in
(select equipmentId from Documentary_maintain_details where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    noti.description = "bao duong";
                                    break;
                                case 3:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 6
where equipmentId in
(select equipmentId from Documentary_moveline_details where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 6
where equipmentId in
(select distinct equipmentId_dikem from Supply_Documentary_Equipment where documentary_id = @documentary_id and equipmentId_dikem is not null)", new SqlParameter("documentary_id", documentary_id));
                                    noti.description = "dieu dong";
                                    break;
                                case 4:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 7
where equipmentId in
(select equipmentId from Documentary_revoke_details where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    break;
                                case 5:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 8
where equipmentId in
(select equipmentId from Documentary_liquidation_details where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    break;
                                case 6:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 9
where equipmentId in 
(select equipmentId from Documentary_big_maintain_details where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    noti.description = "trung dai tu";
                                    break;
                                case 7:
                                    db.Database.ExecuteSqlCommand(@"update Equipment set current_Status = 16
where equipmentId in
(select equipmentId from Documentary_Improve_Detail where documentary_id = @documentary_id)", new SqlParameter("documentary_id", documentary_id));
                                    noti.description = "cai tien";
                                    break;
                                case 8:
                                    break;
                                default:
                                    return Json(new { success = false, message = "Loại quyết định không tồn tại" });
                            }
                            if (!noti.description.Equals(""))
                            {
                                noti.date = DateTime.Now.Date;
                                noti.department_id = doc.department_id_to;
                                noti.id_problem = doc.documentary_id;
                                noti.isread = false;
                                db.Notifications.Add(noti);
                                db.SaveChanges();
                            }
                        }

                        db.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" });
                    }
                }
            }
            return Json(new { success = true, message = "Cập nhật thành công" });
        }

        [Route("phong-cdvt/quyet-dinh/delete")]
        [HttpPost]
        public ActionResult Delete()
        {
            int documentary_id = int.Parse(Request["documentary_id"]);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Documentary doc = db.Documentaries.Find(documentary_id);
                if (doc == null)
                    return Json(new { success = false, message = "Mã quyết định không tồn tại" });

                if (doc.documentary_code != null)
                    return Json(new { success = false, message = "Bạn không được xóa quyết định này" });

                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        switch (doc.documentary_type)
                        {
                            case 8:
                                db.Database.ExecuteSqlCommand("DELETE FROM Supply_Documentary_Camera WHERE documentary_id = " + documentary_id);
                                db.Database.ExecuteSqlCommand("DELETE FROM Documentary_camera_repair_details WHERE documentary_id = " + documentary_id);
                                db.Database.ExecuteSqlCommand("DELETE FROM Documentary WHERE documentary_id = " + documentary_id);
                                break;
                            default:
                                db.Documentaries.Remove(doc);
                                break;
                        }
                        db.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return Json(new { success = false, message = "Có lỗi xảy ra" });
                    }
                }
                return Json(new { success = true, message = "Xóa thành công" });
            }
        }

        //export file world
        [Auther(RightID = "83,85,87,89,91,95")]
        [Route("phong-cdvt/quyet-dinh/export-word")]
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