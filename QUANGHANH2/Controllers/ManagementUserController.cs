using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCrypt;

namespace QUANGHANH2.Controllers
{
    [Auther(RightID = "0")]
    public class ManagementUserController : Controller
    {
        private QUANGHANHABCEntities db = new QUANGHANHABCEntities();
        // GET: ManagementUser

        public ActionResult Index(string username)
        {
            if (!String.IsNullOrEmpty(username))
            {
                if (db.Accounts.Where(a => a.Username == username).Count() > 0)
                {
                    Account user = db.Accounts.Where(a => a.Username == username).First();
                    return View(user);
                }
                else
                {
                    return View(new Account());
                }
            }
            else
            {
                return View(new Account());
            }
        }
        [HttpPost]
        public JsonResult Index(DataTableAjaxPostModel model)
        {
            var users = db.Accounts;
            var search = users.Where(a => true);
            int CurrentUser = int.Parse(Session["UserID"].ToString());
            if (CurrentUser != 14)
            {
                search = search.Where(a => a.ID != 14);
            }
            if (model.search.value != null)
            {
                string searchValue = model.search.value;
                search = search.Where(a => a.Username.Contains(searchValue) || a.Name.Contains(searchValue));
            }
            if (model.columns[1].search.value != null)
            {
                string searchValue = model.columns[1].search.value;
                search = search.Where(a => a.Username.Contains(searchValue));
            }
            if (model.columns[2].search.value != null)
            {
                string searchValue = model.columns[2].search.value;
                search = search.Where(a => a.Name.Contains(searchValue));
            }

            var sorting = search.OrderBy(a => a.ID);
            if (model.order[0].column == 2)
            {
                if (model.order[0].dir.Equals("asc"))
                {
                    sorting = search.OrderBy(a => a.Username);
                }
                else
                {
                    sorting = search.OrderByDescending(a => a.Username);
                }

            }
            else if (model.order[0].column == 3)
            {
                if (model.order[0].dir.Equals("asc"))
                {
                    sorting = search.OrderBy(a => a.Name);
                }
                else
                {
                    sorting = search.OrderByDescending(a => a.Name);
                }

            }
            var paging = sorting.Skip(model.start).Take(model.length).ToList();
            var result = new List<CustomUser>(paging.Count);
            foreach (var s in paging)
            {
                result.Add(new CustomUser
                {
                    ID = s.ID + "",
                    Name = s.Name,
                    Username = s.Username
                });
            };
            return Json(new
            {
                draw = model.draw,
                recordsTotal = users.Count(),
                recordsFiltered = search.Count(),
                data = result
            });
        }
        [HttpPost]
        public JsonResult GetRightInModule(string module, int UserID)
        {
            if (!UserID.Equals(""))
            {
                Rights rights = new Rights();
                rights.Accept = new List<FunctionRight>();
                rights.Deny = new List<FunctionRight>();

                if (UserID == 1)
                {
                    var rightAccept = db.Database.SqlQuery<FunctionRight>("select a.ID,a.[Right],a.GroupID from Account_Right a,Account_Right_Detail ar where a.ID=ar.RightID and a.ModuleID='" + module + "' and ar.AccountID='" + UserID + "' order by a.GroupID asc").ToList<FunctionRight>();
                    foreach (var r in rightAccept)
                    {
                        rights.Accept.Add(new FunctionRight()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                    var rightDeny = db.Database.SqlQuery<FunctionRight>("select distinct a.ID,a.[Right],a.GroupID from Account_Right a,Account_Right_Detail ar where a.ModuleID='" + module + "' and a.ID not in (select a.RightID from Account_Right_Detail a where a.AccountID='" + UserID + "') order by a.GroupID asc").ToList<FunctionRight>();
                    foreach (var r in rightDeny)
                    {
                        rights.Deny.Add(new FunctionRight()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                }
                else
                {
                    var rightAccept = db.Database.SqlQuery<FunctionRight>("select a.ID,a.[Right],a.GroupID from Account_Right a,Account_Right_Detail ar where a.ID=ar.RightID and a.ModuleID='" + module + "' and ar.AccountID='" + UserID + "' order by a.GroupID asc").ToList<FunctionRight>();
                    foreach (var r in rightAccept)
                    {
                        rights.Accept.Add(new FunctionRight()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                    var rightDeny = db.Database.SqlQuery<FunctionRight>("select distinct a.ID,a.[Right],a.GroupID from Account_Right a,Account_Right_Detail ar where a.ModuleID='" + module + "' and a.ID not in (select a.RightID from Account_Right_Detail a where a.AccountID='" + UserID + "') order by a.GroupID asc").ToList<FunctionRight>();
                    foreach (var r in rightDeny)
                    {
                        rights.Deny.Add(new FunctionRight()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                }
                return Json(rights, JsonRequestBehavior.AllowGet);
            }
            else
            {
                RightsWhenCreate rights = new RightsWhenCreate();
                rights.Accept = new List<FunctionRight>();
                rights.Deny = new List<FunctionRight>();
                var rightDeny = db.Database.SqlQuery<FunctionRight>("select a.ID,a.[Right],a.GroupID from Account_Right a where a.ModuleID='" + module + "' order by a.GroupID asc").ToList<FunctionRight>();
                foreach (var r in rightDeny)
                {
                    rights.Deny.Add(new FunctionRight()
                    {
                        ID = r.ID,
                        Right = r.Right,
                        GroupID = r.GroupID
                    });
                }
                return Json(rights, JsonRequestBehavior.AllowGet);
            }
        }
        public void addModule(int module, int ID, int moduleID)
        {
            if (module == 1)
            {
                var listRight = db.Account_Right.Where(x => x.ModuleID == moduleID + "").ToList();
                var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='" + moduleID + "'").ToList<Account_Right_Detail>();
                foreach (var r in rightRemove)
                {
                    var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                    db.Account_Right_Detail.Remove(del);
                }
                db.SaveChanges();
                foreach (var r in listRight)
                {
                    if (!String.IsNullOrEmpty(r.ID + ""))
                    {
                        Account_Right_Detail rd = new Account_Right_Detail()
                        {
                            AccountID = ID,
                            RightID = r.ID
                        };
                        db.Account_Right_Detail.Add(rd);
                    }
                }
                db.SaveChanges();
            }
        }
        [HttpPost]
        public JsonResult AddNewUser(string Name, string Username, string Position, string Password, string RepeatPassword,string NVID,
                int module1, int module2, int module3, int module4, int module5, int module6, int module7,
                int module8, int module9, int module10, int module11, int module12, int module13, int module14,
                int module15, int module16, int module19, string rights)
        {
            if (db.Accounts.Where(x => x.Username == Username).Count() > 0)
            {
                return Json(new Result()
                {
                    CodeError = 2,
                    Data = "Người dùng với tên đăng nhập <strong style='color:black; '>" + Username + "</strong> đã tồn tại!"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!String.IsNullOrEmpty(NVID))
            {
                if (db.NhanViens.Where(x=>x.MaNV == NVID).Count() == 0)
                {
                    return Json(new Result()
                    {
                        CodeError = 2,
                        Data = "Mã nhân viên <strong style='color:black; '>" + NVID + "</strong> không tồn tại!"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                NVID = null;
            }
            string InvalidFields = "";
            if (String.IsNullOrEmpty(Name))
            {
                InvalidFields += "Họ Tên -";
            }
            if (String.IsNullOrEmpty(Username))
            {
                InvalidFields += "Tên đăng nhập -";
            }
            if (String.IsNullOrEmpty(Position))
            {
                InvalidFields += "Chức vụ -";
            }
            if (InvalidFields != "")
            {
                InvalidFields += " không thể để trống !!!";
            }
            if (String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(RepeatPassword))
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = "Mật khẩu không được để trống !!!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (Password != RepeatPassword)
                {
                    InvalidFields += "<br />Mật khảu không khớp !!!";
                }
            }
            if (InvalidFields != "")
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = InvalidFields
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(Password, "pl");
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Account a = new Account()
                        {
                            Name = Name,
                            Username = Username,
                            Password = passXc,
                            Position = Position,
                            NVID = NVID,
                            CDVT = Convert.ToBoolean(module1),
                            TCLD = Convert.ToBoolean(module2),
                            KCS = Convert.ToBoolean(module3),
                            DK = Convert.ToBoolean(module4),
                            BGD = Convert.ToBoolean(module5),
                            PXKT = Convert.ToBoolean(module6),
                            PXDL = Convert.ToBoolean(module8),
                            PXVT = Convert.ToBoolean(module9),
                            PXST = Convert.ToBoolean(module10),
                            PXPV = Convert.ToBoolean(module11),
                            PXDS = Convert.ToBoolean(module12),
                            PXCDM = Convert.ToBoolean(module13),
                            PXTGQLM = Convert.ToBoolean(module14),
                            PXXD = Convert.ToBoolean(module15),
                            PXLT = Convert.ToBoolean(module16),
                            AT = Convert.ToBoolean(module19),
                            KCM = false,
                        };
                        db.Accounts.Add(a);
                        db.SaveChanges();
                        var acc = db.Accounts.Where(x => x.Username == Username).FirstOrDefault();
                        var rightsSplit = rights.Split(',');
                        foreach (var r in rightsSplit)
                        {
                            if (!String.IsNullOrEmpty(r))
                            {
                                Account_Right_Detail rd = new Account_Right_Detail()
                                {
                                    AccountID = acc.ID,
                                    RightID = int.Parse(r)
                                };
                                db.Account_Right_Detail.Add(rd);
                            }
                        }
                        db.SaveChanges();
                        addModule(module1, acc.ID, 1);
                        addModule(module2, acc.ID, 2);
                        addModule(module3, acc.ID, 3);
                        addModule(module4, acc.ID, 4);
                        addModule(module5, acc.ID, 5);
                        addModule(module6, acc.ID, 6);
                        addModule(module8, acc.ID, 8);
                        addModule(module9, acc.ID, 9);
                        addModule(module10, acc.ID, 10);
                        addModule(module11, acc.ID, 11);
                        addModule(module12, acc.ID, 12);
                        addModule(module13, acc.ID, 13);
                        addModule(module14, acc.ID, 14);
                        addModule(module15, acc.ID, 15);
                        addModule(module16, acc.ID, 16);
                        addModule(module19, acc.ID, 19);
                        if (module7 == 1)
                        {
                            var user = db.Accounts.SingleOrDefault(x => x.ID == acc.ID);
                            user.Name = Name;
                            user.Username = Username;
                            user.Password = passXc;
                            user.Position = Position;
                            user.NVID = NVID;
                            user.CDVT = false;
                            user.TCLD = false;
                            user.KCS = false;
                            user.DK = false;
                            user.BGD = false;
                            user.PXKT = false;
                            user.ADMIN = true;
                            user.PXDL = false;
                            user.PXVT = false;
                            user.PXST = false;
                            user.PXPV = false;
                            user.PXDS = false;
                            user.PXCDM = false;
                            user.PXTGQLM = false;
                            user.PXXD = false;
                            user.PXLT = false;
                            user.AT = false;
                            user.KCM = false;
                            db.Entry(user).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        trans.Commit();
                        return Json(new Result()
                        {
                            CodeError = 0,
                            Data = "Tài khoản <strong style='color:black;'>" + Username + " </strong> đã được thêm mới thành công cho <strong style='color:black;'>" + Name + "</strong>"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return Json(new Result()
                        {
                            CodeError = 2,
                            Data = "Có lỗi vui lòng kiểm tra lại!"
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
            }

        }
        public void updateModule(int module, int ID, bool pb, int moduleID)
        {
            if (Convert.ToBoolean(module).Equals(pb))
            { }
            else
            {
                var listRight = db.Account_Right.Where(x => x.ModuleID == moduleID + "").ToList();
                var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='" + moduleID + "'").ToList<Account_Right_Detail>();
                foreach (var r in rightRemoveup)
                {
                    var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                    db.Account_Right_Detail.Remove(del);
                }
                if (module == 0)
                { }
                else
                {
                    db.SaveChanges();
                    foreach (var r in listRight)
                    {
                        if (!String.IsNullOrEmpty(r.ID + ""))
                        {
                            Account_Right_Detail rd = new Account_Right_Detail()
                            {
                                AccountID = ID,
                                RightID = r.ID
                            };
                            db.Account_Right_Detail.Add(rd);
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
        [HttpPost]
        public JsonResult UpdateUser(int ID, string Name, string Username, string Position, string Password, string RepeatPassword,string NVID,
                int module1, int module2, int module3, int module4, int module5, int module6, int module7,
                int module8, int module9, int module10, int module11, int module12, int module13, int module14,
                int module15, int module16, int module19, string rights)
        {
            if (db.Accounts.Where(x => x.Username == Username).Where(y => y.ID != ID).Count() > 0)
            {
                return Json(new Result()
                {
                    CodeError = 2,
                    Data = "Người dùng với tên đăng nhập <strong style='color:black; '>" + Username + "</strong> đã tồn tại!"
                }, JsonRequestBehavior.AllowGet);
            }
            if (!String.IsNullOrEmpty(NVID))
            {
                bool isMaNV = false;
                var MaNV = db.NhanViens.ToList();
                foreach (var item in MaNV)
                {
                    if (NVID.Equals(item.MaNV))
                    {
                        isMaNV = true;
                        break;
                    }
                }
                if (!isMaNV)
                {
                    return Json(new Result()
                    {
                        CodeError = 2,
                        Data = "Mã nhân viên <strong style='color:black; '>" + NVID + "</strong> không tồn tại!"
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                NVID = null;
            }
            string InvalidFields = "";
            if (String.IsNullOrEmpty(Name))
            {
                InvalidFields += "Họ Tên-";
            }
            if (String.IsNullOrEmpty(Username))
            {
                InvalidFields += "Tên đăng nhập-";
            }
            if (String.IsNullOrEmpty(Position))
            {
                InvalidFields += "Chức vụ-";
            }
            if (Password != RepeatPassword)
            {
                InvalidFields += "<br />Mật khảu không khớp !!!";
            }
            if (InvalidFields != "")
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = InvalidFields
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var user = db.Accounts.SingleOrDefault(x => x.ID == ID);
                try
                {
                    var rightsSplit = rights.Split(',');
                    var rightRemove = db.Account_Right_Detail.Where(x => x.AccountID == ID).ToList();
                    foreach (var r in rightRemove)
                    {
                        db.Account_Right_Detail.Remove(r);
                    }
                    db.SaveChanges();
                    foreach (var r in rightsSplit)
                    {
                        if (!String.IsNullOrEmpty(r))
                        {
                            Account_Right_Detail rd = new Account_Right_Detail()
                            {
                                AccountID = ID,
                                RightID = int.Parse(r)
                            };
                            db.Account_Right_Detail.Add(rd);
                        }
                    }
                    db.SaveChanges();
                    updateModule(module1, ID, user.CDVT, 1);
                    updateModule(module2, ID, user.TCLD, 2);
                    updateModule(module3, ID, user.KCS, 3);
                    updateModule(module4, ID, user.DK, 4);
                    updateModule(module5, ID, user.BGD, 5);
                    updateModule(module6, ID, user.PXKT, 6);
                    updateModule(module8, ID, user.PXDL, 8);
                    updateModule(module9, ID, user.PXVT, 9);
                    updateModule(module10, ID, user.PXST, 10);
                    updateModule(module11, ID, user.PXPV, 11);
                    updateModule(module12, ID, user.PXDS, 12);
                    updateModule(module13, ID, user.PXCDM, 13);
                    updateModule(module14, ID, user.PXTGQLM, 14);
                    updateModule(module15, ID, user.PXXD, 15);
                    updateModule(module16, ID, user.PXLT, 16);
                    updateModule(module19, ID, user.AT, 19);
                    if (Convert.ToBoolean(module7).Equals(user.ADMIN))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module7 == 0)
                        {
                            module1 = 0; module2 = 0; module3 = 0; module4 = 0; module5 = 0; module6 = 0; module7 = 0;
                            module8 = 0;module9 = 0;module10 = 0;module11 = 0;module12 = 0;module13 = 0;module14 = 0;
                            module15 = 0;module16 = 0;module19 = 0;
                        }
                        else
                        {
                            module7 = 1;
                            db.SaveChanges();
                        }
                    }
                    user.Name = Name;
                    user.Username = Username;
                    if (String.IsNullOrEmpty(Password))
                    { }
                    else
                    {
                        string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(Password, "pl");
                        user.Password = passXc;
                    }
                    user.Position = Position;
                    user.NVID = NVID;
                    user.CDVT = Convert.ToBoolean(module1);
                    user.TCLD = Convert.ToBoolean(module2);
                    user.KCS = Convert.ToBoolean(module3);
                    user.DK = Convert.ToBoolean(module4);
                    user.BGD = Convert.ToBoolean(module5);
                    user.PXKT = Convert.ToBoolean(module6);
                    user.ADMIN = Convert.ToBoolean(module7);
                    user.PXDL = Convert.ToBoolean(module8);
                    user.PXVT = Convert.ToBoolean(module9);
                    user.PXST = Convert.ToBoolean(module10);
                    user.PXPV = Convert.ToBoolean(module11);
                    user.PXDS = Convert.ToBoolean(module12);
                    user.PXCDM = Convert.ToBoolean(module13);
                    user.PXTGQLM = Convert.ToBoolean(module14);
                    user.PXXD = Convert.ToBoolean(module15);
                    user.PXLT = Convert.ToBoolean(module16);
                    user.AT = Convert.ToBoolean(module19);
                    user.KCM = false;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return Json(new Result()
                    {
                        CodeError = 2,
                        Data = "Có lỗi vui lòng kiểm tra lại!"
                    }, JsonRequestBehavior.AllowGet);
                }
                return Json(new Result()
                {
                    CodeError = 0,
                    Data = "Tài khoản <strong style='color:black;'>" + Username + " </strong> đã được cập nhật thành công cho <strong style='color:black;'>" + Name + "</strong>"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult DeleteUser(string strUIDs)
        {
            try
            {
                var IDs = strUIDs.Split(',');
                foreach (var ID in IDs)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Account_Right_Detail] WHERE Account_Right_Detail.AccountID = '" + ID + "'");
                    db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Account] WHERE Account.ID = '" + ID + "'");
                }
                db.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Có lỗi xảy ra. Vui lòng thử lại", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult ResetPassword(string UserID)
        {

            try
            {
                string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt("123456", "pl");
                int id = int.Parse(UserID);
                var Acc = db.Accounts.Where(x => x.ID == id).SingleOrDefault();
                Acc.Password = passXc;
                db.Entry(Acc).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Reset mật khẩu thành công", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Có lỗi xảy ra !!! Vui lòng thử lại.", JsonRequestBehavior.AllowGet);
            }
        }
    }
    public class CustomUser
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
    public class Rights
    {
        public List<FunctionRight> Accept { get; set; }
        public List<FunctionRight> Deny { get; set; }
    }
    public class RightsDB
    {
        public string ID { get; set; }
        public string Right { get; set; }
    }
    public class RightsWhenCreate
    {
        public List<FunctionRight> Accept { get; set; }
        public List<FunctionRight> Deny { get; set; }
    }
    public class FunctionRight
    {
        public int ID { get; set; }
        public string Right { get; set; }
        public int GroupID { get; set; }
    }
    public class Result
    {
        public int CodeError { get; set; }
        public string Data { get; set; }
    }
    public class rightBasic
    {
        public string ID { get; set; }
    }
}