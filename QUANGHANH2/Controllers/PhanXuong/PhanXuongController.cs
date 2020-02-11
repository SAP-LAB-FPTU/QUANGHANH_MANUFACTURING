using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
namespace QUANGHANHCORE.Controllers.Phanxuong.phanxuong
{
    public class PhanXuongController : Controller
    {
        [Auther(RightID = "006")]
        [Route("phan-xuong")]
        public ActionResult Index()
        {
            //return View("/Views/Phanxuong/phanxuong.cshtml");
            var username = Session["username"];
            ViewBag.phanxuong = Session["departID"];
            return View("/Views/Phanxuong/ChonBaoCao/ChonBaoCao.cshtml");
        }
        [Auther(RightID = "006")]
        [Route("phan-xuong/huy-dong-thiet-bi")]
        [HttpGet]
        public ActionResult HuydongPhanxuong()
        {

            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            List<SelectListItem> listStatus = new List<SelectListItem>();
            var statsu = db.Status.ToList<Status>();
            foreach (Status item in statsu)
            {
                listStatus.Add(new SelectListItem { Text = item.statusid.ToString(), Value = item.statusname });
            }
            ViewBag.listStatus = listStatus;
            var listID = db.Equipments.Select(x => x.equipmentId).ToList();
            ViewBag.listID = listID;
            return View("/Views/Phanxuong/Huydongphanxuong.cshtml");
        }
        [Auther(RightID = "006")]
        [Route("phan-xuong/huy-dong-thiet-bi")]
        [HttpPost]
        public ActionResult Search(string equipmentId, string equipmentName, string dateStart, string dateEnd)
        {
            //Server Side Parameter
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            DateTime dtStart = Convert.ToDateTime("01/01/2000");
            DateTime dtEnd = DateTime.Today;
            if (!dateStart.Equals(""))
            {
                string[] date = dateStart.Split('/');
                string date_fix = date[2] + "/" + date[1] + "/" + date[0];
                dtStart = DateTime.ParseExact(date_fix, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            else
            {
                dateStart = dtStart.ToString("yyyy-MM-dd");
            }
            if (!dateEnd.Equals(""))
            {
                string[] date = dateEnd.Split('/');
                string date_fix = date[2] + "/" + date[1] + "/" + date[0];
                dtEnd = DateTime.ParseExact(date_fix, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
            else
            {
                dateEnd = dtEnd.ToString("yyyy-MM-dd");
            }
            string departID = Session["departID"].ToString();
            string query = "SELECT e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                "FROM [Equipment] e, Status s, Department d, Equipment_category ec " +
                "where d.department_id != 'kho' and e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid and e.usedDay between @start_time1 and @start_time2  and e.isAttach = 0 and d.department_id = @department_id AND e.equipmentId LIKE @equipmentId AND e.equipment_name LIKE @equipment_name except " +
                "select e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name " +
                "from Equipment e inner join Car c on e.equipmentId = c.equipmentId, Status s, Department d, Equipment_category ec " +
                "where d.department_id != 'kho' and e.department_id = d.department_id and e.Equipment_category_id = ec.Equipment_category_id and e.current_Status = s.statusid";
            List<EquipWithName> equiplist = DBContext.Database.SqlQuery<EquipWithName>(query + " order by " + sortColumnName + " " + sortDirection + " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY",
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_id", departID),
                new SqlParameter("start_time1", dateStart),
                new SqlParameter("start_time2", dateEnd)
                ).ToList();
            int totalrows = DBContext.Database.SqlQuery<int>(query.Replace("e.[equipmentId],[equipment_name],[supplier],[date_import],[durationOfMaintainance],[depreciation_estimate],[depreciation_present],(select MAX(ei.inspect_date) from Equipment_Inspection ei where ei.equipmentId = e.equipmentId) as 'durationOfInspection_fix',[durationOfInsurance],[usedDay],[total_operating_hours],[current_Status],[fabrication_number],[mark_code],[quality_type],[input_channel],s.statusname,d.department_name,ec.Equipment_category_name", "count(e.[equipmentId])"),
                new SqlParameter("equipmentId", '%' + equipmentId + '%'),
                new SqlParameter("equipment_name", '%' + equipmentName + '%'),
                new SqlParameter("department_id", departID),
                new SqlParameter("start_time1", dateStart),
                new SqlParameter("start_time2", dateEnd)
                ).FirstOrDefault();
            return Json(new { success = true, data = equiplist, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrows }, JsonRequestBehavior.AllowGet);
        }
        public class EquipWithName : Equipment
        {
            public Nullable<System.DateTime> durationOfInspection_fix { get; set; }
            public string statusname { get; set; }
            public string Equipment_category_name { get; set; }
            public string department_name { get; set; }
        }

        /// <summary>
        /// ///////////////////////////////////////////////PHAN XUONG KHAI THAC/////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        [Auther(RightID = "006")]
        [Route("phan-xuong/chon-bao-cao")]
        public ActionResult ChonBaoCao()
        {
            ViewBag.phanxuong = Session["departID"].ToString();
            return View("/Views/Phanxuong/ChonBaoCao/ChonBaoCao.cshtml");
        }
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
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
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
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
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195,003")]
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

        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195,003,004")]
        [HttpGet]
        [Route("phan-xuong/download-file")]
        public virtual ActionResult Download(string location, string fileName)
        {

            MemoryStream memoryStream = new MemoryStream();
            string handle = Guid.NewGuid().ToString();
            using (FileStream fileStream = new FileStream(HostingEnvironment.MapPath(location), FileMode.Open, FileAccess.Read))
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                TempData[handle] = memoryStream.ToArray();
            }
  
            if (TempData[handle] != null)
            {
                byte[] data = TempData[handle] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}