using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class suachuachonController : Controller
    {
        [Route("phong-cdvt/sua-chua-chon")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/suachuachon.cshtml");
        }

        //public ActionResult GetID(List<String> idCarSelect)
        //{
        //    return GetData(idCarSelect);
        //}

        [Route("phong-cdvt/sua-chua-chon")]
        [HttpPost]
        public ActionResult GetData()
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            var listSelected = HttpContext.Request.Cookies["SuaChuaThietBi"].Value;
            var listConvert = JsonConvert.DeserializeObject<List<String>>(listSelected);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                int count = 1;
                var result = db.Equipments.Where(s => listConvert.Contains(s.equipmentId)).ToList();
                //var result = (from e in db.Equipments where listConvert.Contains(e.equipmentId)
                //join d in db.Documentary_repair_details on e.equipmentId equals d.equipmentId
                //             select new
                //             {
                //                 equipmentId = e.equipmentId,
                //                 equipment_name = e.equipment_name,
                //                 department_id = e.department_id,
                //                 current_Status = e.current_Status,
                //                 repair_type = d.repair_type,
                //                 repair_reason = d.repair_reason,
                //                 finish_date_plan = d.finish_date_plan
                //             }).ToList().Select(s => new NewDoc
                //             {

                //                 equipmentId = s.equipmentId,
                //                 equipment_name = s.equipment_name,
                //                 department_id = s.department_id,
                //                 current_Status = s.current_Status,
                //                 repair_type = s.repair_type,
                //                 repair_reason = s.repair_reason,
                //                 finish_date_plan = s.finish_date_plan
                //             }).ToList();

                // var js = Json(new { success = true, data = result });
                //ViewBag.hihi = new JavaScriptSerializer().Serialize(js.Data);

                //aaaaaaaaaa
                //foreach (var el in result)
                //{
                //    el.order_number = count++;

                //}
                int totalrows = result.Count;
                int totalrowsafterfiltering = result.Count;
                if (sortColumnName != null && sortDirection != null)
                {
                    //sorting
                    result = result.OrderBy(sortColumnName + " " + sortDirection).ToList<Equipment>();
                }
                //paging
                if (start != null && length != null)
                {
                    result = result.Skip(start).Take(length).ToList<Equipment>();
                }
                //return js;
              return  Json(new { success = true, data = result, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpGet]
        public ActionResult AddOrEdit(string id = "")
        {
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_id });

                }
                //
                var categories = db.Equipment_category.ToList<Equipment_category>();
                foreach (Equipment_category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.Equipment_category_id, Value = items.Equipment_category_id });

                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
                if (id == "" || id == null)
                {
                    return View(new Equipment());
                }
                else
                    return View(db.Equipments.Where(x => x.equipmentId == id).FirstOrDefault<Equipment>());
            }
        }






        public class NewDoc : Equipment
        {
            public string equipmentId { get; set; }
            public string equipment_name { get; set; }
            public string supplier { get; set; }
            public System.DateTime date_import { get; set; }
            public double depreciation_estimate { get; set; }
            public double depreciation_present { get; set; }
            public System.DateTime durationOfInspection { get; set; }
            public System.DateTime durationOfInsurance { get; set; }
            public System.DateTime usedDay { get; set; }
            public System.DateTime nearest_Maintenance_Day { get; set; }
            public int total_operating_hours { get; set; }
            public string current_Status { get; set; }
            public Nullable<double> fabrication_number { get; set; }
            public string mark_code { get; set; }
            public string quality_type { get; set; }
            public string input_channel { get; set; }
            public string Equipment_category_id { get; set; }
            public string department_id { get; set; }
            public string equipment_repair_status { get; set; }
            public string repair_type { get; set; }
            public string repair_reason { get; set; }
            public System.DateTime finish_date_plan { get; set; }
            public string documentary_id { get; set; }
            public virtual Documentary Documentary { get; set; }
            public virtual Equipment Equipment { get; set; }
            public int order_number { get; set; }
        }
    }
}