using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers
{

    public class LogInController : Controller
    {
        private QUANGHANHABCEntities1 db = new QUANGHANHABCEntities1();
        // GET: /<controller>/
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                string url = (string)Session["url"];
                return Redirect(url);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var checkuser = db.Accounts.Where(x => x.Username == username).Where(y => y.Password == password).ToList();
            if (checkuser.Count > 0)
            {
                Session["UserID"] = checkuser[0].ID;
                string id = checkuser[0].ID;
                var Name = db.Accounts.Where(x => x.ID == id).FirstOrDefault<Account>();
                Session["Name"] = Name.Name;
                Session["username"] = Name.Username;
                Session["Position"] = Name.Position;
                GetPermission(checkuser[0].ID);
                if (Name.Name.Equals("ADMIN")) return RedirectToAction("Index","ManagementUser");
                string url = (string)Session["url"];
                if(url == null)
                {
                    ViewData["Notification"] = "Bạn không có bất kì quyền hạn nào.";
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
        public void GetPermission(string UserID)
        {
            Session["UserID"] = UserID;
            List<string> RightIDs = new List<string>();
            var userRight = db.Account_Right_Detail.Where(a => a.AccountID == UserID).ToList();
            foreach (var right in userRight)
            {
                RightIDs.Add(right.RightID + "");
            }
            if (RightIDs.Count > 0)
            {
                int id = int.Parse(RightIDs[0]);
                var module = db.Account_Right.Where(x => x.ID == id).FirstOrDefault();
                string url = module.ModuleID;
                if (url.Equals("1"))
                {
                    Session["url"] = "phong-cdvt";
                }
                if (url.Equals("2"))
                {
                    Session["url"] = "phong-tcld";
                }
                if (url.Equals("3"))
                {
                    Session["url"] = "phong-kcs";
                }
                if (url.Equals("4"))
                {
                    Session["url"] = "phong-dieu-khien";
                }
                if (url.Equals("5"))
                {
                    Session["url"] = "ban-giam-doc";
                }
                if (url.Equals("6"))
                {
                    Session["url"] = "phan-xuong-khai-thac";
                }
            }
            if (Session["Name"].Equals("ADMIN")) RightIDs.Add("0");
            Session["RightIDs"] = RightIDs;
        }
    }
}
