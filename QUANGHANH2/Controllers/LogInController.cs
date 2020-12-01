using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using XCrypt;
using System.Linq.Dynamic;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers
{

    public class LogInController : Controller
    {
        private QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
        // GET: /<controller>/ neww
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                string url = (string)Session["url"];
                return Redirect(url);
            }
            if (HttpContext.Request.Cookies["token"] != null)
            {
                HttpCookie remme = HttpContext.Request.Cookies.Get("token");
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    string token = remme.Values.Get("token");
                    int uid = int.Parse(remme.Values.Get("uid"));
                    var info = db.Accounts.Where(x => x.token.Equals(token) && x.ID == uid).FirstOrDefault();
                    if(info != null)
                    {
                        login a = new login()
                        {
                            username = info.Username,
                            password = Hash.Encrypt.DecryptString(token, "quanghanhcoals")
                        };
                        ViewBag.login = a;
                    }
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password, string rm)
        {
            if (password == null) return RedirectToAction("Index");
            string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(password, "pl");
            var checkuser = db.Accounts.Where(x => x.Username == username).Where(y => y.Password == passXc).SingleOrDefault();
            if (checkuser != null)
            {
                if (checkuser.Username.Equals(username) && checkuser.Password.Equals(passXc))
                {
                    Session["UserID"] = checkuser.ID;
                    Session["time"] = DateTime.Now;
                    int id = checkuser.ID;
                    var Name = db.Database.SqlQuery<InfoAccount>(@"select a.ID, ep.BASIC_INFO_full_name, a.Username, a.Position, a.ADMIN, d.department_name, d.department_id, a.Role 
                                                                    from Account.Account a, HumanResources.Employee ep , General.Department d
                                                                    where a.NVID = ep.employee_id and d.department_id = ep.current_department_id and a.ID = @id", new SqlParameter("id", id)).FirstOrDefault();
                    Session["departName"] = Name.department_name.Trim();
                    Session["departID"] = Name.department_id.Trim();
                    Session["account_id"] = Name.ID;
                    Session["Name"] = Name.Ten;
                    Session["username"] = Name.Username.Trim();
                    Session["Position"] = Name.Position.Trim();
                    Session["isAdmin"] = Name.ADMIN;
                    Session["Role"] = Name.Role;
                    GetPermission(id);
                    //thư viện đang dùng cho hashpass không decrypt được nên phải dùng thư viện khác để set pass cookie
                    string hashtoken = Hash.Encrypt.EncryptString(password,"quanghanhcoals");
                    if (!String.IsNullOrEmpty(rm))
                    {
                        if (rm.Equals("on"))
                        {
                            HttpCookie remme = new HttpCookie("token");
                            remme["token"] = hashtoken;
                            remme["uid"] = Name.ID.ToString();
                            remme.Expires = DateTime.Now.AddDays(365);
                            remme.Secure = true;
                            remme.HttpOnly = true;
                            HttpContext.Response.Cookies.Add(remme);
                            checkuser.token = hashtoken;
                            try
                            {
                                db.Entry(checkuser).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            catch (Exception e) { }
                        }
                    }
                    if (Name.ADMIN) return RedirectToAction("Index", "ManagementUser");
                    string url = (string)Session["url"];
                    if (url == null)
                    {
                        ViewData["Notification"] = "Tài khoản chưa được kích hoạt";
                        Session.Abandon();
                        return View();
                    }
                    return Redirect(url);
                }
                else
                {
                    ViewData["Notification"] = "Tên đăng nhập/mật khẩu không đúng!";
                    return View();
                }
            }
            else
            {
                ViewData["Notification"] = "Tên đăng nhập/mật khẩu không đúng!";
                return View();
            }

        }
        [Route("Logout")]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        public void GetPermission(int UserID)
        {
            Session["UserID"] = UserID;
            List<string> RightIDs = new List<string>();
            var userRight = db.Account_Right_Detail.Where(a => a.AccountID == UserID).ToList();
            foreach (var right in userRight)
            {
                RightIDs.Add(right.RightID + "");
            }
            if (Session["Position"].ToString().Equals("Trưởng phòng") && Session["departID"].ToString().Equals("CV"))
            {
                RightIDs.Add("192");
            }
            if (Session["Position"].ToString().Equals("Trưởng phòng"))
            {
                RightIDs.Add("0");
            }
            var user = db.Accounts.Where(x => x.ID == UserID).FirstOrDefault();

            if (user.NVID != null)
            {
                //var url = db.NhanViens.Where(x => x.MaNV == user.NVID).FirstOrDefault();

                var mysql = @"select * from HumanResources.Employee ep 
                            join General.Department dp on ep.current_department_id = dp.department_id where ep.employee_id = @nvid";
                var url = db.Database.SqlQuery<nvs>(mysql, new SqlParameter("nvid", user.NVID)).FirstOrDefault();

                if (url.current_department_id.Equals("CV"))
                {
                    Session["url"] = "phong-cdvt";
                    RightIDs.Add("001");
                }
                if (url.current_department_id.Equals("TCLĐ"))
                {
                    Session["url"] = "phong-tcld";
                    RightIDs.Add("002");
                }
                if (url.current_department_id.Equals("KCS"))
                {
                    Session["url"] = "phong-kcs";
                    RightIDs.Add("003");
                }
                if (url.current_department_id.Equals("ĐK"))
                {
                    Session["url"] = "phong-dieu-khien";
                    RightIDs.Add("004");
                }
                if (url.current_department_id.Equals("BGĐ"))
                {
                    Session["url"] = "ban-giam-doc/bao-cao-nhanh-san-xuat";
                    RightIDs.Add("005");
                }
                if (url.department_type.Contains("Phân xưởng"))
                {
                    Session["url"] = "phan-xuong";
                    RightIDs.Add("006");
                }
                if (url.current_department_id.Equals("AT"))
                {
                    Session["url"] = "phong-an-toan/danh-sach-tai-nan";
                    RightIDs.Add("007");
                }
                if (url.current_department_id.Equals("KCM"))
                {
                    Session["url"] = "phong-kcm/ke-hoach-san-xuat-thang";
                    RightIDs.Add("008");
                }
            }
            if (Boolean.Parse(Session["isAdmin"].ToString()) == true)
            {
                RightIDs.Add("0");
                Session["url"] = "ManagementUser/Index";
                //Session["departID"] = "QL";
            }
            RightIDs.Add("000");
            Session["RightIDs"] = RightIDs;
        }
        [Auther(RightID = "000")]
        public ActionResult Detail()
        {
            DateTime start = Convert.ToDateTime(Session["time"]).AddMinutes(20);
            ViewBag.remain = start.Subtract(DateTime.Now).TotalMinutes;
            return View("/Views/LogIn/Account_Information.cshtml");
        }
        [Auther(RightID = "000")]
        public JsonResult ResetPassword(string oldPass, string newPass, string rePass)
        {
            int id = Convert.ToInt32(Session["account_id"]);
            string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(oldPass, "pl");
            string rePasss = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(rePass, "pl");
            var user = db.Accounts.Where(x => x.ID == id).FirstOrDefault();
            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(rePass))
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = "Mật khẩu không được để trống"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!newPass.Equals(rePass))
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = "2 mật khẩu không trùng khớp"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!user.Password.Equals(passXc))
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = "Mật khẩu cũ không đúng"
                }, JsonRequestBehavior.AllowGet);
            }
            user.Password = rePasss;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new Result()
            {
                CodeError = 2,
                Data = "Thay đổi mật khẩu thành công"
            }, JsonRequestBehavior.AllowGet);
        }
    }
    public class login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class Result
    {
        public int CodeError { get; set; }
        public string Data { get; set; }
    }
    public class InfoAccount
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public string TenCongViec { get; set; }
        public bool ADMIN { get; set; }
        public string department_name { get; set; }
        public string department_id { get; set; }
        public int Role { get; set; }
    }
    public class nvs : Employee
    {
        public string department_type { get; set; }
    }
}
