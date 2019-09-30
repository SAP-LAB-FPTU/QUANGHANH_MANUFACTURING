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
            var temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = '3'").ToList<Temp>();
            etk.total_repair = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = '5'").ToList<Temp>();
            etk.total_maintain = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = '1'").ToList<Temp>();
            etk.total_KD = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = '8'").ToList<Temp>();
            etk.total_TL = temp.Count().ToString();
            temp = db.Database.SqlQuery<Temp>("select distinct e.equipmentId from Equipment e where e.current_Status = '1'").ToList<Temp>();
            etk.total_TH = temp.Count().ToString();

            etk.total_KHD = Convert.ToInt32(etk.total_repair) + Convert.ToInt32(etk.total_maintain) + Convert.ToInt32(etk.total_KD) + Convert.ToInt32(etk.total_TH) + Convert.ToInt32(etk.total_TL);
            etk.total_HD = Convert.ToInt32(etk.total) - Convert.ToInt32(etk.total_KHD);

            List<DashEquip> listRepair = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = '3'").ToList();
            ViewBag.listRepair = listRepair;

            List<DashEquip> listMain = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = '5'").ToList();
            ViewBag.listMain = listMain;

            List<DashEquip> listKD = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = '1'").ToList();
            ViewBag.listKD = listKD;

            List<DashEquip> listTL = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = '8'").ToList();
            ViewBag.listTL = listTL;

            List<DashEquip> listTH = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name from Equipment e where e.current_Status = '1'").ToList();
            ViewBag.listTH = listTH;

            ViewBag.Thongke = etk;

            List<DashEquip> listSapKD = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name,e.durationOfInspection from Equipment e where DATEDIFF(DAY, GETDATE(), e.durationOfInspection) < 30").ToList();
            ViewBag.listSapKD = listSapKD;
            ViewBag.soSapKD = listSapKD.Count();

            List<DashEquip> listHetBH = db.Database.SqlQuery<DashEquip>("select e.equipmentId,e.equipment_name,e.durationOfInsurance from Equipment e where DATEDIFF(DAY, GETDATE(), e.durationOfInsurance) < 30").ToList();
            ViewBag.listHetBH = listHetBH;
            ViewBag.soHetBH = listHetBH.Count();

            //bảo dưỡng
            int bd100 = db.Database.SqlQuery<Documentary_maintain_details>("select * from Documentary_maintain_details d where d.maintain_type = N'Bảo dưỡng 100h'").ToList().Count();
            ViewBag.bd100 = bd100;

            int bd200 = db.Database.SqlQuery<Documentary_maintain_details>("select * from Documentary_maintain_details d where d.maintain_type = N'Bảo dưỡng 200h'").ToList().Count();
            ViewBag.bd200 = bd200;

            int bd500 = db.Database.SqlQuery<Documentary_maintain_details>("select * from Documentary_maintain_details d where d.maintain_type = N'Bảo dưỡng 500h'").ToList().Count();
            ViewBag.bd500 = bd500;

            int bd1000 = db.Database.SqlQuery<Documentary_maintain_details>("select * from Documentary_maintain_details d where d.maintain_type = N'Bảo dưỡng 1000h'").ToList().Count();
            ViewBag.bd1000 = bd1000;

            int bd2000 = db.Database.SqlQuery<Documentary_maintain_details>("select * from Documentary_maintain_details d where d.maintain_type = N'Bảo dưỡng 2000h'").ToList().Count();
            ViewBag.bd2000 = bd2000;

            int tt = db.Database.SqlQuery<Documentary_maintain_details>("select * from Documentary_maintain_details d where d.maintain_type = N'Tiểu tu'").ToList().Count();
            ViewBag.tt = tt;

            //sửa chữa
            int scl = db.Database.SqlQuery<Documentary_repair_details>("select * from Documentary_repair_details d where d.repair_type = N'Sửa chữa lớn'").ToList().Count();
            ViewBag.scl = scl;

            int sctx = db.Database.SqlQuery<Documentary_repair_details>("select * from Documentary_repair_details d where d.repair_type = N'Sửa chữa nhỏ'").ToList().Count();
            ViewBag.sctx = sctx;

            //thanh lý
            int dangTL = db.Database.SqlQuery<Equipment>("select * from Equipment e where e.current_Status = '15'").ToList().Count();
            ViewBag.dangTL = dangTL;

            int daTL = db.Database.SqlQuery<Equipment>("select * from Equipment e where e.current_Status = '8'").ToList().Count();
            ViewBag.daTL = daTL;

            return View("/Views/CDVT/Dashboard.cshtml");
        }
    }

    public class DashEquip
    {
        public DateTime durationOfInsurance { get; set; }
        public DateTime durationOfInspection { get; set; }
        public string equipmentId { get; set; }
        public string equipment_name { get; set; }
    }
}