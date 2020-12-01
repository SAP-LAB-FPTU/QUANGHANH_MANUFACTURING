//using QUANGHANH2.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using System.Web.Routing;
//using System.Linq.Dynamic;
//using System.Data.Entity;
//using QUANGHANH2.SupportClass;
//using System.Globalization;
//using System.Data.SqlClient;

//namespace QUANGHANHCORE.Controllers.CDVT.Nghiemthu
//{
//    public class DanghiemthuController : Controller
//    {
//        [Auther(RightID = "26")]
//        [Route("phong-cdvt/da-nghiem-thu")]
//        public ActionResult Index()
//        {
//            return View("/Views/CDVT/Nghiemthu/Danghiemthu.cshtml");
//        }

//        [Route("phong-cdvt/da-nghiem-thu/search")]
//        [HttpPost]
//        public ActionResult Search(string document_code, string equimentid, string equimentname, string date_start, string date_end)
//        {
//            //Server Side Parameter
//            string requestID = Request["sessionId"];
//            int start = Convert.ToInt32(Request["start"]);
//            int length = Convert.ToInt32(Request["length"]);
//            //int length = 2;
//            string searchValue = Request["search[value]"];
//            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
//            string sortDirection = Request["order[0][dir]"];
//            List<MyDoc> docList = new List<MyDoc>();
//            DateTime dstart;
//            DateTime dend;
//            try
//            {
//                if (date_start == "Nhập ngày bắt đầu (từ)" || date_start == "") date_start = "01/01/1900";
//                dstart = DateTime.ParseExact(date_start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
//                if (date_end == "Nhập ngày kết thúc (đến)" || date_end == "") dend = DateTime.Now;
//                else dend = DateTime.ParseExact(date_end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
//                dend = dend.AddHours(23);
//                dend = dend.AddMinutes(59);
//            }
//            catch
//            {
//                Response.Write("Vui lòng nhập đúng ngày tháng năm");
//                return new HttpStatusCodeResult(400);
//            }

//            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
//            {
//                string username = Session["Username"].ToString();
//                Account account = new Account();
//                account = db.Accounts.Where(x => x.Username.Equals(username)).FirstOrDefault<Account>();

//                db.Configuration.LazyLoadingEnabled = false;

//                docList = (from a in db.Acceptances
//                           join b in db.Equipments on a.equipmentId equals b.equipmentId
//                           join c in db.Documentaries on a.documentary_id equals c.documentary_id
//                           where (a.equipmentStatus == 3) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equimentid)) && (b.equipment_name.Contains(equimentname))
//                           join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
//                           join e in db.Important_Documentary.Where(x => x.AccountID == account.ID) on a.documentary_id equals e.documentary_id into f
//                           from g in f.DefaultIfEmpty()
//                           select new MyDoc
//                           {
//                               documentary_id = a.documentary_id,
//                               equipmentId = b.equipmentId,
//                               equipment_name = b.equipment_name,
//                               attach_to = a.attach_to,
//                               documentary_code = c.documentary_code,
//                               documentary_type = c.documentary_type,
//                               documentary_name = d.documentary_name,
//                               du_phong = d.du_phong,
//                               di_kem = d.di_kem,
//                               can = d.can,
//                               acceptance_id = a.acceptance_id,
//                               date_created = c.date_created,
//                               acceptance_date = a.acceptance_date.Value,
//                               person_created = c.person_created,
//                               QDQT = !Equals(g, default(Important_Documentary))
//                           }).ToList().OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();
//                int totalrows = (from a in db.Acceptances
//                                 join b in db.Equipments on a.equipmentId equals b.equipmentId
//                                 join c in db.Documentaries on a.documentary_id equals c.documentary_id
//                                 where (a.equipmentStatus == 3) && (c.documentary_code.Contains(document_code))
//                                 && (a.equipmentId.Contains(equimentid)) && (b.equipment_name.Contains(equimentname))
//                                 && a.acceptance_date >= dstart && a.acceptance_date <= dend
//                                 join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
//                                 join e in db.Important_Documentary.Where(x => x.AccountID == account.ID) on a.documentary_id equals e.documentary_id into f
//                                 from g in f.DefaultIfEmpty()
//                                 select new MyDoc
//                                 {
//                                     documentary_id = a.documentary_id,
//                                     equipmentId = b.equipmentId,
//                                     equipment_name = b.equipment_name,
//                                     attach_to = a.attach_to,
//                                     documentary_code = c.documentary_code,
//                                     documentary_type = c.documentary_type,
//                                     documentary_name = d.documentary_name,
//                                     du_phong = d.du_phong,
//                                     di_kem = d.di_kem,
//                                     can = d.can,
//                                     acceptance_id = a.acceptance_id,
//                                     date_created = c.date_created,
//                                     acceptance_date = a.acceptance_date.Value,
//                                     person_created = c.person_created,
//                                     QDQT = !Equals(g, default(Important_Documentary))
//                                 }).Count();
//                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
//            }
//        }

//        public class MyDoc
//        {
//            public int documentary_id { get; set; }
//            public string documentary_code { get; set; }
//            public string documentary_name { get; set; }
//            public string equipmentId { get; set; }
//            public string equipment_name { get; set; }
//            public string attach_to { get; set; }
//            public int documentary_type { get; set; }
//            public bool du_phong { get; set; }
//            public bool di_kem { get; set; }
//            public bool can { get; set; }
//            public int acceptance_id { get; set; }
//            public bool QDQT { get; set; }
//            public DateTime date_created { get; set; }
//            public DateTime acceptance_date { get; set; }
//            public string person_created { get; set; }
//        }

//        [Route("phong-cdvt/da-nghiem-thu/quyet-dinh-quan-trong")]
//        [HttpGet]
//        public ActionResult AddQDQT()
//        {
//            QuangHanhManufacturingEntities dbContext = new QuangHanhManufacturingEntities();
//            int id = Int32.Parse(Request["documentory_id"]);
//            string username = Session["Username"].ToString();
//            Account account = new Account();
//            account = dbContext.Accounts.Where(x => x.Username.Equals(username)).FirstOrDefault<Account>();
//            Important_Documentary checkDoc = new Important_Documentary();
//            checkDoc = dbContext.Important_Documentary.Where(x => x.documentary_id == id && x.AccountID == account.ID).FirstOrDefault<Important_Documentary>();
//            if (checkDoc == null)
//            {
//                Important_Documentary important_Documentary = new Important_Documentary
//                {
//                    documentary_id = id,
//                    AccountID = account.ID
//                };
//                dbContext.Important_Documentary.Add(important_Documentary);
//                dbContext.SaveChanges();
//            }
//            else
//            {
//                dbContext.Important_Documentary.Remove(checkDoc);
//                dbContext.SaveChanges();
//            }
//            return Json(new { message = "Success" }, JsonRequestBehavior.AllowGet);
//        }
//    }
//}