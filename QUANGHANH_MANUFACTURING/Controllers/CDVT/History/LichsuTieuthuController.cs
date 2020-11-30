using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using QUANGHANH_MANUFACTURING.Models;
using QUANGHANH_MANUFACTURING.SupportClass;

namespace QUANGHANH_MANUFACTURING.Controllers.CDVT.History
{
    public class LichsuTieuthuController : Controller
    {
        [Auther(RightID = "7,179,180,181,183,184,185,186,187,189,195,003")]
        [Route("phong-cdvt/cap-nhat-tieu-thu")]
        public ActionResult Index()
        {
            // only taken by each department.
            string department_id = Session["departID"].ToString();

            QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
            List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from Equipment where department_id = @department_id",new SqlParameter("department_id",department_id)).ToList();

            List<Supply> listSupply = db.Supplies.ToList();

            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/History/LichsuTieuthu.cshtml");
        }
    }

    public class FuelDB : FuelActivitiesConsumption
    {
        public String IDitem { get; set; }
        public string stringDate { get; set; }
        public String equipment_name { get; set; }
        public String unit { get; set; }
        public String supply_name { get; set; }
    }
}