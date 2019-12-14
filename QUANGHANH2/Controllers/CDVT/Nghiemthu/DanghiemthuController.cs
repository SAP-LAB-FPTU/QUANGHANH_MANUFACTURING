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
using System.Data.SqlClient;

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
            DateTime dstart;
            DateTime dend;
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
                string basesql = @"from Documentary d inner join DocumentaryType dt
on d.documentary_type = dt.documentary_type
inner join Acceptance a on a.documentary_id = d.documentary_id
inner join Equipment e on e.equipmentId = a.equipmentId
where d.documentary_code like @documentary_code and a.equipmentId like @equipmentId
and e.equipment_name like @equipment_name and a.acceptance_date between @dstart and @dend";
                docList = db.Database.SqlQuery<Documentary_Extend>(@"select d.date_created, d.person_created, d.documentary_id, a.equipmentId, e.equipment_name, a.acceptance_date, d.documentary_code, d.documentary_type, dt.documentary_name, dt.du_phong, dt.di_kem, dt.can
" + basesql + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY", 
new SqlParameter("documentary_code", "%" + document_code + "%"),
new SqlParameter("equipmentId", "%" + equimentid + "%"),
new SqlParameter("equipment_name", "%" + equimentname + "%"),
new SqlParameter("dstart", dstart),
new SqlParameter("dend", dend)).ToList();
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
                int totalrows = db.Database.SqlQuery<int>(@"select count(d.documentary_id) " + basesql,
new SqlParameter("documentary_code", document_code),
new SqlParameter("equipmentId", equimentid),
new SqlParameter("equipment_name", equimentname),
new SqlParameter("dstart", dstart),
new SqlParameter("dend", dend)).FirstOrDefault();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}