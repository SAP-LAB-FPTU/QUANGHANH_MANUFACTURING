using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return View("/Views/Phanxuong/NhapBaoCao/BaoCaoLenDK.cshtml");
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("phan-xuong/upload-len-dk")]
        [HttpPost]
        public ActionResult uploadLenDK()
        {
                HttpFileCollectionBase files = Request.Files;
                 string ngayNhap = Request["ngayNhap"];
                 string phanxuong = Request["phanxuong"];
                 string ca = Request["ca"];
                 //MessageBox.Show(ngayNhap + "/" + ca +"/"+ phanxuong);

                for(int i=0;i<files.Count;i++)
                {
                    HttpPostedFileBase file = files[i];
                    string fileName = file.FileName;
                    string path = "/FileContainer/PhanXuongLenDK/";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (file.ContentLength > 0)
                    {
                        file.SaveAs(HostingEnvironment.MapPath(path + fileName));
                        //FileInfo process_file = new FileInfo(HostingEnvironment.MapPath("/excel/KCS/FileUploadContainer/temp.xlsx"));
                    }
                }
           
            return Json(new { success = true});
        }
        public class UploadData
        {
            public string ca { get; set; }
            public string ngay { get; set; }
            public HttpFileCollectionBase file { get; set; }
        }
    }
}