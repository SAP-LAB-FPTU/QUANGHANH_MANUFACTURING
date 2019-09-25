using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                    ID = s.ID+"",
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
        [HttpPost]
        public JsonResult AddNewUser(string Name, string Username, string Position, string Password, string RepeatPassword,
    int module1, int module2, int module3, int module4, int module5, int module6, int module7, string rights)
        {
            if (db.Accounts.Where(x => x.Username == Username).Count() > 0)
            {
                return Json(new Result()
                {
                    CodeError = 2,
                    Data = "Người dùng với tên đăng nhập <strong style='color:black; '>" + Username + "</strong> đã tồn tại!"
                }, JsonRequestBehavior.AllowGet);
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
                //var listRightBasic = db.Database.SqlQuery<rightBasic>("select a.ID from Account_Right a where a.isBasic = '1' and a.ModuleID='1'").ToList<rightBasic>();
                string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt(Password, "pl");
                using (DbContextTransaction trans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Account a = new Account()
                        {
                            Name = Name,
                            Username = Username,
                            Password = Password,
                            Position = Position,
                            CDVT = Convert.ToBoolean(module1),
                            TCLD = Convert.ToBoolean(module2),
                            KCS = Convert.ToBoolean(module3),
                            DK = Convert.ToBoolean(module4),
                            BGD = Convert.ToBoolean(module5),
                            PXKT = Convert.ToBoolean(module6)
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
                                    AccountID = acc.ID+"",
                                    RightID = int.Parse(r)
                                };
                                db.Account_Right_Detail.Add(rd);
                            }
                        }
                        db.SaveChanges();
                        if (module1 == 1)
                        {
                            var listRight = db.Account_Right.Where(x => x.ModuleID == 1 + "").ToList();
                            var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + acc.ID + "' and a.ModuleID='1'").ToList<Account_Right_Detail>();
                            foreach (var r in rightRemove)
                            {
                                var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                                db.Account_Right_Detail.Remove(del);
                            }
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                        if (module2 == 1)
                        {
                            var listRight = db.Account_Right.Where(x => x.ModuleID == 2 + "").ToList();
                            var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + acc.ID + "' and a.ModuleID='2'").ToList<Account_Right_Detail>();
                            foreach (var r in rightRemove)
                            {
                                var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                                db.Account_Right_Detail.Remove(del);
                            }
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                        if (module3 == 1)
                        {
                            var listRight = db.Account_Right.Where(x => x.ModuleID == 3 + "").ToList();
                            var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + acc.ID + "' and a.ModuleID='3'").ToList<Account_Right_Detail>();
                            foreach (var r in rightRemove)
                            {
                                var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                                db.Account_Right_Detail.Remove(del);
                            }
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                        if (module4 == 1)
                        {
                            var listRight = db.Account_Right.Where(x => x.ModuleID == 4 + "").ToList();
                            var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + acc.ID + "' and a.ModuleID='4'").ToList<Account_Right_Detail>();
                            foreach (var r in rightRemove)
                            {
                                var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                                db.Account_Right_Detail.Remove(del);
                            }
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                        if (module5 == 1)
                        {
                            var listRight = db.Account_Right.Where(x => x.ModuleID == 5 + "").ToList();
                            var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + acc.ID + "' and a.ModuleID='5'").ToList<Account_Right_Detail>();
                            foreach (var r in rightRemove)
                            {
                                var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                                db.Account_Right_Detail.Remove(del);
                            }
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                        if (module6 == 1)
                        {
                            var listRight = db.Account_Right.Where(x => x.ModuleID == 6 + "").ToList();
                            var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + acc.ID + "' and a.ModuleID='6'").ToList<Account_Right_Detail>();
                            foreach (var r in rightRemove)
                            {
                                var del = db.Account_Right_Detail.Where(x => x.ID == r.ID).SingleOrDefault();
                                db.Account_Right_Detail.Remove(del);
                            }
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                        if (module7 == 1)
                        {
                            var listRight = db.Account_Right.ToList();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID + ""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = acc.ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            var user = db.Accounts.SingleOrDefault(x => x.ID == acc.ID);
                            user.Name = Name;
                            user.Username = Username;
                            user.Password = Password;
                            user.Position = Position;
                            user.CDVT = true;
                            user.TCLD = true;
                            user.KCS = true;
                            user.DK = true;
                            user.BGD = true;
                            user.PXKT = true;
                            user.ADMIN = true;
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
        [HttpPost]
        public JsonResult UpdateUser(int ID, string Name, string Username, string Position, string Password, string RepeatPassword,
            int module1, int module2, int module3, int module4, int module5, int module6, int module7, string rights)
        {
            if (db.Accounts.Where(x => x.Username == Username).Where(y => y.ID != ID).Count() > 0)
            {
                return Json(new Result()
                {
                    CodeError = 2,
                    Data = "Người dùng với tên đăng nhập <strong style='color:black; '>" + Username + "</strong> đã tồn tại!"
                }, JsonRequestBehavior.AllowGet);
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
                    var rightRemove = db.Account_Right_Detail.Where(x => x.AccountID == ID + "").ToList();
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
                                AccountID = ID + "",
                                RightID = int.Parse(r)
                            };
                            db.Account_Right_Detail.Add(rd);
                        }
                    }
                    db.SaveChanges();
                    if (Convert.ToBoolean(module1).Equals(user.CDVT))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.Where(x => x.ModuleID == 1 + "").ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='1'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module1 == 0)
                        { }
                        else
                        {
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                    if (Convert.ToBoolean(module2).Equals(user.TCLD))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.Where(x => x.ModuleID == 2 + "").ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='2'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module2 == 0)
                        { }
                        else
                        {
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                    if (Convert.ToBoolean(module3).Equals(user.KCS))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.Where(x => x.ModuleID == 3 + "").ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='3'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module3 == 0)
                        { }
                        else
                        {
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                    if (Convert.ToBoolean(module4).Equals(user.DK))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.Where(x => x.ModuleID == 4 + "").ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='4'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module4 == 0)
                        { }
                        else
                        {
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                    if (Convert.ToBoolean(module5).Equals(user.BGD))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.Where(x => x.ModuleID == 5 + "").ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='5'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module5 == 0)
                        { }
                        else
                        {
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                    if (Convert.ToBoolean(module6).Equals(user.PXKT))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.Where(x => x.ModuleID == 6 + "").ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("select ar.* from Account_Right a , Account_Right_Detail ar where a.ID = ar.RightID and ar.AccountID='" + ID + "' and a.ModuleID='6'").ToList<Account_Right_Detail>();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module6 == 0)
                        { }
                        else
                        {
                            db.SaveChanges();
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID+""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
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
                            module1 = 0;module2 = 0;module3 = 0;module4 = 0;module5 = 0; module6 = 0;module7 = 0;
                        }
                        else
                        {
                            foreach (var r in listRight)
                            {
                                if (!String.IsNullOrEmpty(r.ID + ""))
                                {
                                    Account_Right_Detail rd = new Account_Right_Detail()
                                    {
                                        AccountID = ID + "",
                                        RightID = r.ID
                                    };
                                    db.Account_Right_Detail.Add(rd);
                                }
                            }
                            db.SaveChanges();
                            module1 = 1;
                            module2 = 1;
                            module3 = 1;
                            module4 = 1;
                            module5 = 1;
                            module6 = 1;
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
                        user.Password = Password;
                    }
                    user.Position = Position;
                    user.CDVT = Convert.ToBoolean(module1);
                    user.TCLD = Convert.ToBoolean(module2);
                    user.KCS = Convert.ToBoolean(module3);
                    user.DK = Convert.ToBoolean(module4);
                    user.BGD = Convert.ToBoolean(module5);
                    user.PXKT = Convert.ToBoolean(module6);
                    user.ADMIN = Convert.ToBoolean(module7);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch(Exception)
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
                        db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Account_Right_Detail] WHERE Account_Right_Detail.AccountID = '"+ID+"'");
                        db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Account] WHERE Account.ID = '"+ID+"'");
                    }
                    db.SaveChanges();
                    return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult ResetPassword(string UserID)
        {
            try
            {
                string passXc = new XCryptEngine(XCryptEngine.AlgorithmType.MD5).Encrypt("123456", "pl");
                var Acc = db.Accounts.Where(x => x.ID == int.Parse(UserID)).SingleOrDefault();
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