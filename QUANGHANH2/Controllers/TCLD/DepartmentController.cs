using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.TCLD
{
    public class DepartmentController : Controller
    {
        // GET: Department
        [Auther(RightID = "175")]
        [Route("phong-tcld/quan-ly-phong-ban")]
        public ActionResult Index()
        {
            return View("/Views/TCLD/Department/List.cshtml");
        }

        [Auther(RightID = "175")]
        [Route("phong-tcld/quan-ly-phong-ban")]
        [HttpPost]
        public ActionResult listDepartment()
        {

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                List<Department> hs_nv = new List<Department>();
                hs_nv = (from department in db.Departments
                         select new
                         {
                             maPB = department.department_id,
                             ten = department.department_name,
                             loai = department.department_type
                         }).ToList().Select(p => new Department
                         {
                             department_id = p.maPB,
                             department_name = p.ten,
                             department_type = p.loai

                         }).ToList();

                int totalrows = hs_nv.Count;
                int totalrowsafterfiltering = hs_nv.Count;
                hs_nv = hs_nv.OrderBy(sortColumnName + " " + sortDirection).ToList<Department>();
                //paging
                hs_nv = hs_nv.Skip(start).Take(length).ToList<Department>();
                var dataJson = Json(new { success = true, data = hs_nv, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }

        }

        [Auther(RightID = "175")]
        [HttpPost]
        public ActionResult searchDepartment(string DepartmentSearchList)
        {


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                List<Department> hs_nv = new List<Department>();
                string[] idsArray = DepartmentSearchList.Split(',').ToArray();
                var manv = idsArray[0];
                var tennv = idsArray[1];
                var nguoigiaohoso = idsArray[2];
                if (manv != null || tennv != null && nguoigiaohoso != null)
                {
                    hs_nv = (from de in db.Departments
                             where  ((de.department_id + " ").Contains(manv))
                             && ((de.department_name + " ").Contains(tennv))
                             && ((de.department_type + " ").Contains(nguoigiaohoso))
                             select new
                             {
                                 maPB = de.department_id,
                                 ten = de.department_name,
                                 loai = de.department_type
                             }).ToList().Select(p => new Department
                             {
                                 department_id = p.maPB,
                                 department_name = p.ten,
                                 department_type = p.loai

                             }).ToList();


                    int totalrows = hs_nv.Count;
                    int totalrowsafterfiltering = hs_nv.Count;
                    hs_nv = hs_nv.OrderBy(sortColumnName + " " + sortDirection).ToList<Department>();
                    //paging
                    hs_nv = hs_nv.Skip(start).Take(length).ToList<Department>();
                    var dataJson = Json(new { success = true, data = hs_nv, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                    string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                    return dataJson;
                }
            }
            return RedirectToAction("listDepartment");
        }

        //Add Diploma
        [Auther(RightID = "176")]
        [HttpGet]
        public ActionResult AddDepartment()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //var query = db.Departments.Distinct(p => p.department_type);
            }
                

            return View();

        }
        [Auther(RightID = "176")]
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                if (department != null)
                {

                    db.Departments.Add(department);
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }


        }
    }
}