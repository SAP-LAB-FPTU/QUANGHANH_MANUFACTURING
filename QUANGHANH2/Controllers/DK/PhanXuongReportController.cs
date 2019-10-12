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

            if (phanxuong != null)
            {
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
                            db.SaveChanges();

                            transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                        }
                    }

                }
            }
            ViewBag.phanxuong = phanxuong;

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
    }
    public class fileObjectDisplay : FileBaoCao
    {
        public int ca { get; set; }
    }
}