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
            var phanxuong = this.Request.QueryString["phanxuong"];
            string ngay = this.Request.QueryString["ngay"];
            
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        string sql;
                        List<fileObjectDisplay> list = new List<fileObjectDisplay>();
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
                        ViewBag.phanxuong = phanxuong;
                        if (ngay != null)
                        {
                            ngay = ngay.Split('/')[2] + "/" + ngay.Split('/')[1] + "/" + ngay.Split('/')[0];
                        }
                        else
                        {
                            ngay = "0";
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
                        int baoCaoID = 0;
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
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
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
                        return Json(new { success = true}, JsonRequestBehavior.AllowGet);
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