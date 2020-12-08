//using QUANGHANH2.Models;
//using QUANGHANH2.SupportClass;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using System.Web.Routing;
//using static QUANGHANHCORE.Controllers.CDVT.Thietbi.HoatdongController;
//using System.Data.SqlClient;
//using QUANGHANH2.EntityResult;

//namespace QUANGHANHCORE.Controllers.CDVT
//{
//    public class Temp
//    {
//        public string abc { get; set; }
//    }/*a*/
//    public class DashController : Controller
//    {
//        [Auther(RightID = "001")]
//        [Route("phong-cdvt")]
//        public ActionResult Index(string type, string month, string year)
//        {
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();

//            List<string> rights = (List<string>)Session["RightIDs"];
//            List<GetDashEquip_Result> listhd = new List<GetDashEquip_Result>();
//            List<GetDashEquip_Result> listkhd = new List<GetDashEquip_Result>();
//            List<GetDashEquip_Result> listcar = new List<GetDashEquip_Result>();

//            DateTime date = DateTime.Now.Date;
//            int sess = 0;
//            int hour = DateTime.Now.Hour;
//            if (hour >= 6 && hour < 14) sess = 1;
//            else if (hour >= 14 && hour < 22) sess = 2;
//            else if (hour >= 22 || hour < 6) sess = 3;
//            // GPS car unavailable
//            String date_string = date.ToString("yyyy/MM/dd");
//            var gpsunavailble = db.Database.SqlQuery<GetGPSCarAvailable_Result>(@"[Equipment].[Get_GPS_Car_Available] {0}, {1}",
//                date_string, sess).ToList();
//            ViewBag.gpsavail = gpsunavailble.Count;

//            listcar = db.Database.SqlQuery<GetDashEquip_Result>("Equipment.Get_List_Car").ToList();
//            if (rights.Contains("10"))
//            {
//                listhd = db.Database.SqlQuery<GetDashEquip_Result>("Equipment.Get_List_Car_Active").ToList();
//                listkhd = db.Database.SqlQuery<GetDashEquip_Result>("Equipment.Get_List_Car_Not_Active").ToList();
//                string query = @"Equipment.Get_Number_Of_Car_Active";
//                var tonghop = db.Database.SqlQuery<GetExportByGroup_Result>(query).ToList();
//                ViewBag.hd = tonghop;
//                //ViewBag.hd = listhd;
//                ViewBag.khd = listkhd;
//            }
//            else
//            {
//                listhd = db.Database.SqlQuery<GetDashEquip_Result>("Equipment.Get_List_Equipment_Active").ToList();
//                listkhd = db.Database.SqlQuery<GetDashEquip_Result>("Equipment.Get_List_Equipment_Not_Active").ToList();
//                string query = @"Equipment.Get_List_Export_By_Group_Equipment";
//                var tonghop = db.Database.SqlQuery<GetExportByGroup_Result>(query).ToList();
//                ViewBag.hd = tonghop;
//                //ViewBag.hd = listhd.Except(listcar);
//                ViewBag.khd = listkhd.Except(listcar);
//            }

//            GetStatisEquipment_Result etk = new GetStatisEquipment_Result();
//            var equipList = db.Equipments.ToList<Equipment>();
//            etk.total = equipList.Where(x => x.isAttach == false).Count().ToString();
//            int total_repair = 0; int total_maintain = 0; int total_TL = 0; int total_TH = 0;
//            var listKD = db.Database.SqlQuery<GetDashEquip_Result>("Equipment.Get_List_Equipment_Accreditation").ToList();
//            ViewBag.listKD = listKD;
//            ViewBag.totalKD = listKD.Count();

//            etk.total_HD = db.Equipments.Where(x => x.current_Status == 2 && x.isAttach == false).Count();
//            etk.total_KHD = int.Parse(etk.total) - etk.total_HD;

//            var listRepair = db.Equipments.Where(x => x.current_Status == 3).Select(x => new GetDashEquip_Result { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
//            ViewBag.listRepair = listRepair;

//            var listMain = db.Equipments.Where(x => x.current_Status == 5).Select(x => new GetDashEquip_Result { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
//            ViewBag.listMain = listMain;

//            var listTL = db.Equipments.Where(x => x.current_Status == 8).Select(x => new GetDashEquip_Result { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
//            ViewBag.listTL = listTL;

