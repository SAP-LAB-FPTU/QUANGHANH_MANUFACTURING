using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Microsoft.Ajax.Utilities;

namespace QUANGHANH2.Controllers.TCLD
{
    public class DepartmentController : Controller
    {
        // GET: Department
        [Auther(RightID = "175")]
        [Route("phong-tcld/quan-ly-phong-ban")]
        public ActionResult Index()
        {
            using(QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var arr_department_type = db.Departments.DistinctBy(d => d.department_type).ToList();

                ViewBag.arr_department_type = arr_department_type;
                return View("/Views/TCLD/Department/List.cshtml");
            }

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
        public ActionResult AddNewDepartment()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //var query = db.Departments.Distinct(p => p.department_type);
            }
                

            return View();

        }
        [Auther(RightID = "176")]
        [HttpPost]
        public ActionResult AddNewDepartment(string departmentJson)
        {
            dynamic dataJson = JObject.Parse(departmentJson);
            string mpb = dataJson.mpb;
            string tpb = dataJson.tpb;
            string lpb = dataJson.lpb;
            bool isInside = Convert.ToBoolean(dataJson.isInside);

            Department department = new Department { department_id = mpb, department_name = tpb, department_type = lpb, isInside = isInside };

            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var pb = db.Departments.Add(department);
                    db.SaveChanges();
                    return Json(new { success = true}, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
           

        }

        [Auther(RightID = "176")]
        [HttpPost]
        public ActionResult GetEditDepartment(string did)
        {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                db.Configuration.LazyLoadingEnabled = false;
                var pb = db.Departments.Where(d => d.department_id.Equals(did)).FirstOrDefault();
                var dataJson = Json(new { success = true, data = pb }, JsonRequestBehavior.AllowGet);
                string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);
                return dataJson;
            }
        }

        [Auther(RightID = "176")]
        [HttpPost]
        public ActionResult EditDepartment(string departmentJson, string did)
        {
            dynamic dataJson = JObject.Parse(departmentJson);
            string mpb = dataJson.mpb;
            string tpb = dataJson.tpb;
            string lpb = dataJson.lpb;
            bool isInside = Convert.ToBoolean(dataJson.isInside);

            Department department = new Department { department_id = mpb, department_name = tpb, department_type = lpb, isInside = isInside };

            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Department pb = db.Departments.Where(d => d.department_id.Equals(did)).FirstOrDefault<Department>();
                    if(pb!= null)
                    {
                        pb.department_id = mpb;
                        pb.department_name = tpb;
                        pb.department_type = lpb;
                        pb.isInside = isInside;
                        db.SaveChanges();
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}