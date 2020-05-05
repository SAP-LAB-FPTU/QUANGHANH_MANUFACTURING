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

namespace QUANGHANH2.Controllers.DK.Factory
{
    public class FactoryController : Controller
    {
        // GET: Department
        //[Auther(RightID = "175")]
        [Route("phong-dk/quan-ly-phan-xuong")]
        public ActionResult Index()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var arr_department_type = db.Departments.DistinctBy(d => d.department_type).ToList();

                ViewBag.arr_department_type = arr_department_type;
                return View("/Views/DK/Factory/List.cshtml");
            }

        }

        //[Auther(RightID = "175")]
        [Route("phong-dk/quan-ly-phan-xuong")]
        [HttpPost]
        public ActionResult listDepartment()
        {
            var department_id = Request["department_id"].ToString();
            var department_name = Request["department_name"].ToString();
            var department_type = Request["department_type"].ToString();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                //List<Department> hs_nv = new List<Department>();
                var hs_nv = db.Departments.Where(x => x.department_id.Contains(department_id) && x.department_name.Contains(department_name) && x.department_type.Contains(department_type))
                    .OrderBy(sortColumnName + " " + sortDirection).Skip(start).Take(length).ToList();

                int totalrows = db.Departments.Where(x => x.department_id.Contains(department_id) && x.department_name.Contains(department_name) && x.department_type.Contains(department_type)).Count();
                var dataJson = Json(new { success = true, data = hs_nv, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);

                //string dataSerialize = new JavaScriptSerializer().Serialize(dataJson.Data);

                return dataJson;
            }

        }

        //Add Diploma
        //[Auther(RightID = "176")]
        [HttpGet]
        public ActionResult AddNewDepartment()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                //var query = db.Departments.Distinct(p => p.department_type);
            }


            return View();

        }
        //[Auther(RightID = "176")]
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
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }


        }

        //[Auther(RightID = "176")]
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

        //[Auther(RightID = "176")]
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
                    if (pb != null)
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
            catch (Exception e)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult DeleteDepartment(string department_id)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var department = db.Departments.Find(department_id);
                    db.Departments.Remove(department);
                    try
                    {
                        db.SaveChanges();
                    } catch (Exception e)
                    {
                        return Json(new { success = false, message = "Dữ liệu bạn xóa đang tồn tại ở những màn hình khác. Do vậy để xóa phân xưởng này bạn phải xóa dữ liệu tại các màn hình có liên quan tới dữ liệu trên." });
                    }
                    
                    return Json(new { success = true, message = "Xóa phân xưởng thành công." });
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra." });
            }
        }
    }
}