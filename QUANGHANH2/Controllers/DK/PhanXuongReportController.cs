using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QUANGHANH2.Models;


using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;

using System.Threading;
using System.Threading.Tasks;

using System.Web.Hosting;

using System.Web.Routing;
using System.Windows;

namespace QUANGHANH2.Controllers.DK
{
    public class PhanXuongReportController : Controller
    {
        // GET: PhanXuongReport
        public ActionResult Index()
        {
            return View();
        }
        [Route("phong-dieu-khien/bao-cao-phan-xuong-phong-ban")]
        public ActionResult ReportIncident()
        {

            var phanxuong = this.Request.QueryString["phanxuong"];
            string ngay = this.Request.QueryString["ngay"];
            List<Department> listPX = new List<Department>();
            bool? ca1IsLock= false;
            bool? ca2IsLock = false;
            bool? ca3IsLock = false;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string sql;
                        List<fileObjectDisplay> list = new List<fileObjectDisplay>();
                        List<BaoCaoFile> isLockList = new List<BaoCaoFile>();
                        sql = "select * from department where department_id in\n" +
                        "('PXKT1', 'PXKT2', 'PXKT3', 'PXKT4', 'PXKT5', 'PXKT6', 'PXKT7',\n" +
                        "'PXKT8', 'PXKT9', 'PXKT10', 'PXKT11', 'PXDL3', 'PXDL5', 'PXDL7', 'PXDL8',\n" +
                        "'PXVT1', 'PXVT2', 'PXTGQLKM', 'PXST', 'PXCDM', 'PXCKSC', 'PXPV', 'PXXD', 'PXDS', 'PXLT')\n" +
                        "order by department_name";
                        listPX = db.Database.SqlQuery<Department>(sql).ToList<Department>();
                        if (phanxuong != null)
                        {
                            if (ngay == null || ngay == "")
                            {
                                sql = "select f.*,b.ca from filebaocao f,baocaofile b\n" +
                                 "where f.baocaoid = b.id and b.ngay = (SELECT CONVERT(VARCHAR(10), getdate(), 101))\n" +
                                 "and b.phanxuong_id = @phanxuong";
                                list = db.Database.SqlQuery<fileObjectDisplay>(sql, new SqlParameter("phanxuong", phanxuong)).ToList<fileObjectDisplay>();
                            }
                            else
                            {
                                ngay = ngay.Split('-')[2] + "/" + ngay.Split('-')[1] + "/" + ngay.Split('-')[0];
                                sql = "select f.*,b.ca from filebaocao f,baocaofile b\n" +
                                "where f.baocaoid = b.id and b.ngay = @ngay\n" +
                                "and b.phanxuong_id = @phanxuong";
                                list = db.Database.SqlQuery<fileObjectDisplay>(sql,
                                    new SqlParameter("phanxuong", phanxuong),
                                    new SqlParameter("ngay", DateTime.Parse(ngay))
                                    ).ToList<fileObjectDisplay>();
                            }
                            ViewBag.listFiles = list;
                            sql = "select * from baocaofile\n" +
                                "where ngay = @ngay\n" +
                                "and phanxuong_id = @phanxuong order by ca asc";
                            isLockList = db.BaoCaoFiles.SqlQuery(sql,
                                new SqlParameter("ngay", DateTime.Parse(ngay)),
                                new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                            for(int i = 0; i < isLockList.Count; i++)
                            {
                                switch (isLockList[i].ca)
                                {
                                    case 1:
                                        ca1IsLock = isLockList[i].@lock;
                                        break;
                                    case 2:
                                        ca2IsLock = isLockList[i].@lock;
                                        break;
                                    case 3:
                                        ca3IsLock = isLockList[i].@lock;
                                        break;
                                }
                            }
                            ViewBag.ca1IsLock = ca1IsLock;
                            ViewBag.ca2IsLock = ca2IsLock;
                            ViewBag.ca3IsLock = ca3IsLock;
                        }
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                    }
                }

            }