//            var listTH = db.Equipments.Where(x => x.current_Status == 7).Select(x => new GetDashEquip_Result { equipmentId = x.equipmentId, equipment_name = x.equipment_name }).ToList().Distinct();
//            total_repair = listRepair.Count();
//            total_maintain = listMain.Count();
//            total_TL = listTL.Count();
//            total_TH = listTH.Count();
//            ViewBag.listTH = listTH;
//            etk.total_repair = total_repair + "";
//            etk.total_maintain = total_maintain + "";
//            etk.total_TL = total_TL + "";
//            etk.total_TH = total_TH + "";
//            ViewBag.Thongke = etk;
//            var testTime = DateTime.Now.AddDays(10);
//            var hanDangKiem = db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now && x.isAttach == false).OrderBy(x => x.durationOfInspection).
//                                    Select(x => new GetListEquipNoAccreditation_Result
//                                    {
//                                        equipment_name = x.equipment_name,
//                                        equipmentId = x.equipmentId,
//                                        ngay = x.durationOfInspection.Value.Day,
//                                        thang = x.durationOfInspection.Value.Month,
//                                        nam = x.durationOfInspection.Value.Year
//                                    }).Take(10).ToList().Distinct();
//            ViewBag.kiemdinhtag = hanDangKiem.Count();
//            ViewBag.handangkiem = hanDangKiem;
//            var hanBaoduong = db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now && x.isAttach == false).OrderBy(x => x.durationOfMaintainance).
//                                    Select(x => new GetListEquipNoAccreditation_Result
//                                    {
//                                        equipment_name = x.equipment_name,
//                                        equipmentId = x.equipmentId,
//                                        ngay = x.durationOfMaintainance.Value.Day,
//                                        thang = x.durationOfMaintainance.Value.Month,
//                                        nam = x.durationOfMaintainance.Value.Year
//                                    }).Take(10).ToList().Distinct();
//            ViewBag.baoduongtag = hanBaoduong.Count();
//            ViewBag.hanbaoduong = hanBaoduong;

//            var tongcogioi = (from equip in db.Equipments
//                              join car in db.Cars
//                              on equip.equipmentId equals car.equipmentId
//                              select new GetDashEquip_Result
//                              {
//                                  equipment_name = equip.equipment_name,
//                                  equipmentId = equip.equipmentId
//                              }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.tongcogioi = tongcogioi.Count();

//            var cogioihd = (from equip in db.Equipments.Where(x => x.current_Status == 2)
//                            join car in db.Cars
//                              on equip.equipmentId equals car.equipmentId
//                            select new GetDashEquip_Result
//                            {
//                                equipment_name = equip.equipment_name,
//                                equipmentId = equip.equipmentId
//                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.cogioikhd = tongcogioi.Count() - cogioihd.Count();
//            ViewBag.cogioihd = cogioihd.Count();
//            var cogioiSC = (from equip in db.Equipments.Where(x => x.current_Status == 3)
//                            join car in db.Cars
//                                on equip.equipmentId equals car.equipmentId
//                            select new GetDashEquip_Result
//                            {
//                                equipment_name = equip.equipment_name,
//                                equipmentId = equip.equipmentId
//                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.cogioiSC = cogioiSC;
//            ViewBag.slSC = cogioiSC.Count();

//            var cogioiBD = (from equip in db.Equipments.Where(x => x.current_Status == 5)
//                            join car in db.Cars
//                              on equip.equipmentId equals car.equipmentId
//                            select new GetDashEquip_Result
//                            {
//                                equipment_name = equip.equipment_name,
//                                equipmentId = equip.equipmentId
//                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.cogioiBD = cogioiBD;
//            ViewBag.slBD = cogioiBD.Count();

//            var cogioiKD = (from equip in db.Equipments.Where(x => x.current_Status == 10)
//                            join car in db.Cars
//                              on equip.equipmentId equals car.equipmentId
//                            join Equipment_category in db.Categories
//                            on equip.Equipment_category_id equals Equipment_category.Equipment_category_id
//                            select new GetDashEquip_Result
//                            {
//                                equipment_name = equip.equipment_name,
//                                equipmentId = equip.equipmentId
//                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.cogioiKD = cogioiKD;
//            ViewBag.slKD = cogioiKD.Count();

//            var cogioiTL = (from equip in db.Equipments.Where(x => x.current_Status == 8)
//                            join car in db.Cars
//                              on equip.equipmentId equals car.equipmentId
//                            select new GetDashEquip_Result
//                            {
//                                equipment_name = equip.equipment_name,
//                                equipmentId = equip.equipmentId
//                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.cogioiTL = cogioiTL;
//            ViewBag.slTL = cogioiTL.Count();

