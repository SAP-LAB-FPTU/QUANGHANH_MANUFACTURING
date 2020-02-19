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
using Newtonsoft.Json;
using System.Transactions;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using QUANGHANH2.Repositories.Intefaces;
using QUANGHANH2.Utils;
using QUANGHANH2.ModelViews;

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
                        bool? isLock = false;
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
                        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
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

        /// <summary>
        /// NSLD va Diem Luong
        /// </summary>
        /// <returns></returns>
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [Route("phan-xuong/nang-suat-lao-dong")]
        public ActionResult NSLD()
        {
            return View("/Views/PX/PXKT/InputNSLD.cshtml");
        }

        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [HttpPost]
        [Route("phan-xuong/nang-suat-lao-dong/lay-du-lieu")]
        /////////////////////GET DATA///////////////////////
        public ActionResult getEffortData()
        {
            string date = Request["date"];
            string shift = Request["shift"];
            string departmentID = (String)Session["departID"];
            string convert_date;
            int convert_shift = 0;
            try
            {
                if (date.Equals("") || shift.Equals(""))
                {
                    convert_date = DateTime.Now.Date.ToString("yyyy/MM/dd");
                    var curr_hour = DateTime.Now.Hour;
                    if (curr_hour >= 8 && curr_hour < 16)
                    {
                        //Shift 1
                        convert_shift = 1;
                    }
                    if (16 <= curr_hour && curr_hour < 23)
                    {
                        //shift 2
                        convert_shift = 2;
                    }
                    else if (0 <= curr_hour && curr_hour < 16)
                    {
                        convert_shift = 3;
                    }
                }
                else
                {
                    convert_date = Convert.ToDateTime(date).Date.ToString("yyyy/MM/dd");
                    convert_shift = Convert.ToInt32(shift);
                }

                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    //get list_nsld
                    var mysql = @"select 
                                (case when hd.NgayDiemDanh is NULL then '0-0-0' else hd.NgayDiemDanh end) as 'NgayDiemDanh', 
                                (case when hd.Ca is NULL then '0' else hd.Ca end) as 'Ca', 
                                (case when dd.MaNV is NULL then '0' else dd.MaNV end) as 'MaNV', 
                                (case when nv.Ten is NULL then '' else nv.Ten end) as 'Ten', 
                                (case when dd.DiemLuong is NULL then 0 else dd.DiemLuong end) as 'DiemLuong' 
                                from 
                                (select HeaderID, NgayDiemDanh, Ca, MaPhongBan from Header_DiemDanh_NangSuat_LaoDong where NgayDiemDanh = @date 
                                                    and Ca = @shift 
                                                    and  MaPhongBan = @departmentID) as hd 
                                join (select * from DiemDanh_NangSuatLaoDong where DiLam = 1) as dd on hd.HeaderID = dd.HeaderID
                                join NhanVien nv on nv.MaNV = dd.MaNV";
                    List<NangSuatLaoDong_TungCongNhan> list_nsld = db.Database.SqlQuery<NangSuatLaoDong_TungCongNhan>(mysql,
                        new SqlParameter("date", convert_date),
                        new SqlParameter("shift", convert_shift),
                        new SqlParameter("departmentID", departmentID)).ToList();

                    //get list_sum_effort
                    var mysql_sum = @"select TotalEffort,ThanThucHien, MetLoThucHien, XenThucHien from Header_DiemDanh_NangSuat_LaoDong 
                                    where NgayDiemDanh = @date and Ca = @shift and MaPhongBan = @departmentID";
                    List<Sum_DiemLuong_Than_MetLo_Xen> list_sum = db.Database.SqlQuery<Sum_DiemLuong_Than_MetLo_Xen>(mysql_sum,
                        new SqlParameter("date", convert_date),
                        new SqlParameter("shift", convert_shift),
                        new SqlParameter("departmentID", departmentID)).ToList();

                    return Json(new { list_nsld = list_nsld, list_sum = list_sum, date = Convert.ToDateTime(convert_date).Date.ToString("dd/MM/yyyy"), shift = convert_shift });
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [Route("phan-xuong/nang-suat-lao-dong/luu-du-lieu")]
        [HttpPost]
        public ActionResult saveNSLD()
        {
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                DbContextTransaction transaction = db.Database.BeginTransaction();
                try
                {
                    //header params
                    var departmentID = Session["departID"].ToString();
                    var date = DateTime.Parse(Request["date"]).Date;
                    var shift = Convert.ToInt32(Request["shift"]);

                    //list data need to save
                    var arrES = JArray.Parse(Request["arrES"]);
                    var arrTB = JArray.Parse(Request["arrTB"]);


                    Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Where(x => x.NgayDiemDanh == date && x.Ca == shift && x.MaPhongBan.Equals(departmentID)).FirstOrDefault();
                    if (header != null)
                    {
                        //save to Header_DiemDanh_NangSuat_LaoDong
                        header.TotalEffort = Convert.ToDouble(arrES[0]["TongDiemLuong"]);
                        header.ThanThucHien = Convert.ToDouble(arrES[0]["TongThan"]);
                        header.MetLoThucHien = Convert.ToDouble(arrES[0]["TongMetLo"]);
                        header.XenThucHien = Convert.ToDouble(arrES[0]["TongXen"]);

                        //save to DiemDanh_NangSuat_LaoDong
                        var headerID = Convert.ToInt32(header.HeaderID);
                        foreach (var row in arrTB)
                        {
                            string nhanvien_id = (String)row["mathe"];
                            double diemluong = Convert.ToDouble(row["diemluong"]);
                            DiemDanh_NangSuatLaoDong effort = db.DiemDanh_NangSuatLaoDong.Find(nhanvien_id, headerID);
                            effort.DiemLuong = Convert.ToDouble(diemluong);
                            db.SaveChanges();
                        }
                    }
                    transaction.Commit();
                    return Json(new { success = true, title = "Thành công", message = "Cập nhật công việc thành công." });
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return Json(new { success = false, title = "Có lỗi", message = "Cập nhật không thành công." });
                }
            }
        }
        //public ActionResult getDataNSLD()
        //{
        //    try
        //    {
        //        string caSearch = Request["caSearch"];
        //        string ngaySearch = Request["ngaySearch"];
        //        string Donvi = Request["phongbanSearch"];
        //        ngaySearch = ngaySearch.Split('"')[1];
        //        int calamviec = Int32.Parse(caSearch.Split('"')[1]);
        //        ngaySearch = ngaySearch.Split('/')[1] + "/" + ngaySearch.Split('/')[0] + "/" + ngaySearch.Split('/')[2];
        //        DateTime date = DateTime.Parse(ngaySearch);
        //        List<BaoCaoTheoCa> customNSLDs = new List<BaoCaoTheoCa>();

        //        Donvi = Donvi.Split('"')[1];
        //        QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        //        Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.MaPhongBan == Donvi && a.Ca == calamviec && a.NgayDiemDanh == date).First();
        //        List<DiemDanh_NangSuatLaoDong> list = db.DiemDanh_NangSuatLaoDong
        //            .Where(a => a.DiLam == true)
        //            .Where(a => a.HeaderID == header.HeaderID)
        //            .ToList();
        //        customNSLDs = new List<BaoCaoTheoCa>();
        //        BaoCaoTheoCa cus;
        //        int num = 1;
        //        foreach (var i in list)
        //        {
        //            string MaPhongBan = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.HeaderID == i.HeaderID).First().MaPhongBan;
        //            cus = new BaoCaoTheoCa
        //            {
        //                STT = num,
        //                Name = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().Ten,
        //                BacTho = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().BacLuong,
        //                ChucDanh = db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec == null ? "" : db.NhanViens.Where(a => a.MaNV == i.MaNV).First().CongViec.TenCongViec,
        //                //DuBaoNguyCo = i.DuBaoNguyCo,
        //                //HeSoChiaLuong = i.HeSoChiaLuong.ToString(),
        //                LuongSauDuyet = i.DiemLuong.ToString(),
        //                LuongTruocDuyet = i.DiemLuong.ToString(),
        //                NoiDungCongViec = db.Departments.Where(a => a.department_id == MaPhongBan).First().department_name,
        //                SoThe = i.MaNV
        //                //YeuCauBPKTAT = i.GiaiPhapNguyCo
        //            };
        //            customNSLDs.Add(cus);
        //            num++;
        //        }
        //        return Json(new
        //        {
        //            success = true,
        //            customNSLDs = customNSLDs,
        //            total_point = header.TotalEffort,
        //            than = header.ThanThucHien,
        //            lo = header.MetLoThucHien,
        //            xen = header.XenThucHien,
        //            note = header.GhiChu == null ? "" : header.GhiChu
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { success = false });
        //    }
        //}
        //[Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        //[Route("phan-xuong/nang-suat-lao-dong-update")]
        //public ActionResult UpdateNSLD(string stringjson)
        //{
        //    using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
        //    {
        //        using (DbContextTransaction transaction = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                JObject json = JObject.Parse(stringjson);
        //                int calamviec = (int)json["ca"];
        //                string Donvi = (string)json["phongban"];
        //                string ngaySearch = (string)json["ngay"];
        //                ngaySearch = ngaySearch.Split('/')[1] + "/" + ngaySearch.Split('/')[0] + "/" + ngaySearch.Split('/')[2];
        //                DateTime date = DateTime.Parse(ngaySearch);
        //                Header_DiemDanh_NangSuat_LaoDong header = db.Header_DiemDanh_NangSuat_LaoDong.Where(a => a.MaPhongBan.Equals(Donvi) && a.Ca == calamviec && a.NgayDiemDanh == date).FirstOrDefault();
        //                if (header != null)
        //                {
        //                    header.TotalEffort = (double)json["total_point"];
        //                    header.GhiChu = (string)json["note"];
        //                    header.ThanThucHien = (double)json["than"];
        //                    header.MetLoThucHien = (double)json["lo"];
        //                    header.XenThucHien = (double)json["xen"];
        //                    JArray temp = (JArray)json.SelectToken("list");
        //                    foreach (JObject item in temp)
        //                    {
        //                        DiemDanh_NangSuatLaoDong NSLD = db.DiemDanh_NangSuatLaoDong.Find((string)item["MaNhanVien"], (int)header.HeaderID);
        //                        //NSLD.HeSoChiaLuong = (double?)item["HeSoChiaLuong"];
        //                        NSLD.DiemLuong = (double?)item["Luong"];
        //                        //NSLD.DuBaoNguyCo = (string)item["DuBaoNguyCo"];
        //                        //NSLD.GiaiPhapNguyCo = (string)item["YeuCauBPKTAT"];
        //                        db.SaveChanges();
        //                    }
        //                    transaction.Commit();
        //                    return Json(new { success = true, message = "Cập nhật thành công" });
        //                }
        //                else
        //                {
        //                    return Json(new { success = false, message = "Cập nhật thất bại." });
        //                }


        //            }
        //            catch (Exception e)
        //            {
        //                transaction.Rollback();
        //                return Json(new { success = false, message = "Cập nhật thất bại" });
        //            }
        //        }

        //    }

        //}



        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [Route("phan-xuong/diem-danh")]
        public ActionResult takeAttendanceView()
        {
            try
            {

            }
            catch (Exception e)
            {

            }

            return View("/Views/PX/PXKT/takeAttendance.cshtml");
        }

        public dynamic getAll(int session, string departmentID, DateTime date, string MaNV, string TenNV)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var query = @"select b.DiLam as [status], b.HeaderID as headerID,nv.MaNV,nv.Ten as tenNV,b.ThoiGianThucTeDiemDanh as timeAttendance,b.reason,[b].[description]
                                from (select dd.DiLam,header.HeaderID , dd.MaNV ,dd.ThoiGianThucTeDiemDanh,dd.LyDoVangMat as reason,dd.GhiChu as [description]
                                from (select * from Header_DiemDanh_NangSuat_LaoDong
                                where NgayDiemDanh = @date and Ca = @session and MaPhongBan = @departmentID) as header
                                left join DiemDanh_NangSuatLaoDong as dd on header.HeaderID = dd.HeaderID) as b
                                right join(select * from NhanVien where MaPhongBan = @departmentID and MaNV like @manv and Ten like @tennv ) as nv on b.MaNV = nv.MaNV";
                    var listAttended = db.Database.SqlQuery<attendanceEntity>(query,
                        new SqlParameter("date", date),
                        new SqlParameter("session", session),
                        new SqlParameter("departmentID", departmentID),
                        new SqlParameter("manv", '%' + MaNV + '%'),
                        new SqlParameter("tennv", '%' + TenNV + '%')).ToList();


                    return listAttended;
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public SoLuongDiLam_Vang getAttendance_NotAttendance(int session, string departmentID, DateTime date)
        {
            try
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    //take sum attendance and not attendance
                    var mysql = @"select
                                (case when TongDilam is NULL then 0 else TongDilam end ) as 'TongDiLam',
								(case when DiLam_CNKT is NULL  then 0 else DiLam_CNKT end) as 'DiLam_CNKT',
								(case when DiLam_CNCD is NULL then 0 else DiLam_CNCD end) as 'DiLam_CNCD',
								(case when DiLam_CBQL is NULL then 0 else DiLam_CBQL end) as 'DiLam_CBQL',
								(case when TongNghi is NULL then 0 else TongNghi end) as 'TongNghi',
								(case when Om is NULL then 0 else Om end) as 'Om',
								(case when Phep is NULL then 0 else Phep end) as 'Phep',
								(case when VoLyDo is NULL then 0 else VoLyDo end) as 'VoLyDo',
								(case when Khac is NULL then 0 else Khac end) as 'Khac',
								(case when TaiNanLaoDong is NULL then 0 else TaiNanLaoDong end) as 'TaiNanLaoDong',
								(case when OmDai is NULL then 0 else OmDai end) as 'OmDai',
								(case when ThaiSan is NULL then 0 else ThaiSan end) as 'ThaiSan',
								(case when TamHoanLaoDong is NULL then 0 else TamHoanLaoDong end) as 'TamHoanLaoDong',
								(case when VoLyDoDai is NULL then 0 else VoLyDoDai end) as 'VoLyDoDai'
                                from
                                (select
                                (select count(MaNV) from Header_DiemDanh_NangSuat_LaoDong a join DiemDanh_NangSuatLaoDong b on a.HeaderID = b.HeaderID where MaPhongBan = @departmentID and NgayDiemDanh = @date and Ca = @session and DiLam = 1) as 'TongDilam',
                                sum(case when (d.DiLam = 1 and ncv.LoaiNhomCongViec = N'CNKT') then 1 else 0 end) as 'DiLam_CNKT',
                                sum(case when (d.DiLam = 1 and ncv.LoaiNhomCongViec = N'CNCĐ') then 1 else 0 end) as 'DiLam_CNCD',
                                sum(case when (d.DiLam = 1 and ncv.LoaiNhomCongViec = N'CBQL') then 1 else 0 end) as 'DiLam_CBQL' 
                                from (select HeaderID from Header_DiemDanh_NangSuat_LaoDong where MaPhongBan = @departmentID and NgayDiemDanh = @date and Ca = @session) as hd 
			                                left join DiemDanh_NangSuatLaoDong as d on hd.HeaderID = d.HeaderID
			                                left join NhanVien as nv on nv.MaNV = d.MaNV
			                                left join CongViec_NhomCongViec cv_ncv on cv_ncv.MaCongViec = nv.MaCongViec
			                                left join NhomCongViec ncv on ncv.MaNhomCongViec = cv_ncv.MaNhomCongViec) as dilam,
                                (select
                                sum(case when (d.DiLam = 0 and (d.LyDoVangMat = N'Ốm' or d.LyDoVangMat = N'Nghỉ phép' or d.LyDoVangMat = N'Vô lý do'
								                                or d.LyDoVangMat = N'Khác' or d.LyDoVangMat = N'Tai nạn lao động' or d.LyDoVangMat = N'Ốm dài'
								                                or d.LyDoVangMat = N'Thai sản' or d.LyDoVangMat = N'Tạm hoãn lao động'
								                                or d.LyDoVangMat = N'Vô lý do dài')) then 1 else 0 end) as 'TongNghi',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Ốm') then 1 else 0 end) as 'Om',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Nghỉ phép') then 1 else 0 end) as 'Phep',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Vô lý do') then 1 else 0 end) as 'VoLyDo',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Khác') then 1 else 0 end) as 'Khac',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Tai nạn lao động') then 1 else 0 end) as 'TaiNanLaoDong',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Ốm dài') then 1 else 0 end) as 'OmDai',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Thai sản') then 1 else 0 end) as 'ThaiSan',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Tạm hoãn lao động') then 1 else 0 end) as 'TamHoanLaoDong',
                                sum(case when (d.DiLam = 0 and d.LyDoVangMat = N'Vô lý do dài') then 1 else 0 end) as 'VoLyDoDai'
                                from Header_DiemDanh_NangSuat_LaoDong as hd
	                                join DiemDanh_NangSuatLaoDong as d  on hd.HeaderID = d.HeaderID
	                                where MaPhongBan = @departmentID and NgayDiemDanh = @date and Ca = @session) as nghi";
                    var listSum = db.Database.SqlQuery<SoLuongDiLam_Vang>(mysql,
                                                                        new SqlParameter("departmentID", departmentID.ToString()),
                                                                        new SqlParameter("date", date.ToString("yyyy-MM-dd")),
                                                                        new SqlParameter("session", session.ToString())).FirstOrDefault();

                    return listSum;
                }

            }
            catch (Exception e)
            {

            }
            return null;
        }


        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [HttpPost]
        [Route("phan-xuong/diem-danh")]
        public ActionResult takeAttendance()
        {
            var departmentID = Session["departID"].ToString();
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            string manv = Request["MaNV"];
            string tennv = Request["TenNV"];
            dynamic listAttendance;
            SoLuongDiLam_Vang listAtten_NotAtten;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var head = db.Header_DiemDanh_NangSuat_LaoDong
                             .Where(h => h.MaPhongBan == departmentID && h.NgayDiemDanh == dateAtt && h.Ca == session)
                             .FirstOrDefault();
                if (head == null)
                {
                    Header_DiemDanh_NangSuat_LaoDong header = new Header_DiemDanh_NangSuat_LaoDong();
                    header.MaPhongBan = departmentID;
                    header.Ca = session;
                    header.NgayDiemDanh = dateAtt;
                    db.Header_DiemDanh_NangSuat_LaoDong.Add(header);
                    db.SaveChanges();
                }
                listAttendance = getAll(session, departmentID, dateAtt, manv, tennv);
                listAtten_NotAtten = getAttendance_NotAttendance(session, departmentID, dateAtt);
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                return Json(new { success = true, data = result, listAtten_NotAtten = listAtten_NotAtten }, JsonRequestBehavior.AllowGet);
            }
        }
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [HttpPost]
        [Route("phan-xuong/diem-danh/cap-nhat")]
        public ActionResult updateAttendance()
        {
            var listUpdateJSON = Request["sessionId"];
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            string manv = Request["MaNV"];
            string tennv = Request["TenNV"];
            var listUpdate = JsonConvert.DeserializeObject<List<updateStatus>>(listUpdateJSON);
            SoLuongDiLam_Vang listAtten_NotAtten;
            using (var transaction = new TransactionScope())
            {
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    var headerID = db.Header_DiemDanh_NangSuat_LaoDong
                                     .Where(x => x.MaPhongBan == departmentID && x.NgayDiemDanh == dateAtt && x.Ca == session)
                                     .Select(x => x.HeaderID).FirstOrDefault();
                    //
                    foreach (var item in listUpdate)
                    {
                        DiemDanh_NangSuatLaoDong dn = new DiemDanh_NangSuatLaoDong();
                        dn.MaNV = item.maNV;
                        dn.DiLam = item.status;
                        dn.LyDoVangMat = item.reason;
                        dn.ThoiGianThucTeDiemDanh = item.timeAttendance != "" ? (DateTime?)Convert.ToDateTime(item.timeAttendance) : null;
                        dn.GhiChu = item.description;
                        if (item.isEnvolved)
                        {
                            dn.HeaderID = headerID;
                            if (item.headerID == null)
                            {
                                db.DiemDanh_NangSuatLaoDong.Add(dn);
                            }
                            else
                            {
                                db.Entry(dn).State = EntityState.Modified;
                            }
                        }
                        else
                        {
                            if (item.headerID != null)
                            {
                                db.DiemDanh_NangSuatLaoDong.Remove(db.DiemDanh_NangSuatLaoDong.Find(item.maNV, item.headerID));
                                //dn.HeaderID = headerID;
                                //db.Entry(dn).State = EntityState.Modified;
                            }
                        }
                    }

                    db.SaveChanges();
                    transaction.Complete();
                }
            }
            var listAttendance = getAll(session, departmentID, dateAtt, manv, tennv);
            listAtten_NotAtten = getAttendance_NotAttendance(session, departmentID, dateAtt);
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
            return Json(new { success = true, data = result, listAtten_NotAtten = listAtten_NotAtten }, JsonRequestBehavior.AllowGet);
        }
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [HttpPost]
        [Route("phan-xuong/diem-danh/lua-chon-diem-danh")]
        public ActionResult filterEmployee()
        {
            //
            var workAll = bool.Parse(Request["workChecked"]);
            var notWorkAll = bool.Parse(Request["notWorkChecked"]);
            // fixxing
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            SoLuongDiLam_Vang listAtten_NotAtten;
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var listAttendance = (from emp in db.NhanViens
                                        .Where(emp => emp.MaPhongBan == departmentID)
                                      join per in db.DiemDanh_NangSuatLaoDong
                                      on emp.MaNV equals per.MaNV into tmp1
                                      from tmp2 in tmp1.DefaultIfEmpty()
                                        .Where(per => ((workAll ? (per.DiLam == true) : (per.DiLam == false || per.DiLam == null)) || (notWorkAll ? (per.DiLam == false || per.DiLam == null) : (per.DiLam == true))) && (workAll || notWorkAll))
                                      join header in db.Header_DiemDanh_NangSuat_LaoDong
                                        .Where(h => h.MaPhongBan == departmentID && h.Ca == session && h.NgayDiemDanh == dateAtt)
                                      on tmp2.HeaderID equals header.HeaderID into attendance
                                      from att in attendance.DefaultIfEmpty()
                                      select new
                                      {
                                          maNV = emp.MaNV,
                                          tenNV = emp.Ten,
                                          status = (bool?)tmp2.DiLam,
                                          timeAttendance = tmp2.ThoiGianThucTeDiemDanh,
                                          reason = tmp2.LyDoVangMat,
                                          description = tmp2.GhiChu
                                      }).OrderBy(att => att.status).ToList();
                listAtten_NotAtten = getAttendance_NotAttendance(session, departmentID, dateAtt);
                JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                return Json(new { success = true, data = result, listAtten_NotAtten = listAtten_NotAtten }, JsonRequestBehavior.AllowGet);
            }
        }
        [Auther(RightID = "179,180,181,183,184,185,186,187,189,195")]
        [HttpPost]
        [Route("phan-xuong/diem-danh/lay-thong-tin")]
        public ActionResult fetchAPI()
        {
            var departmentID = Request["department"];
            var dateAtt = Convert.ToDateTime(Request["date"]);
            int session = Int32.Parse(Request["session"]);
            string manv = Request["MaNV"];
            string tennv = Request["TenNV"];
            SoLuongDiLam_Vang listAtten_NotAtten;
            //
            var listAttendanceFromAPI = new List<FakeAPI>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Task t = Task.Run(async () =>
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://foodserver.azurewebsites.net/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //GET Method
                        HttpResponseMessage response = await client.GetAsync("api/Attendance");
                        using (HttpContent content = response.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            listAttendanceFromAPI = JsonConvert.DeserializeObject<List<FakeAPI>>(data);
                        }
                    }
                });
                t.Wait();
                //
                List<String> listAttendanceFromAPI_ID = new List<string>();
                foreach (var item in listAttendanceFromAPI)
                {
                    listAttendanceFromAPI_ID.Add(item.MaNV);
                }
                try
                {
                    using (var transaction = new TransactionScope())
                    {
                        // get all "ma nhan vien" already have been taken attendance.
                        List<String> listAttendanceID = db.DiemDanh_NangSuatLaoDong/*.Where(dd => dd.CaDiemDanh == session && dd.MaDonVi == departmentID && dd.NgayDiemDanh == dateAtt)*/.Select(col => col.MaNV).ToList();
                        foreach (var id in listAttendanceFromAPI_ID)
                        {
                            if (!listAttendanceID.Contains(id))
                            {
                                DiemDanh_NangSuatLaoDong dn = new DiemDanh_NangSuatLaoDong();
                                //dn.MaDonVi = departmentID;
                                //dn.CaDiemDanh = session;
                                //dn.NgayDiemDanh = dateAtt;
                                dn.MaNV = id;
                                // from API
                                //dn.XacNhan = false;
                                db.DiemDanh_NangSuatLaoDong.Add(dn);
                                db.SaveChanges();
                            }
                        }
                        transaction.Complete();
                    }
                    listAtten_NotAtten = getAttendance_NotAttendance(session, departmentID, dateAtt);
                    var listAttendance = getAll(session, departmentID, dateAtt, manv, tennv);
                    JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                    var result = JsonConvert.SerializeObject(listAttendance, Formatting.Indented, jss);
                    return Json(new { success = true, data = result, time = "hihi", listAtten_NotAtten = listAtten_NotAtten }, JsonRequestBehavior.AllowGet);
                }
                catch
                {

                }
            }
            return View();
        }

        //////PXDS////////
        private readonly IPxdsRepository _repository;

        public PhanXuongController(IPxdsRepository repo)
        {
            _repository = repo;
        }
        [Auther(RightID = "122")]
        [HttpGet]
        [Route("phan-xuong-doi-song/theo-doi-suat-an")]
        public ActionResult MealRegisterView()
        {
            return View("/Views/PX/PXDS/View.cshtml");
        }

        [Auther(RightID = "123")]
        [HttpGet]
        [Route("phan-xuong-doi-song/dang-ky-suat-an")]
        public ActionResult MealRegisterInput()
        {
            var timeHelper = new TimeHelper();
            DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
            ViewBag.MondayOfNextWeek = mondayOfNextWeek.Date.ToString("dd/MM/yyyy");
            ViewBag.FridayOfNextWeek = mondayOfNextWeek.AddDays(5).Date.ToString("dd/MM/yyyy");
            return View("/Views/PX/PXDS/Input.cshtml");
        }

        [Auther(RightID = "123")]
        [HttpGet]
        [Route("phan-xuong-doi-song/dang-ky-suat-an/details")]
        public ActionResult RegistrationDetail()
        {
            var details = _repository.GetDetails();
            return Json(new
            {
                success = true,
                data = details
            }, JsonRequestBehavior.AllowGet);
        }

        [Auther(RightID = "123")]
        [HttpPost]
        [Route("phan-xuong-doi-song/dang-ky-suat-an/save")]
        public ActionResult RegistrationSave(IList<PxdsModelView> details)
        {
            var timeHelper = new TimeHelper();
            DateTime mondayOfNextWeek = timeHelper.StartOfNextWeek(DateTime.Now, DayOfWeek.Monday);
            bool success;
            if (_repository.HasMealRegistration(mondayOfNextWeek))
            {
                success = _repository.UpdateMealRegistration(details);
            }
            else
            {
                success = _repository.SaveMealRegistration(details);
            }
            return Json(new { success }, JsonRequestBehavior.AllowGet);
        }
    }
    public class updateStatus
    {
        public bool isEnvolved { get; set; }
        public int? headerID { get; set; }
        public string maDV { get; set; }
        public string maNV { get; set; }
        public string tenNV { get; set; }
        public bool status { get; set; }
        public string timeAttendance { get; set; }
        public string reason { get; set; }
        public string description { get; set; }
    }

    public class attendanceEntity
    {
        public int? headerID { get; set; }
        public string maNV { get; set; }
        public string tenNV { get; set; }
        public DateTime? timeAttendance { get; set; }
        public string reason { get; set; }
        public string description { get; set; }

        public bool? status { get; set; }

    }

    public class SoLuongDiLam_Vang
    {
        public int TongDiLam { get; set; }
        public int DiLam_CNKT { get; set; }
        public int DiLam_CNCD { get; set; }
        public int DiLam_CBQL { get; set; }
        public int TongNghi { get; set; }
        public int Om { get; set; }
        public int Phep { get; set; }
        public int VoLyDo { get; set; }
        public int Khac { get; set; }
        public int TaiNanLaoDong { get; set; }
        public int OmDai { get; set; }
        public int ThaiSan { get; set; }
        public int TamHoanLaoDong { get; set; }
        public int VoLyDoDai { get; set; }
    }

    public class NangSuatLaoDong_TungCongNhan
    {
        public DateTime NgayDiemDanh { get; set; }
        public int Ca { get; set; }
        public string MaNV { get; set; }
        public string Ten { get; set; }
        public double DiemLuong { get; set; }
    }

    public class Sum_DiemLuong_Than_MetLo_Xen
    {
        public double TotalEffort { get; set; }
        public double ThanThucHien { get; set; }
        public double MetLoThucHien { get; set; }
        public double XenThucHien { get; set; }
    }

    public class BaoCaoTheoCa
    {
        public int STT { get; set; }
        public string Name { get; set; }
        public string SoThe { get; set; }
        public string BacTho { get; set; }
        public string ChucDanh { get; set; }
        public string NoiDungCongViec { get; set; }
        public string HeSoChiaLuong { get; set; }
        public string LuongTruocDuyet { get; set; }
        public string LuongSauDuyet { get; set; }
        public string DuBaoNguyCo { get; set; }
        public string YeuCauBPKTAT { get; set; }
    }
}