            ViewBag.phanxuong = phanxuong;
            ViewBag.listPX = listPX;
            if (ngay != null)
            {
                ngay = ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0];
            }
            else
            {
                ngay = "0";
            }
            ViewBag.ngay = ngay;
            return View("/Views/DK/PhanXuongReport.cshtml");
        }
        [Route("phong-dieu-khien/lock-nhap-bao-cao")]
        [HttpPost]
        public ActionResult LockUpload()
        {
            var phanxuong = Request["phanxuong"];
            string ngay = Request["ngay"];
            string ca = Request["ca"];
            DateTime date = DateTime.Parse(ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0]);
            List<Department> listPX = new List<Department>();
            if (phanxuong != null)
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            int baoCaoID;
                            string sql = "select * from BaoCaoFile where ngay=@ngay and ca=@ca and phanxuong_id=@phanxuong";
                            List<BaoCaoFile> a = db.BaoCaoFiles.SqlQuery(sql,
                                new SqlParameter("ngay", date),
                                new SqlParameter("ca", Int32.Parse(ca)),
                                new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                            if (a.Count == 0)
                            {
                                sql = "insert into BaoCaoFile(ngay,ca,phanxuong_id,lock) values\n" +
                                    "(@ngay,@ca,@phanxuong_id,@lock)";
                                db.Database.ExecuteSqlCommand(sql,
                                new SqlParameter("ngay", date),
                                new SqlParameter("ca", Int32.Parse(ca)),
                                new SqlParameter("phanxuong_id", phanxuong),
                                new SqlParameter("lock", false));
                                /////////////////////////////////////////////////
                                sql = "select * from BaoCaoFile where ngay=@ngay and ca=@ca and phanxuong_id=@phanxuong";
                                a = db.BaoCaoFiles.SqlQuery(sql,
                                    new SqlParameter("ngay", date),
                                    new SqlParameter("ca", Int32.Parse(ca)),
                                    new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                                baoCaoID = a[0].ID;
                            }
                            else
                            {
                                baoCaoID = a[0].ID;
                            }
                            sql = "update baocaofile set lock=1 where ID=@ID";
                            db.Database.ExecuteSqlCommand(sql,new SqlParameter("ID",baoCaoID));

                            db.SaveChanges();

                            transaction.Commit();
                            return Json(new { success = true });
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            return Json(new { success = false,message="Lỗi" });
                        }
                    }

                }
            }
            return Json(new { success = false });
        }
        [Route("phong-dieu-khien/unlock-nhap-bao-cao")]
        [HttpPost]
        public ActionResult UnLockUpload()
        {
            var phanxuong = Request["phanxuong"];
            string ngay = Request["ngay"];
            string ca = Request["ca"];
            DateTime date = DateTime.Parse(ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0]);
            List<Department> listPX = new List<Department>();
            if (phanxuong != null)
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            int baoCaoID;
                            string sql = "select * from BaoCaoFile where ngay=@ngay and ca=@ca and phanxuong_id=@phanxuong";
                            List<BaoCaoFile> a = db.BaoCaoFiles.SqlQuery(sql,
                                new SqlParameter("ngay", date),
                                new SqlParameter("ca", Int32.Parse(ca)),
                                new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                            if (a.Count == 0)
                            {
                                sql = "insert into BaoCaoFile(ngay,ca,phanxuong_id,lock) values\n" +
                                    "(@ngay,@ca,@phanxuong_id,@lock)";
                                db.Database.ExecuteSqlCommand(sql,
                                new SqlParameter("ngay", date),
                                new SqlParameter("ca", Int32.Parse(ca)),
                                new SqlParameter("phanxuong_id", phanxuong),
                                new SqlParameter("lock", false));
                                /////////////////////////////////////////////////
                                sql = "select * from BaoCaoFile where ngay=@ngay and ca=@ca and phanxuong_id=@phanxuong";
                                a = db.BaoCaoFiles.SqlQuery(sql,
                                    new SqlParameter("ngay", date),
                                    new SqlParameter("ca", Int32.Parse(ca)),
                                    new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                                baoCaoID = a[0].ID;
                            }
                            else
                            {
                                baoCaoID = a[0].ID;
                            }
                            sql = "update baocaofile set lock=0 where ID=@ID";
                            db.Database.ExecuteSqlCommand(sql,new SqlParameter("ID",baoCaoID));

                            db.SaveChanges();

                            transaction.Commit();
                            return Json(new { success = true });
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            return Json(new { success = false,message="Lỗi" });
                        }
                    }

                }
            }
            return Json(new { success = false });
        }


    }
    public class fileObjectDisplay : FileBaoCao
    {
        public int ca { get; set; }
    }
}