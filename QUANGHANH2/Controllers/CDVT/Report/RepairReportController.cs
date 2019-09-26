using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Report
{
    public class RepairReportController : Controller
    {
        [Route("phong-cdvt/bao-cao/sua-chua")]
        public ActionResult Index(string type, string date, string month, string quarter, string year)
        {
            var noww = DateTime.Now.Date.ToString("dd/MM/yyyy");
            ViewBag.now = noww;
            int h100bag = 0, h200bag = 0, h500bag = 0, h1000bag = 0, h2000bag = 0, dotxuatbag = 0,thuongxuyenbag=0;
            Wherecondition(type, date, month, quarter, year);
            List<Content> content = new List<Content>();
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                var eqID = db.Database.SqlQuery<Eqp>("select dm.equipmentId as id from Documentary_maintain_details dm union select dr.equipmentId as id from Documentary_repair_details dr").ToList();
                foreach (var item in eqID)
                {
                    if (ViewBag.ContentBaoDuong.Count > 0 || ViewBag.ContentSuaChua.Count > 0)
                    {
                    string id = item.id;
                    int h100 = 0, h200 = 0, h500 = 0, h1000 = 0, h2000 = 0, DotXuat = 0, ThuongXuyen = 0, Thang = 0,Nam = 0 ;
                    string MaThietBi = ""; string TenThietBi = ""; string MaTSCD = "";
                    foreach (var item1 in ViewBag.ContentBaoDuong)
                    {
                        if (id.Equals(item1.MaThietBi))
                        {
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 100h")) { h100++; h100bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 200h")) { h200++; h200bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 500h")) { h500++; h500bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 1000h")){ h1000++; h1000bag++; }
                                if (item1.LoaiBaoDuong.Equals("Bảo dưỡng 2000h")){ h2000++; h2000bag++; }
                                MaThietBi = item1.MaThietBi; TenThietBi = item1.TenThietBi; MaTSCD = item1.MaTSCD;
                                Thang = item1.Thang; Nam = item1.Nam;
                        }
                    }
                    foreach(var item1 in ViewBag.ContentSuaChua)
                    {
                        if (id.Equals(item1.MaThietBi))
                        {
                                if (item1.LoaiSuaChua.Equals("sửa chữa lớn")) { DotXuat++; dotxuatbag++; }
                                if (item1.LoaiSuaChua.Equals("sửa chữa nhỏ")) { ThuongXuyen++; thuongxuyenbag++; }
                                MaThietBi = item1.MaThietBi; TenThietBi = item1.TenThietBi; MaTSCD = item1.MaTSCD;
                                Thang = item1.Thang; Nam = item1.Nam;
                            }
                    }
                        if (!String.IsNullOrEmpty(MaThietBi))
                        {
                            content.Add(new Content
                            {
                                Thang = Thang,
                                Nam = Nam,
                                MaThietBi = MaThietBi,
                                TenThietBi = TenThietBi,
                                MaTSCD = MaTSCD,
                                h100 = h100,
                                h200 = h200,
                                h500 = h500,
                                h1000 = h1000,
                                h2000 = h2000,
                                DotXuat = DotXuat,
                                ThuongXuyen = ThuongXuyen
                            });
                        }
                    }
                }
                db.SaveChanges();
            }
            //foreach(var item in content)
            //{
            //    if (String.IsNullOrEmpty(item.MaThietBi))
            //    {
            //        content.Remove(item);
            //    }
            //}
            ViewBag.all = content;
            ViewBag.h100 = h100bag;
            ViewBag.h200 = h200bag;
            ViewBag.h500 = h500bag;
            ViewBag.h1000 = h1000bag;
            ViewBag.h2000 = h2000bag;
            ViewBag.dotxuat = dotxuatbag;
            ViewBag.thuongxuyen = thuongxuyenbag;
            ViewBag.baoduong = h100bag + h200bag + h500bag + h1000bag + h2000bag;
            ViewBag.suachua = dotxuatbag + thuongxuyenbag;
                return View("/Views/CDVT/Report/RepairReport.cshtml");
        }
        private void Wherecondition(string type, string date, string month, string quarter, string year)
        {
            string queryBD = "";
            string querySC = "";
            if (type == null)
            {
                var ngay = DateTime.Now.Date;
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, "+
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and dm.finish_date_plan = '"+ngay+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, "+
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and dm.finish_date_plan = '"+ngay+"'";
            }
            if (type == "day")
            {
                var ngay = DateTime.ParseExact(date, "dd/MM/yyyy", null).ToString("yyyy-MM-dd");
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and dm.finish_date_plan = '" + ngay + "'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and dm.finish_date_plan = '" + ngay + "'";
                ViewBag.now = date;
            }
            if (type == "month")
            {
                int thang = Convert.ToInt32(month);
                int nam = Convert.ToInt32(year);
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and MONTH(dm.finish_date_plan) = '"+thang+"' and YEAR(dm.finish_date_plan) = '"+nam+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and MONTH(dm.finish_date_plan) = '" + thang + "' and YEAR(dm.finish_date_plan) = '" + nam + "'";
            }
            if (type == "quarter")
            {
                int nam = Convert.ToInt32(year);
                string quy = "";
                if (quarter == "1")
                {
                    quy = " (1,2,3) ";
                }
                if (quarter == "2")
                {
                    quy = " (4,5,6) ";
                }
                if (quarter == "3")
                {
                    quy = " (7,8,9) ";
                }
                if (quarter == "4")
                {
                    quy = " (10,11,12) ";
                }
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and MONTH(dm.finish_date_plan) in "+quy+" and YEAR(dm.finish_date_plan) = '"+nam+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and MONTH(dm.finish_date_plan) in " + quy + " and YEAR(dm.finish_date_plan) = '" + nam + "'";
            }
            if (type == "year")
            {
                int nam = Convert.ToInt32(year);
                queryBD = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.maintain_type as LoaiBaoDuong " +
                            " from Equipment e,Documentary_maintain_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and YEAR(dm.finish_date_plan) = '"+nam+"'";
                querySC = "select MONTH(dm.finish_date_plan) as Thang,YEAR(dm.finish_date_plan) as Nam,e.equipmentId as MaThietBi, " +
                            " e.equipment_name as TenThietBi,e.mark_code as MaTSCD,dm.repair_type as LoaiSuaChua " +
                            " from Equipment e,Documentary_repair_details dm, Documentary do where e.equipmentId = dm.equipmentId " +
                            " and do.documentary_code = dm.documentary_id and YEAR(dm.finish_date_plan) = '" + nam + "'";
            }

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                ViewBag.ContentBaoDuong = db.Database.SqlQuery<contentBaoDuong>(queryBD).ToList();
                ViewBag.ContentSuaChua = db.Database.SqlQuery<contentSuaChua>(querySC).ToList();
            }
        }
        [Route("phong-cdvt/bao-cao/sua-chua/excel")]
        public ActionResult Export()
        {
            return File( "~/excel/CDVT/suachua.xls", contentType: "text/plain; charset=utf-8", fileDownloadName: "suachua.xls");
        }
    }
    public class contentBaoDuong
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string MaTSCD { get; set; }
        public string LoaiBaoDuong { get; set; }
    }
    public class contentSuaChua
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string MaTSCD { get; set; }
        public string LoaiSuaChua { get; set; }
    }
    public class Content
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }
        public string MaTSCD { get; set; }
        public int h100 { get; set; }
        public int h200 { get; set; }
        public int h500 { get; set; }
        public int h1000 { get; set; }
        public int h2000 { get; set; }
        public int DotXuat { get; set; }
        public int ThuongXuyen { get; set; }
    }
    public class Eqp
    {
        public string id { get; set; }
    }
}