using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.KCS
{
    [Auther(RightID = "003")]
    public class KCSController : Controller
    {
        // GET: /<controller>/
        [Route("phong-kcs/bao-cao/bao-cao-len-dk")]
        public ActionResult Index()
        {
            var phanxuong = "kcs";
            string ngay = this.Request.QueryString["ngay"];
            //List<Department> listPX = new List<Department>();
            //bool? ca1IsLock = false;
            //bool? ca2IsLock = false;
            //bool? ca3IsLock = false;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string sql;
                        List<FileBaoCao> list = new List<FileBaoCao>();
                        //List<BaoCaoFile> isLockList = new List<BaoCaoFile>();
                        //sql = "select * from department where department_id in\n" +
                        //"('PXKT1', 'PXKT2', 'PXKT3', 'PXKT4', 'PXKT5', 'PXKT6', 'PXKT7',\n" +
                        //"'PXKT8', 'PXKT9', 'PXKT10', 'PXKT11', 'PXDL3', 'PXDL5', 'PXDL7', 'PXDL8',\n" +
                        //"'PXVT1', 'PXVT2', 'PXTGQLKM', 'PXST', 'PXCDM', 'PXCKSC', 'PXPV', 'PXXD', 'PXDS', 'PXLT')\n" +
                        //"order by department_name";
                        //listPX = db.Database.SqlQuery<Department>(sql).ToList<Department>();
                        if (phanxuong != null)
                        {
                            if (ngay == null || ngay == "")
                            {
                                sql = "select f.* from filebaocao f,baocaofile b\n" +
                                 "where f.baocaoid = b.id and b.ngay = (SELECT CONVERT(VARCHAR(10), getdate(), 101))\n" +
                                 "and b.phanxuong_id = @phanxuong";
                                list = db.Database.SqlQuery<FileBaoCao>(sql, new SqlParameter("phanxuong", phanxuong)).ToList<FileBaoCao>();
                            }
                            else
                            {
                                ngay = ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0];
                                sql = "select f.* from filebaocao f,baocaofile b\n" +
                                "where f.baocaoid = b.id and b.ngay = @ngay\n" +
                                "and b.phanxuong_id = @phanxuong";
                                list = db.Database.SqlQuery<FileBaoCao>(sql,
                                    new SqlParameter("phanxuong", phanxuong),
                                    new SqlParameter("ngay", DateTime.Parse(ngay))
                                    ).ToList<FileBaoCao>();
                            }
                            bool? isLock= false;
                            ViewBag.listFiles = list;
                            List<BaoCaoFile> isLockList = new List<BaoCaoFile>();
                            if (ngay == null)
                            {
                                sql = "select * from baocaofile\n" +
                                                               "where ngay = (SELECT CONVERT(VARCHAR(10), getdate(), 101))\n" +
                                                               "and phanxuong_id = @phanxuong";
                                isLockList = db.BaoCaoFiles.SqlQuery(sql,
                                new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                            }
                            else
                            {
                                sql = "select * from baocaofile\n" +
                                                                "where ngay = @ngay\n" +
                                                                "and phanxuong_id = @phanxuong";
                                isLockList = db.BaoCaoFiles.SqlQuery(sql,
                                new SqlParameter("ngay", DateTime.Parse(ngay)),
                                new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                            }
                            for (int i = 0; i < isLockList.Count; i++)
                            {
                                isLock = isLockList[i].@lock;
                                break;
                            }
                            ViewBag.isLock = isLock;
      
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

            if (ngay != null)
            {
                ngay = ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0];
            }
            else
            {
                ngay = "0";
            }
            ViewBag.ngay = ngay;

            return View("/Views/KCS/Report/Report.cshtml");
        }


        [Route("phong-kcs/upload-file")]
        [HttpPost]
        public ActionResult uploadFile()
        {
            HttpFileCollectionBase files = Request.Files;
            string temp = Request["notes"];
            string[] notes = temp.Split(',');
            string ngayNhap = Request["ngayNhap"];

            string phanxuong ="kcs";

            DateTime date = DateTime.Parse(ngayNhap.Split('/')[2] + "/" + ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0]);


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int baoCaoID;
                        bool? isLock = false;
                        string sql = "select * from BaoCaoFile where ngay=@ngay and phanxuong_id=@phanxuong";
                        List<BaoCaoFile> a = db.BaoCaoFiles.SqlQuery(sql,
                            new SqlParameter("ngay", date),
                            new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                        if (a.Count == 0)
                        {
                            sql = "insert into BaoCaoFile(ngay,phanxuong_id,lock) values\n" +
                                "(@ngay,@phanxuong_id,@lock)";
                            db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("ngay", date),
                            new SqlParameter("phanxuong_id", phanxuong),
                            new SqlParameter("lock", false));
                            /////////////////////////////////////////////////
                            sql = "select * from BaoCaoFile where ngay=@ngay and phanxuong_id=@phanxuong";
                            a = db.BaoCaoFiles.SqlQuery(sql,
                                new SqlParameter("ngay", date),
                                new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                            baoCaoID = a[0].ID;
                            isLock = a[0].@lock;
                        }
                        else
                        {
                            baoCaoID = a[0].ID;
                            isLock = a[0].@lock;
                        }
                        if (isLock == false)
                        {
                            for (int i = 0; i < files.Count; i++)
                            {
                                HttpPostedFileBase file = files[i];
                                Thread.Sleep(300);
                                string fileName = file.FileName;
                                string fileNameDisplay = fileName;
                                string Fextension = Path.GetExtension(fileName);
                                var timeStamp = DateTime.Now.ToFileTime();
                                fileName = ngayNhap.Replace("/", "") + phanxuong + timeStamp + Fextension;
                                string path = "/FileContainer/KCS/";
                                if (!Directory.Exists(HostingEnvironment.MapPath(path)))
                                {
                                    Directory.CreateDirectory(HostingEnvironment.MapPath(path));
                                }
                                if (file.ContentLength > 0)
                                {
                                    file.SaveAs(HostingEnvironment.MapPath(path + fileName));
                                }
                                sql = "insert into FileBaoCao(baoCaoID,fileName,fileNameDisplay,nguoinhap_id,uploadTime,chuthich)\n" +
                                    "values(@ID,@filename,@fileNameDisplay,@nguoinhap,@time,@chuthich)";
                                db.Database.ExecuteSqlCommand(sql,
                                new SqlParameter("ID", baoCaoID),
                                new SqlParameter("filename", fileName),
                                new SqlParameter("fileNameDisplay", fileNameDisplay),
                                new SqlParameter("nguoinhap", 26),
                                new SqlParameter("time", DateTime.Now),
                                new SqlParameter("chuthich", notes[i]));
                            }
                            db.SaveChanges();
                            ////////////////////////////////////////////////////
                            transaction.Commit();
                            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message);
                        transaction.Rollback();
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
        }

        [Route("phong-kcs/delete-file-bao-cao")]
        [HttpPost]
        public ActionResult deleteFile()
        {
            //var phanxuong = Session["departId"];
            //string ngay = Request["ngay"];
            //string ca = Request["ca"];
            String id = Request["id"];
            if (id != null)
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            string sql = "select * from filebaocao where id=@ID";
                            string fileName = db.Database.SqlQuery<FileBaoCao>(sql, new SqlParameter("id", Int32.Parse(id))).ToList<FileBaoCao>()[0].fileName;
                            string path = HostingEnvironment.MapPath(@"/FileContainer/PhanXuongLenDK/" + fileName);
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }

                            sql = "delete from filebaocao where id=@ID";
                            db.Database.ExecuteSqlCommand(sql, new SqlParameter("ID", Int32.Parse(id)));

                            db.SaveChanges();

                            transaction.Commit();
                            return Json(new { success = true });
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            return Json(new { success = false, message = "Lỗi" });
                        }
                    }

                }
            }
            return Json(new { success = false });
        }

        public class UploadData
        {
            public string ca { get; set; }
            public string ngay { get; set; }
            public HttpFileCollectionBase file { get; set; }
        }

    }
}
