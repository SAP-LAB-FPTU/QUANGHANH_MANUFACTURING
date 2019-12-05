using OfficeOpenXml;
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using QUANGHANH2.SupportClass;

namespace QUANGHANH2.Controllers.CDVT.History
{
    public class LichsuTieuthuController : Controller
    {
        [Auther(RightID = "7,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/cap-nhat-tieu-thu")]
        public ActionResult Index()
        {
            // only taken by each department.
            string department_id = Session["departID"].ToString();

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from Equipment where department_id = @department_id",new SqlParameter("department_id",department_id)).ToList();

            List<Supply> listSupply = db.Supplies.ToList();

            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/History/LichsuTieuthu.cshtml");
        }
    }

    public class FuelDB : Fuel_activities_consumption
    {
        public String IDitem { get; set; }
        public string stringDate { get; set; }
        public String equipment_name { get; set; }
        public String unit { get; set; }
        public String supply_name { get; set; }
    }
}