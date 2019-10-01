using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using static QUANGHANHCORE.Controllers.CDVT.Thietbi.HoatdongController;

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class Temp
    {
        public string abc { get; set; }
    }
    public class DashController : Controller
    {
        [Auther(RightID = "001")]
        [Route("phong-cdvt")]
        public ActionResult Index()
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<Department> listDepeartment = db.Departments.ToList<Department>();
            ViewBag.listDepeartment = listDepeartment;
            EquipThongKe etk = new EquipThongKe();
            var equipList = db.Equipments.ToList<Equipment>();
            etk.total = equipList.Count().ToString();
            var temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 3").ToList<Temp>();
            etk.total_repair = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 5").ToList<Temp>();
            etk.total_maintain = temp.Count().ToString();
            //temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = N'Đang kiểm định'").ToList<Temp>();
            //etk.total_KD = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 8").ToList<Temp>();
            etk.total_TL = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = 1").ToList<Temp>();
            etk.total_TH = temp.Count().ToString();

            etk.total_KHD = Convert.ToInt32(etk.total_repair) + Convert.ToInt32(etk.total_maintain) + Convert.ToInt32(etk.total_KD) + Convert.ToInt32(etk.total_TH) + Convert.ToInt32(etk.total_TL);
            etk.total_HD = Convert.ToInt32(etk.total) - Convert.ToInt32(etk.total_KHD);

            List<DashEquip> listRepair = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 3").ToList();
            ViewBag.listRepair = listRepair;

            List<DashEquip> listMain = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 5").ToList();
            ViewBag.listMain = listMain;

            //List<DashEquip> listKD = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = N'Đang kiểm định'").ToList();
            //ViewBag.listKD = listKD;

            List<DashEquip> listTL = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 8").ToList();
            ViewBag.listTL = listTL;

            List<DashEquip> listTH = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = 1").ToList();
            ViewBag.listTH = listTH;

            ViewBag.Thongke = etk;
            return View("/Views/CDVT/Dashboard.cshtml");
        }
    }

    public class DashEquip
    {
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
    }
}