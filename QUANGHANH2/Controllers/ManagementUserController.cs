using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using QUANGHANH2.EntityResult;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using XCrypt;

using System.Web.Routing;
using System.Data.Entity.Validation;

namespace QUANGHANH2.Controllers
{
    [Auther(RightID = "0")]
    public class ManagementUserController : Controller
    {
        private QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities();
        // GET: ManagementUser

        public ActionResult Index(string username)
        {
            string depart = Session["departID"].ToString();
            if (Session["Role"].ToString().Equals("1"))
            {
                var employ = (from nv in db.Employees
                              join pb in db.Departments on nv.current_department_id equals pb.department_id
                              select new employ
                              {
                                  id = nv.employee_id,
                                  name = nv.BASIC_INFO_full_name,
                                  pb = pb.department_name
                              }).ToList();
                ViewBag.employ = employ;
            }
            else
            {
                var employ = (from nv in db.Employees
                              join pb in db.Departments on nv.current_department_id equals pb.department_id
                              where nv.current_department_id == depart
                              select new employ
                              {
                                  id = nv.employee_id,
                                  name = nv.BASIC_INFO_full_name,
                                  pb = pb.department_name
                              }).ToList();
                ViewBag.employ = employ;
            }

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
            var users = new List<GetAllAccountInfo_Result>();
            string ts = Session["departID"].ToString();
            if (Session["Role"].ToString().Equals("1"))
            {
                users = db.Database.SqlQuery<GetAllAccountInfo_Result>("Account.GetAllAccountInfo").ToList();
            }
            else
            {
                users = db.Database.SqlQuery<GetAllAccountInfo_Result>("Account.GetAllAccountInfoByDepartmentID {0}",Session["departID"].ToString()).ToList();
            }

            var search = users.ToList();
            int CurrentUser = int.Parse(Session["UserID"].ToString());
            int role_user = int.Parse(Session["Role"].ToString());
            if (CurrentUser != 74)
            {
                search = search.Where(a => a.ID != 74).ToList();
            }
            if (model.search.value != null)
            {
                string searchValue = model.search.value;
                search = search.Where(a => a.Username.ToLower().Contains(searchValue.ToLower()) || a.Name.ToLower().Contains(searchValue.ToLower()) || a.department_name.ToLower().Contains(searchValue.ToLower()) || a.department_id.ToLower().Contains(searchValue.ToLower())).ToList();
            }
            if (model.columns[1].search.value != null)
            {
                string searchValue = model.columns[1].search.value;
                search = search.Where(a => a.Username.Contains(searchValue)).ToList();
            }
            if (model.columns[2].search.value != null)
            {
                string searchValue = model.columns[2].search.value;
                search = search.Where(a => a.Name.Contains(searchValue)).ToList();
            }

            var sorting = search.OrderBy(a => a.department_name);
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
            var result = new List<GetAllAccountInfo_Result>(paging.Count);
            foreach (var s in paging)
            {
                result.Add(new GetAllAccountInfo_Result
                {
                    ID = s.ID,
                    Name = s.Name,
                    Username = s.Username,
                    department_name = s.department_name
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
        public JsonResult getPB(string id)
        {
            var pb = db.Database.SqlQuery<GetDepartmentJobDetailByEmployeeID_Result>("Account.GetDepartmentJobDetailByEmployeeID {0}", id).FirstOrDefault();
            return Json(pb, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRightInModule(string module, int UserID)
        {
            
            if (!UserID.Equals(""))
            {
                Rights rights = new Rights();
                rights.Accept = new List<GetUserFunction_Result>();
                rights.Deny = new List<GetUserFunction_Result>();

                if (UserID == 1)
                {
                    var rightAccept = db.Database.SqlQuery<GetUserFunction_Result>("Account.GetUserAcceptByModuleAndUID {0}, {1}", module,UserID).ToList();
                    foreach (var r in rightAccept)
                    {
                        rights.Accept.Add(new GetUserFunction_Result()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                    var rightDeny = db.Database.SqlQuery<GetUserFunction_Result>("Account.GetUserDenyByModuleAndUID {0} {1}", module, UserID).ToList();
                    foreach (var r in rightDeny)
                    {
                        rights.Deny.Add(new GetUserFunction_Result()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                }
                else
                {
                    var rightAccept = db.Database.SqlQuery<GetUserFunction_Result>("Account.GetUserAcceptByModuleAndUID {0}, {1}", module, UserID).ToList();
                    foreach (var r in rightAccept)
                    {
                        rights.Accept.Add(new GetUserFunction_Result()
                        {
                            ID = r.ID,
                            Right = r.Right,
                            GroupID = r.GroupID
                        });
                    }
                    var rightDeny = db.Database.SqlQuery<GetUserFunction_Result>("Account.GetUserDenyByModuleAndUID {0}, {1}", module, UserID).ToList();
                    foreach (var r in rightDeny)
                    {
                        rights.Deny.Add(new GetUserFunction_Result()
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
                rights.Accept = new List<GetUserFunction_Result>();
                rights.Deny = new List<GetUserFunction_Result>();
                var rightDeny = db.Database.SqlQuery<GetUserFunction_Result>("Account.GetFunctionsByModule {0}", module).ToList();
                foreach (var r in rightDeny)
                {
                    rights.Deny.Add(new GetUserFunction_Result()
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
                var rightRemove = db.Database.SqlQuery<Account_Right_Detail>("Account.GetFunctionsByModuleAndUID {0}, {1}",ID,moduleID).ToList();
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
        public JsonResult AddNewUser(string Name, string Username, string Position, string Password, string RepeatPassword, string NVID,
                int module1, int module2, int module3, int module4, int module5, int module6, int module7,
                int module8, int module9, int module11, int module12, int module13, int module14,
                int module15, int module17, int module18, int module19, int module20, string rights)
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
            if (!String.IsNullOrEmpty(NVID))
            {
                if (db.Employees.Where(x => x.employee_id == NVID).Count() == 0)
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
                InvalidFields += " Mã nhân viên -";
            }
            if (String.IsNullOrEmpty(Name))
            {
                InvalidFields += " Họ Tên -";
            }
            if (String.IsNullOrEmpty(Username))
            {
                InvalidFields += " Tên đăng nhập -";
            }
            if (String.IsNullOrEmpty(Position))
            {
                InvalidFields += " Chức vụ -";
            }
            if (InvalidFields != "")
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = InvalidFields.Substring(0, InvalidFields.Length) + " không được để trống !!!"
                }, JsonRequestBehavior.AllowGet);
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
                    return Json(new Result()
                    {
                        CodeError = 1,
                        Data = "Mật khẩu nhập lại không khớp !!!"
                    }, JsonRequestBehavior.AllowGet);
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
                            Role = 3,
                            CDVT = Convert.ToBoolean(module1),
                            TCLD = Convert.ToBoolean(module2),
                            KCS = Convert.ToBoolean(module3),
                            DK = Convert.ToBoolean(module4),
                            BGD = Convert.ToBoolean(module5),
                            PXKT = Convert.ToBoolean(module6),
                            PXDL = Convert.ToBoolean(module8),
                            PXVT = Convert.ToBoolean(module9),
                            PXPV = Convert.ToBoolean(module11),
                            PXDS = Convert.ToBoolean(module12),
                            PXCDM = Convert.ToBoolean(module13),
                            PXTGQLM = Convert.ToBoolean(module14),
                            PXXD = Convert.ToBoolean(module15),
                            AT = Convert.ToBoolean(module17),
                            PXCKSC = Convert.ToBoolean(module19),
                            KCM = Convert.ToBoolean(module18),
                            PXCBT = Convert.ToBoolean(module20)
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
                        addModule(module11, acc.ID, 11);
                        addModule(module12, acc.ID, 12);
                        addModule(module13, acc.ID, 13);
                        addModule(module14, acc.ID, 14);
                        addModule(module15, acc.ID, 15);
                        addModule(module17, acc.ID, 17);
                        addModule(module18, acc.ID, 18);
                        addModule(module19, acc.ID, 19);
                        addModule(module20, acc.ID, 20);
                        if (module7 == 1)
                        {
                            var user = db.Accounts.SingleOrDefault(x => x.ID == acc.ID);
                            user.Name = Name;
                            user.Username = Username;
                            user.Password = passXc;
                            user.Position = Position;
                            user.Role = 2;
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
                            user.PXPV = false;
                            user.PXDS = false;
                            user.PXCDM = false;
                            user.PXTGQLM = false;
                            user.PXXD = false;
                            user.AT = false;
                            user.KCM = false;
                            user.PXCKSC = false;
                            user.PXCBT = false;
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
                    catch (Exception e)
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
                var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("Account.GetFunctionsByModuleAndUID {0}, {1}",ID,moduleID).ToList();
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
        public JsonResult UpdateUser(int ID, string Name, string Username, string Position, string Password, string RepeatPassword, string NVID,
                int module1, int module2, int module3, int module4, int module5, int module6, int module7,
                int module8, int module9, int module11, int module12, int module13, int module14,
                int module15, int module17, int module18, int module19, int module20, string rights)
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
                var nv = db.Employees.Where(x => x.employee_id.Equals(NVID)).FirstOrDefault();
                if (nv == null)
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
                InvalidFields += " Tên đăng nhập -";
            }
            if (String.IsNullOrEmpty(Position))
            {
                InvalidFields += " Chức vụ -";
            }
            if (InvalidFields != "")
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = InvalidFields.Substring(0, InvalidFields.Length) + " không thể để trống!"
                }, JsonRequestBehavior.AllowGet);
            }
            if (Password != RepeatPassword)
            {
                return Json(new Result()
                {
                    CodeError = 1,
                    Data = "Mật khẩu không khớp!"
                }, JsonRequestBehavior.AllowGet);
            }
            var user = db.Accounts.SingleOrDefault(x => x.ID == ID);
            using (DbContextTransaction trans = db.Database.BeginTransaction())
            {
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
                    updateModule(module11, ID, user.PXPV, 11);
                    updateModule(module12, ID, user.PXDS, 12);
                    updateModule(module13, ID, user.PXCDM, 13);
                    updateModule(module14, ID, user.PXTGQLM, 14);
                    updateModule(module15, ID, user.PXXD, 15);
                    updateModule(module17, ID, user.AT, 17);
                    updateModule(module18, ID, user.KCM, 18);
                    updateModule(module19, ID, Convert.ToBoolean(user.PXCKSC), 19);
                    updateModule(module20, ID, user.PXCBT, 20);
                    if (Convert.ToBoolean(module7).Equals(user.ADMIN))
                    { }
                    else
                    {
                        var listRight = db.Account_Right.ToList();
                        var rightRemoveup = db.Database.SqlQuery<Account_Right_Detail>("Account.GetFunctionsByUID {0}",ID).ToList();
                        foreach (var r in rightRemoveup)
                        {
                            var del = db.Account_Right_Detail.Where(a => a.ID == r.ID).SingleOrDefault();
                            db.Account_Right_Detail.Remove(del);
                        }
                        if (module7 == 0)
                        {
                            module1 = 0; module2 = 0; module3 = 0; module4 = 0; module5 = 0; module6 = 0; module7 = 0;
                            module8 = 0; module9 = 0; module11 = 0; module12 = 0; module13 = 0; module14 = 0;
                            module15 = 0; module17 = 0; module18 = 0; module19 = 0; module20 = 0;
                            user.Role = 3;
                        }
                        else
                        {
                            module7 = 1;
                            user.Role = 2;
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
                    user.PXPV = Convert.ToBoolean(module11);
                    user.PXDS = Convert.ToBoolean(module12);
                    user.PXCDM = Convert.ToBoolean(module13);
                    user.PXTGQLM = Convert.ToBoolean(module14);
                    user.PXXD = Convert.ToBoolean(module15);
                    user.AT = Convert.ToBoolean(module17);
                    user.PXCKSC = Convert.ToBoolean(module19);
                    user.KCM = Convert.ToBoolean(module18);
                    user.PXCBT = Convert.ToBoolean(module20);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    return Json(new Result()
                    {
                        CodeError = 2,
                        Data = "Có lỗi vui lòng kiểm tra lại!"
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new Result()
            {
                CodeError = 0,
                Data = "Tài khoản <strong style='color:black;'>" + Username + " </strong> đã được cập nhật thành công cho <strong style='color:black;'>" + Name + "</strong>"
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteUser(string strUIDs)
        {
            try
            {
                var IDs = strUIDs.Split(',');
                foreach (var ID in IDs)
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Account_Right_Detail] WHERE Account_Right_Detail.AccountID = @accountid", new SqlParameter("accountid", ID));
                    db.Database.ExecuteSqlCommand("delete from User_Action_Log where AccountID = @accountid", new SqlParameter("accountid", ID));
                    db.Database.ExecuteSqlCommand("DELETE FROM [dbo].[Account] WHERE Account.ID = @accountid", new SqlParameter("accountid", ID));
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
        public ActionResult Management()
        {
            List<Module> list = db.Modules.OrderBy(x => x.ID).ToList();
            ViewBag.pb = list;
            return View("/Views/ManagementUser/Roles.cshtml");
        }
        [HttpPost]
        public ActionResult searchRoles(string module, string rights)
        {
            try
            {
                string sql = "";
                if (string.IsNullOrEmpty(module))
                {
                    sql = "select a.ID,a.[Right],m.Module,a.GroupID from Account.Account_Right a, Account.Module m where a.ModuleID=m.ID and a.[Right] like @rights";
                }
                else
                {
                    sql = "select a.ID,a.[Right],m.Module,a.GroupID from Account.Account_Right a, Account.Module m where a.ModuleID=m.ID and a.[Right] like @rights and m.ID = @module";
                }
                int start = Convert.ToInt32(Request["start"]);
                int length = Convert.ToInt32(Request["length"]);
                string searchValue = Request["search[value]"];
                string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
                string sortDirection = Request["order[0][dir]"];
                using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
                {
                    List<Account_Rights> list = db.Database.SqlQuery<Account_Rights>(sql
                        , new SqlParameter("rights", '%' + rights + '%')
                        , new SqlParameter("module", module)
                        ).ToList();

                    int totalrows = list.Count;
                    int totalrowsafterfiltering = list.Count;
                    list = list.OrderBy(sortColumnName + " " + sortDirection).ToList<Account_Rights>();
                    list = list.Skip(start).Take(length).ToList<Account_Rights>();
                    return Json(new { success = true, data = list, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception)
            {
                Response.Write("Có lỗi xảy ra, xin vui lòng nhập lại");
                return new HttpStatusCodeResult(400);
            }
        }
        [HttpPost]
        public ActionResult getEdit(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var obj = db.Account_Right.Where(x => x.ID == id).FirstOrDefault();
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(400);
            }
        }
        public ActionResult EditRoles(int id, string name, int group, int module)
        {
            try
            {
                var role = db.Account_Right.Where(x => x.ID == id).FirstOrDefault();
                role.Right = name;
                role.GroupID = group;
                role.ModuleID = module.ToString();
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(400);
            }
        }
        public ActionResult DeleteRoles(int id)
        {
            try
            {
                var obj = db.Account_Right.Where(x => x.ID == id).FirstOrDefault();
                db.Account_Right.Remove(obj);
                db.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(400);
            }
        }
        public ActionResult AddRoles(string name, int group, int module)
        {
            try
            {
                Account_Right a = new Account_Right();
                a.Right = name;
                a.ModuleID = module.ToString();
                a.GroupID = group;
                db.Account_Right.Add(a);
                db.SaveChanges();
                return Json("", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(400);
            }
        }
    }
    public class Account_Rights
    {
        public int ID { get; set; }
        public string Right { get; set; }
        public string Module { get; set; }
        public int GroupID { get; set; }
    }
    public class Rights
    {
        public List<GetUserFunction_Result> Accept { get; set; }
        public List<GetUserFunction_Result> Deny { get; set; }
    }
    public class RightsWhenCreate
    {
        public List<GetUserFunction_Result> Accept { get; set; }
        public List<GetUserFunction_Result> Deny { get; set; }
    }
    public class Result
    {
        public int CodeError { get; set; }
        public string Data { get; set; }
    }
    public class employ
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pb { get; set; }
    }

}