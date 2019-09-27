using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.TCLD
{
    public class RecruitmentController : Controller
    {
        // GET: Recruitment
        [Route("phong-tcld/quan-ly-nhan-vien/tuyen-dung-nhan-vien")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/Recruitment/AddRecruitment1.cshtml");
        }
      
         [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> listDepeartment = new List<SelectListItem>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var departments = db.Departments.ToList<Department>();
                foreach (Department items in departments)
                {
                    listDepeartment.Add(new SelectListItem { Text = items.department_id, Value = items.department_name });

                }
                //
                var categories = db.Equipment_category.ToList<Equipment_category>();
                foreach (Equipment_category items in categories)
                {
                    listCategory.Add(new SelectListItem { Text = items.Equipment_category_id, Value = items.Equipment_category_name });

                }
                //listForSelect.Add(new SelectListItem { Text = "Your text", Value = "TRAI" });
                ViewBag.listDepeartment = listDepeartment;
                ViewBag.listCategory = listCategory;
            }
            return View(new Equipment());
        }
        [HttpPost]
        public ActionResult Add(Equipment emp, string import, string duraInspec, string duraInsura, string used, string nearmain, string[] id, string[] name, int[] value, string[] unit)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
               
                db.SaveChanges();
                return RedirectToAction("GetData");
            }
        }
    }
}