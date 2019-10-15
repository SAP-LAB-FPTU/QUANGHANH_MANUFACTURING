using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using XCrypt;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers
{

    public class LogInController : Controller
    {
        private QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        // GET: /<controller>/ neww
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                string url = (string)Session["url"];
                return Redirect(url);
            }
            if (HttpContext.Request.Cookies["remme"] != null)
            {
                HttpCookie remme = HttpContext.Request.Cookies.Get("remme");
                login a = new login()
                {
                    username = remme.Values.Get("username"),
                    password = remme.Values.Get("password")
                };
                ViewBag.login = a;
                return View();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password, string rm)
        {
            if (password == null) return RedirectToAction("Index");
            string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(password, "pl");
            var checkuser = db.Accounts.Where(x => x.Username == username).Where(y => y.Password == passXc).SingleOrDefault();
            if (checkuser.Username.Equals(username) && checkuser.Password.Equals(passXc))
            {
                Session["UserID"] = checkuser.ID;
                int id = checkuser.ID;
                var Name = db.Accounts.Where(x => x.ID == id).FirstOrDefault<Account>();
                if (Name.NVID != null)
                {
                    var depart = db.NhanViens.Where(x => x.MaNV == Name.NVID).FirstOrDefault();
                    var departName = db.Departments.Where(x => x.department_id == depart.MaPhongBan).FirstOrDefault();
                    Session["departName"] = departName.department_name;
                    Session["departID"] = departName.department_id;
                }
                Session["Name"] = Name.Name;
                Session["username"] = Name.Username;
                Session["Position"] = Name.Position;
                Session["isAdmin"] = Name.ADMIN;
                GetPermission(id);
                if (!String.IsNullOrEmpty(rm))
                {
                    if (rm.Equals("on"))
                    {
                        HttpCookie remme = new HttpCookie("remme");
                        remme["username"] = Name.Username;
                        remme["password"] = password;
                        remme.Expires = DateTime.Now.AddDays(365);
                        HttpContext.Response.Cookies.Add(remme);
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
            var user = db.Accounts.Where(x => x.ID == UserID).FirstOrDefault();

            if (user.NVID != null)
            {
                var url = db.NhanViens.Where(x => x.MaNV == user.NVID).FirstOrDefault();

                if (url.MaPhongBan.Equals("CDVT"))
                {
                    Session["url"] = "phong-cdvt";
                    RightIDs.Add("001");
                }
                if (url.MaPhongBan.Equals("TCLD"))
                {
                    Session["url"] = "phong-tcld";
                    RightIDs.Add("002");
                }
                if (url.MaPhongBan.Equals("KCS"))
                {
                    Session["url"] = "phong-kcs";
                    RightIDs.Add("003");
                }
                if (url.MaPhongBan.Equals("DK"))
                {
                    Session["url"] = "phong-dieu-khien";
                    RightIDs.Add("004");
                }
                if (url.MaPhongBan.Equals("BGD"))
                {
                    Session["url"] = "ban-giam-doc";
                    RightIDs.Add("005");
                }
                if (url.MaPhongBan.Contains("PX"))
                {
                    Session["url"] = "phan-xuong";
                    RightIDs.Add("006");
                }
            }
            if (Boolean.Parse(Session["isAdmin"].ToString()) == true)
            {
                RightIDs.Add("0");
                Session["url"] = "ManagementUser/Index";
            }
            Session["RightIDs"] = RightIDs;
        }
    }
    public class login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
