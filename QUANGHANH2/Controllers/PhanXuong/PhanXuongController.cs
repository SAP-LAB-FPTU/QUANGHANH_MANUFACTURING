using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;using System.Web.Routing;
using System.Windows;

namespace QUANGHANHCORE.Controllers.Phanxuong.phanxuong
{
    public class PhanXuongController : Controller
    {
        [Route("phan-xuong")]
        public ActionResult Index()
        {
            //return View("/Views/Phanxuong/phanxuong.cshtml");
            var username = Session["username"];
            
            return View("/Views/Phanxuong/ChonBaoCao/ChonBaoCao.cshtml");
        }

        /// <summary>
        /// ///////////////////////////////////////////////PHAN XUONG KHAI THAC/////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        [Route("phan-xuong/chon-bao-cao")]
        public ActionResult ChonBaoCao(String phanxuong)
        {
            ViewBag.phanxuong = phanxuong;
            return View("/Views/Phanxuong/ChonBaoCao/ChonBaoCao.cshtml");
        }

        [Route("phan-xuong/nhap-bao-cao-len-phong-dk")]
        public ActionResult HangNgayKT()
        {
            var phanxuong = Session["departId"];
            string ngay = this.Request.QueryString["ngay"];
            List<BaoCaoFile> isLockList = new List<BaoCaoFile>();
            bool? ca1IsLock = false;
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
                        /////////////////////GET DATA///////////////////////////
                        if (ngay == null || ngay == "")
                        {
                            ngay = DateTime.Now.ToString("yyyy/MM/dd");
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
                        ViewBag.phanxuong = phanxuong;

                        /////////////////////GET LOCK STATUS///////////////////////////
                        sql = "select * from baocaofile\n" +
                                "where ngay = @ngay\n" +
                                "and phanxuong_id = @phanxuong";
                        isLockList = db.BaoCaoFiles.SqlQuery(sql,
                            new SqlParameter("ngay", DateTime.Parse(ngay)),
                            new SqlParameter("phanxuong", phanxuong)).ToList<BaoCaoFile>();
                        for (int i = 0; i < isLockList.Count; i++)
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

                      
                        if (ngay != null)
                        {
                            ngay = ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0];
                        }

                        db.SaveChanges();
                        ViewBag.ngay = ngay;
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                    }
                }
            }
                        return View("/Views/Phanxuong/NhapBaoCao/BaoCaoLenDK.cshtml");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("phan-xuong/upload-len-dk")]
        [HttpPost]
        public ActionResult uploadLenDK()
        {
                 HttpFileCollectionBase files = Request.Files;
                 string temp = Request["notes"];
                 string[] notes = temp.Split(','); 
                 string ngayNhap = Request["ngayNhap"];
                 
                 string phanxuong = Request["phanxuong"];
                 string ca = Request["ca"];

                 DateTime date = DateTime.Parse(ngayNhap.Split('/')[2] + "/" + ngayNhap.Split('/')[1] + "/" + ngayNhap.Split('/')[0]);
            //MessageBox.Show(ngayNhap + "/" + ca +"/"+ phanxuong);
            


            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int baoCaoID;
                        bool? isLock=false;
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
                            isLock = a[0].@lock;
                        }
                        else
                        {
                            baoCaoID = a[0].ID;
                            isLock = a[0].@lock;
                        }
                        if (isLock==false)
                        {
                            for (int i = 0; i < files.Count; i++)
                            {
                                HttpPostedFileBase file = files[i];
                                Thread.Sleep(300);
                                string fileName = file.FileName;
                                string fileNameDisplay = fileName;
                                string Fextension = Path.GetExtension(fileName);
                                var timeStamp = DateTime.Now.ToFileTime();
                                fileName = ngayNhap.Replace("/", "") + ca + phanxuong + timeStamp + Fextension;
                                string path = "/FileContainer/PhanXuongLenDK/";
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
                        return Json(new { success = false}, JsonRequestBehavior.AllowGet);
                    }
                }
            }
          
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        [Route("phan-xuong/delete-file-bao-cao")]
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

        public class fileObjectDisplay : FileBaoCao
        {
            public int ca { get; set; }
        }
    }
}