//            var cogioiTH = (from equip in db.Equipments.Where(x => x.current_Status == 7)
//                            join car in db.Cars
//                              on equip.equipmentId equals car.equipmentId
//                            select new GetDashEquip_Result
//                            {
//                                equipment_name = equip.equipment_name,
//                                equipmentId = equip.equipmentId
//                            }).GroupBy(x => x.equipment_name + x.equipmentId).Select(x => x.FirstOrDefault());
//            ViewBag.cogioiTH = cogioiTH;
//            ViewBag.slTH = cogioiTH.Count();

//            var hanDangKiemcogioi = (from equip in db.Equipments.Where(x => x.durationOfInspection <= testTime && x.durationOfInspection >= DateTime.Now)
//                                     join car in db.Cars
//                                        on equip.equipmentId equals car.equipmentId
//                                     select new GetListEquipNoAccreditationWithDate_Result
//                                     {
//                                         equipment_name = equip.equipment_name,
//                                         equipmentId = equip.equipmentId,
//                                         day = equip.durationOfInspection.Value,
//                                         ngay = equip.durationOfInspection.Value.Day,
//                                         thang = equip.durationOfInspection.Value.Month,
//                                         nam = equip.durationOfInspection.Value.Year
//                                     }).Take(10).GroupBy(x => x.equipment_name + x.equipmentId + x.ngay + x.thang + x.nam).Select(x => x.FirstOrDefault()).OrderBy(x => x.day);
//            ViewBag.kiemdinhcogioitag = hanDangKiemcogioi.Count();
//            ViewBag.hanDangKiemcogioi = hanDangKiemcogioi;

//            var hanBaoduongcogioi = (from equip in db.Equipments.Where(x => x.durationOfMaintainance <= testTime && x.durationOfMaintainance >= DateTime.Now).OrderBy(x => x.durationOfMaintainance)
//                                     join car in db.Cars
//                                        on equip.equipmentId equals car.equipmentId
//                                     select new GetListEquipNoAccreditation_Result
//                                     {
//                                         equipment_name = equip.equipment_name,
//                                         equipmentId = equip.equipmentId,
//                                         ngay = equip.durationOfMaintainance.Value.Day,
//                                         thang = equip.durationOfMaintainance.Value.Month,
//                                         nam = equip.durationOfMaintainance.Value.Year
//                                     }).Take(10).GroupBy(x => x.equipment_name + x.equipmentId + x.ngay + x.thang + x.nam).Select(x => x.FirstOrDefault());
//            ViewBag.baoduongcogioitag = hanBaoduongcogioi.Count();
//            ViewBag.hanBaoduongcogioi = hanBaoduongcogioi;


//            Wherecondition(type, month, year);

//            if (rights.Contains("193"))
//            {
//                DateTime d = DateTime.Today;
//                ViewBag.today = month == null ? d.ToString("MM yyyy") : (month + " " + year);
//                string query = @"Camera.Get_List_Cam_Incident {0}, {1}";
//                GetDashCam_Result dc = db.Database.SqlQuery<GetDashCam_Result>(query, month == null ? d.Month.ToString() : month, "year", year == null ? d.Year.ToString() : year).FirstOrDefault();
//                dc.notdone = dc.sum - dc.done;
//                ViewBag.dc = dc;

//                string query2 = @"Camera.Get_List_Cam_Room";
//                GetDashRoom_Result dr = db.Database.SqlQuery<GetDashRoom_Result>(query2).FirstOrDefault();
//                ViewBag.dr = dr;
//            }
//            return View("/Views/CDVT/Dashboard.cshtml");
//        }

