using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh
{
    public class CaitienController : Controller
    {
        [Auther(RightID = "30")]
        [Route("phong-cdvt/quyet-dinh/cai-tien")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Quyet_dinh/Quyet_dinh_cai_tien.cshtml");
        }

        [Route("phong-cdvt/quyet-dinh/cai-tien")]
        [HttpPost]
        public ActionResult Update(int documentary_id, string date_created, string person_created, string reason, string out_in_come)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();

            if (String.IsNullOrEmpty(date_created) || String.IsNullOrEmpty(person_created) || String.IsNullOrEmpty(out_in_come) || String.IsNullOrEmpty(reason))
            {
                return Json(new { success = false, message = "Không được bỏ trống" });
            }
            else
            {
                try
                {
                    Documentary documentary = DBContext.Documentaries.Where(a => a.documentary_id == documentary_id).First();
                    if (documentary != null)
                    {
                        documentary.date_created = DateTime.Parse(date_created);
                        documentary.person_created = person_created;
                        documentary.reason = reason;
                        documentary.out_in_come = out_in_come;

                    }
                    DBContext.SaveChanges();
                    return Json(new { success = true, message = "Cập nhật thành công" });
                }
                catch
                {
                    return Json(new { success = false, message = "Có lỗi xảy ra" });
                }
            }
        }

        [Route("phong-cdvt/quyet-dinh/cai-tien/update")]
        public ActionResult UpdateID(int documentary_id, string documentary_code, string date_created, string person_created, string reason, string out_in_come)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();

            Documentary i = DBContext.Documentaries.Find(documentary_id);

            if (String.IsNullOrEmpty(documentary_code))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường mã quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }
            else if (String.IsNullOrEmpty(date_created))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường mã quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }
            else if (String.IsNullOrEmpty(person_created))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường người lập quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }
            else if (String.IsNullOrEmpty(reason))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường lý do quyết định là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }

            if (String.IsNullOrEmpty(out_in_come))
            {
                return Json(new
                {
                    success = false,
                    message = "Trường nguồn vốn là trường bắt buộc có"
                }, JsonRequestBehavior.AllowGet);
            }

            else
            {
                try
                {
                    var query = (from x in DBContext.Documentaries
                                 where x.documentary_code == documentary_code
                                 select x).First();
                    return Json(new
                    {
                        success = false,
                        message = "Mã số quyết định đã tồn tại"
                    }, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    using (DbContextTransaction transaction = DBContext.Database.BeginTransaction())
                    {
                        try
                        {
                            List<Documentary_maintain_details> details = DBContext.Documentary_maintain_details.Where(x => x.documentary_id == documentary_id).ToList();
                            foreach (Documentary_maintain_details item in details)
                            {
                                Equipment e = DBContext.Equipments.Find(item.equipmentId);
                                e.current_Status = 5;
                            }
                            documentary_code = documentary_code.Replace(" ", String.Empty);
                            i.documentary_code = documentary_code;
                            i.date_created = DateTime.Parse(date_created);
                            i.person_created = person_created;
                            i.reason = reason;
                            i.out_in_come = out_in_come;
                            DBContext.SaveChanges();
                            transaction.Commit();
                            return Json(new
                            {
                                success = true,
                            }, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return Json(new
                            {
                                success = false,
                                message = "Có lỗi xảy ra"
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
        }
    }
}