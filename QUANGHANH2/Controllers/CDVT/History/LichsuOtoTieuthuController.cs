using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using QUANGHANH2.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Globalization;
using QUANGHANH2.SupportClass;

namespace QUANGHANHCORE.Controllers.CDVT.History
{
    public class LichsuOtoTieuthuController : Controller
    {
        [Auther(RightID = "13,179,180,181,182,183,184,185,186,187,188,189")]
        [Route("phong-cdvt/oto/cap-nhat-tieu-thu")]
        [HttpGet]
        public ActionResult Index()
        {
            // only taken by each department.
            string department_id = Session["departID"].ToString();

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Supply> listSupply = db.Supplies.ToList();
            //List <Supply> listSupply = db.Supplies.Where(x => x.unit == "L" || x.unit == "kWh").ToList();

            List<FuelDB> listEQ = db.Database.SqlQuery<FuelDB>("select equipmentId , equipment_name from " +
               " (select distinct e.equipmentId, e.equipment_name ,e.department_id from Equipment e inner join Equipment_category_attribute ea " +
               "  on ea.Equipment_category_id = e.Equipment_category_id where " +
               " ea.Equipment_category_attribute_name = N'Số khung' or ea.Equipment_category_attribute_name = N'Số máy') as t " +
               " where department_id = @department_id", new SqlParameter("department_id", department_id)
            ).ToList();
            ViewBag.listSupply = listSupply;
            ViewBag.listEQ = listEQ;
            return View("/Views/CDVT/History/LichsuOtoTieuthu.cshtml");
        }
    }
}