//        private void Wherecondition(string type, string month, string year)
//        {
//            string querySC = "";
//            string queryBD = "";
//            string queryTL = "";
//            string queryTDT = "";
//            string queryKD = "";
//            string queryCamera = "";
//            if (type == null)
//            {
//                int monthnull = DateTime.Now.Date.Month;
//                int yearnull = DateTime.Now.Date.Year;
//                querySC = "Equipment.Get_Equipment_Chart_Repair_Dash_Type_Null " + monthnull + ", " + yearnull;
//                queryBD = "Equipment.Get_Equipment_Chart_Maintain_Dash_Type_Null " + monthnull + ", " + yearnull;
//                queryTL = "Equipment.Get_Equipment_Chart_Liquidation_Dash_Type_Null " + monthnull + ", " + yearnull;
//                queryTDT = "Equipment.Get_Equipment_Chart_Big_Maintain_Dash_Type_Null " + monthnull + ", " + yearnull;
//                queryKD = "Equipment.Get_Equipment_Chart_Accreditation_Dash_Type_Null " + monthnull + ", " + yearnull;
//                queryCamera = "Equipment.Get_Equipment_Chart_Camera_Incident_Dash_Type_Null " + monthnull + ", " + yearnull;
//            }
//            if (type == "month")
//            {
//                int thang = Convert.ToInt32(month);
//                int nam = Convert.ToInt32(year);
//                querySC = "Equipment.Get_Equipment_Chart_Repair_Dash_Type_Month " + thang + ", " + nam;
//                queryBD = "Equipment.Get_Equipment_Chart_Maintain_Dash_Type_Month " + thang + ", " + nam;
//                queryTL = "Equipment.Get_Equipment_Chart_Liquidation_Dash_Type_Month " + thang + ", " + nam;
//                queryTDT = "Equipment.Get_Equipment_Chart_Big_Maintain_Dash_Type_Month " + thang + ", " + nam;
//                queryKD = "Equipment.Get_Equipment_Chart_Accreditation_Dash_Type_Month " + thang + ", " + nam;
//                queryCamera = "Equipment.Get_Equipment_Chart_Camera_Incident_Dash_Type_Month " + thang + ", " + nam;
//            }
//            if (type == "year")
//            {
//                int nam = Convert.ToInt32(year);
//                querySC = "Equipment.Get_Equipment_Chart_Repair_Dash_Type_Year " + nam;
//                queryBD = "Equipment.Get_Equipment_Chart_Maintain_Dash_Type_Year " + nam;
//                queryTL = "Equipment.Get_Equipment_Chart_Liquidation_Dash_Type_Year " + nam;
//                queryTDT = "Equipment.Get_Equipment_Chart_Big_Maintain_Dash_Type_Year " + nam;
//                queryKD = "Equipment.Get_Equipment_Chart_Accreditation_Dash_Type_Year " + nam;
//                queryCamera = "Equipment.Get_Equipment_Chart_Camera_Incident_Dash_Type_Year " + nam;
//            }
//            if (type == "yearss")
//            {
//                querySC = "Equipment.Get_Equipment_Chart_Repair_Dash_Type_Yearss";
//                queryBD = "Equipment.Get_Equipment_Chart_Maintain_Dash_Type_Yearss";
//                queryTL = "Equipment.Get_Equipment_Chart_Liquidation_Dash_Type_Yearss";
//                queryTDT = "Equipment.Get_Equipment_Chart_Big_Maintain_Dash_Type_Yearss";
//                queryKD = "Equipment.Get_Equipment_Chart_Accreditation_Dash_Type_Yearss";
//                queryCamera = "Equipment.Get_Equipment_Chart_Camera_Incident_Dash_Type_Yearss";
//            }
//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                ViewBag.suachua = db.Database.SqlQuery<GetChart_Result>(querySC).ToList();
//                ViewBag.baoduong = db.Database.SqlQuery<GetChart_Result>(queryBD).ToList();
//                ViewBag.thanhli = db.Database.SqlQuery<GetChart_Result>(queryTL).ToList();
//                ViewBag.trungdaitu = db.Database.SqlQuery<GetChart_Result>(queryTDT).ToList();
//                ViewBag.kiemdinh = db.Database.SqlQuery<GetChart_Result>(queryKD).ToList();
//                ViewBag.camera = db.Database.SqlQuery<GetChart_Result>(queryCamera).ToList();
//                if (type == "month" || type == null)
//                {
//                    ViewBag.type = "month";
//                }
//                if (type == "year")
//                {
//                    ViewBag.type = "year";
//                }
//                if (type == "yearss")
//                {
//                    ViewBag.type = "yearss";
//                }

//            }
//        }

//        [Route("camera/changedate")]
//        [HttpPost]
//        public ActionResult ChangeDate(string date)
//        {
//            string[] d = date.Split(' ');
//            string query = @"Camera.Get_List_Cam_Incident {0}, {1}";
//            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
//            GetDashCam_Result dc = db.Database.SqlQuery<GetDashCam_Result>(query,  d[1], d[2]).FirstOrDefault();
//            dc.notdone = dc.sum - dc.done;
//            return Json(new { success = true, message = "", dc = dc }, JsonRequestBehavior.AllowGet);
//        }

//        [Route("camera/getList")]
//        [HttpPost]
//        public ActionResult getList(string type)
//        {
//            try
//            {
//                string query = @"Camera.Get_Camera_Statistic_Room {0}";
//                QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
//                List<GetCameraStatisticRoom_Result> list = db.Database.SqlQuery<GetCameraStatisticRoom_Result>(query, type).ToList();
//                return Json(new { success = true, listDB = list }, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception)
//            {
//                return Json(new { success = false });
//            }
//        }
//    }
//}