using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using System.Globalization;

namespace QUANGHANHCORE.Controllers.CDVT.Nghiemthu
{
    public class DanghiemthuController : Controller
    {
        [Auther(RightID = "26")]
        [Route("phong-cdvt/da-nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Nghiemthu/Danghiemthu.cshtml");
        }

        [Route("phong-cdvt/da-nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string document_code, string equimentid, string equimentname, string date_start, string date_end)
        {
            //Server Side Parameter
            string requestID = Request["sessionId"];
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            //int length = 2;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend> docList = new List<Documentary_Extend>();

            //DateTime dstart = DateTime.ParseExact(date_start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dend = DateTime.ParseExact(date_end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //
            //if (date_start == "") date_start = "01/01/1900";
            DateTime dstart;
            DateTime dend;
            //if (date_end == "") dend = DateTime.Now;
            //else dend = DateTime.ParseExact(date_end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //dend = dend.AddHours(23);
            //dend = dend.AddMinutes(59);
            try
            {
                if (date_start == "Nhập ngày bắt đầu (từ)" || date_start == "") date_start = "01/01/1900";
                dstart = DateTime.ParseExact(date_start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (date_end == "Nhập ngày kết thúc (đến)" || date_end == "") dend = DateTime.Now;
                else dend = DateTime.ParseExact(date_end, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dend = dend.AddHours(23);
                dend = dend.AddMinutes(59);
            }
            catch
            {
                Response.Write("Vui lòng nhập đúng ngày tháng năm");
                return new HttpStatusCodeResult(400);
            }

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                docList = (from a in db.Acceptances

                           join b in db.Equipments on a.equipmentId equals b.equipmentId
                           join c in db.Documentaries on a.documentary_id equals c.documentary_id
                           where (a.equipmentStatus == 3) && (c.documentary_code.Contains(document_code)) && (a.equipmentId.Contains(equimentid) && b.equipment_name.Contains(equimentname) && (a.acceptance_date >= dstart && a.acceptance_date <= dend))
                           join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                           select new
                           {
                               documentary_id = a.documentary_id,
                               equipmentId = b.equipmentId,
                               equipment_name = b.equipment_name,
                               acceptance_date = a.acceptance_date,
                               documentary_code = c.documentary_code,
                               documentary_type = c.documentary_type,
                               documentary_name = d.documentary_name,
                               du_phong = d.du_phong,
                               di_kem = d.di_kem,
                               can = d.can
                           }).ToList().Select(p => new Documentary_Extend
                           {
                               documentary_id = p.documentary_id,
                               equipmentId = p.equipmentId,
                               equipment_name = p.equipment_name,
                               acceptance_date = p.acceptance_date,
                               documentary_code = p.documentary_code,
                               documentary_type = p.documentary_type,
                               documentary_name = p.documentary_name,
                               du_phong = p.du_phong,
                               di_kem = p.di_kem,
                               can = p.can
                           }).ToList();
                foreach (Documentary_Extend item in docList)
                {
                    item.temp = item.documentary_id + "^" + item.documentary_code;
                }
                foreach (Documentary_Extend items in docList)
                {
                    items.linkIdCode = new LinkIdCode2();
                    switch (items.documentary_type)
                    {
                        case 1:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 2:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 3:
                            items.linkIdCode.link = "vat-tu-kem-theo";
                            break;
                        case 4:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 5:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 6:
                            items.linkIdCode.link = "vat-tu";
                            break;
                    }
                    items.linkIdCode.code = items.equipmentId;
                    items.linkIdCode.id = items.equipmentId;
                    items.linkIdCode.doc = items.documentary_id;
                }
                //docList = db.Documentaries.ToList<Documentary>();
                int totalrows = docList.Count;
                int totalrowsafterfiltering = docList.Count;
                //sorting
                docList = docList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Extend>();
                //paging
                docList = docList.Skip(start).Take(length).ToList<Documentary_Extend>();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("phong-cdvt/da-nghiem-thu/quyet-dinh-quan-trong")]
        [HttpGet]
        public ActionResult AddQDQT(string docID)
        {
            QUANGHANHABCEntities dbContext = new QUANGHANHABCEntities();
            int id = Int32.Parse(Request["documentory_id"]);
            string username = Session["Username"].ToString();
            Account account = new Account();
            account = dbContext.Accounts.Where(x => x.Username.Equals(username)).FirstOrDefault<Account>();
            Important_Documentary checkDoc = new Important_Documentary();
            checkDoc = dbContext.Important_Documentary.Where(x => x.documentary_id == id && x.AccountID == account.ID).FirstOrDefault<Important_Documentary>();
            if(checkDoc == null)
            {
                Important_Documentary important_Documentary = new Important_Documentary();
                important_Documentary.documentary_id = id;
                important_Documentary.AccountID = account.ID;
                dbContext.Important_Documentary.Add(important_Documentary);
                dbContext.SaveChanges();
            }
            else
            {
                dbContext.Important_Documentary.Remove(checkDoc);
                dbContext.SaveChanges();
            }
            return Json(new { message = "Success" }, JsonRequestBehavior.AllowGet);
        }
    }
}