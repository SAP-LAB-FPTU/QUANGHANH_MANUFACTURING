using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using System.Text.RegularExpressions;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class ThanhlychonController : Controller
    {
        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly-chon")]
        [HttpGet]
        public ActionResult Index(String selectListJson)
        {
            var listSelected = selectListJson;
            var listConvert = listSelected;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                var result = (from e in db.Equipments
                              where listConvert.Contains(e.equipmentId)
                              join d in db.Departments on e.department_id equals d.department_id
                              join c in db.Status on e.current_Status equals c.statusid
                              select new
                              {
                                  equipmentId = e.equipmentId,
                                  equipment_name = e.equipment_name,
                                  department_name = d.department_name,
                                  department_id = e.department_id,
                                  current_Status = e.current_Status,
                                  statusname = c.statusname,
                              }).ToList().Select(s => new equipmentExtend
                              {
                                  equipmentId = s.equipmentId,
                                  equipment_name = s.equipment_name,
                                  department_name = s.department_name,
                                  department_id = s.department_id,
                                  current_Status = s.current_Status,
                                  statusname = s.statusname,

                              }).ToList();
                ViewBag.DataThietBi = result;

                List<Supply> supplies = db.Supplies.ToList();
                List<Department> departments = db.Departments.ToList();
                try
                {
                    int validate = 1;
                    var department_id = result[0].department_id;
                    foreach (var item in result)
                    {
                        if (!item.department_id.Equals(department_id))
                        {
                            validate = 0;
                            break;
                        }
                    }
                    Department department = db.Departments.Find(department_id);
                    ViewBag.validate = validate;
                    ViewBag.department_name = department.department_name;
                    ViewBag.department_id = department.department_id;
                    ViewBag.Supplies = supplies;
                    ViewBag.Departments = departments;
                }
                catch(Exception e)
                {
                    ViewBag.alert = true;
                    TempData["shortMessage"] = true;
                    return Redirect("thanh-ly");
                    throw e;
                }

               
            }
            return View("/Views/CDVT/Work/thanhly_va_chon.cshtml");
        }


        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly-chon")]
        [HttpPost]
        public ActionResult GetData(string documentary_code, string out_in_come, string data, string department_id, string reason)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
            {
                try
                {
                    Documentary documentary = new Documentary();
                    documentary.documentary_code = documentary_code == "" ? null : documentary_code;
                    documentary.documentary_type = 5;
                    documentary.department_id = department_id;
                    documentary.date_created = DateTime.Now;
                    documentary.person_created = Session["Name"] + "";
                    documentary.reason = reason;
                    documentary.out_in_come = out_in_come;
                    documentary.documentary_status = 1;
                    DBContext.Documentaries.Add(documentary);
                    DBContext.SaveChanges();
                    JObject json = JObject.Parse(data);
                    foreach (var item in json)
                    {
                        string equipmentId = (string)item.Value["id"];
                        string buyer = (string)item.Value["buyer"];
                        string equipment_liquidation_reason = (string)item.Value["equipment_liquidation_reason"];
                        if (documentary_code != "")
                        {
                            Equipment e = DBContext.Equipments.Find(equipmentId);
                            e.current_Status = 8;
                        }

                        Documentary_liquidation_details drd = new Documentary_liquidation_details();
                        drd.equipment_liquidation_status = 0;
                        drd.buyer = buyer;
                        drd.equipment_liquidation_reason = equipment_liquidation_reason;
                        drd.documentary_id = documentary.documentary_id;
                        drd.equipmentId = equipmentId;
                        DBContext.Documentary_liquidation_details.Add(drd);
                        DBContext.SaveChanges();
                        List<Supply_DiKem> diKem = DBContext.Supply_DiKem.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
                        foreach (Supply_DiKem supply in diKem)
                        {
                            Supply_Documentary_Equipment s = new Supply_Documentary_Equipment();
                            s.documentary_id = documentary.documentary_id;
                            s.equipmentId = equipmentId;
                            s.quantity_plan = supply.quantity;
                            s.supply_id = supply.supply_id;
                            s.supplyStatus = supply.note;
                            DBContext.Supply_Documentary_Equipment.Add(s);
                            DBContext.SaveChanges();
                        }
                        List<Supply_DuPhong> duPhong = DBContext.Supply_DuPhong.Where(x => x.equipmentId.Equals(equipmentId)).ToList();
                        foreach (Supply_DuPhong supply in duPhong)
                        {
                            Supply_Documentary_Equipment s = new Supply_Documentary_Equipment();
                            s.documentary_id = documentary.documentary_id;
                            s.equipmentId = equipmentId;
                            s.quantity_plan = supply.quantity;
                            s.supply_id = supply.supply_id;
                            s.supply_documentary_status = 1;
                            DBContext.Supply_Documentary_Equipment.Add(s);
                            DBContext.SaveChanges();
                        }
                    }
                    DBContext.SaveChanges();
                    transaction.Commit();
               
                        return Redirect("quyet-dinh/thanh-ly");
                    
             
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    TempData["shortMessage"] = true;
                    return Redirect("thanh-ly");
                    throw e; ;
                }
            }
        }

        //export file world


        [Auther(RightID = "91")]
        [Route("phong-cdvt/thanh-ly-chon/export")]
        [HttpPost]
        public ActionResult ExportQuyetDinh(string data, string documentary_code)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            string Flocation = "/doc/CDVT/QD/quyetdinhthanhly.docx";
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

                    Regex regexText = new Regex("%soquyetdinh%");
                    docText = regexText.Replace(docText, documentary_code);

                    using (StreamWriter sw = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        sw.Write(docText);
                    }
                    /////////////////////////////////////////////////////////////////////
                    JObject json = JObject.Parse(data);

                    Table table =
                    doc.MainDocumentPart.Document.Body.Elements<Table>().ElementAt(1);
                    int i = 0;
                    foreach (var item in json)
                    {
                        string equipmentId = (string)item.Value["id"];
                        JArray vattu = (JArray)item.Value.SelectToken("vattu");
                        if (vattu.Count == 0)
                        {
                            TableRow tr = new TableRow();

                            TableCell tc1 = new TableCell();
                            tc1.Append(new Paragraph(new Run(new Text((i + 1).ToString()))));
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
                        else
                            foreach (JObject jObject in vattu)
                            {
                                string supply_id = (string)jObject["supply_id"];
                                int quantity = (int)jObject["quantity"];
                                Supply s = DBContext.Supplies.Find(supply_id);
                                TableRow tr = new TableRow();

                                TableCell tc1 = new TableCell();
                                tc1.Append(new Paragraph(new Run(new Text((i + 1).ToString()))));
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
                        doc.MainDocumentPart.Document.Save();
                    }
                    // Save the file with the new name

                    string savePath = HostingEnvironment.MapPath(Flocation);
                    stream.Position = 0;
                    System.IO.File.WriteAllBytes(savePath, stream.ToArray());
                }

            }
            return Json(new { success = true, location = Flocation }, JsonRequestBehavior.AllowGet);
        }


        public class ListVatTu
        {
            public string thietbi { get; set; }
            public string[] tenvattu { get; set; }
            public string[] donvi { get; set; }
            public string[] soluong { get; set; }
            public string[] tinhtrang { get; set; }
            public string[] noilinh { get; set; }
        }

        public class ListThietBi
        {
            public string documentary_code { get; set; }
            public string lydoquyetdinh { get; set; }
            public string[] equipmentIds { get; set; }
            public string[] equipment_names { get; set; }
            public string[] department_name { get; set; }
            public string[] department_id { get; set; }
            public string[] current_Status { get; set; }
        }





    }
}