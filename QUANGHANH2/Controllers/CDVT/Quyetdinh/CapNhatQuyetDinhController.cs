using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANGHANH2.Controllers.CDVT.Quyetdinh
{
    public class CapNhatQuyetDinhController : Controller
    {
        [Route("phong-cdvt/quyet-dinh/update")]
        [HttpPost]
        public ActionResult Update()
        {
            try
            {
                int documentary_id = int.Parse(Request["documentary_id"]);
                string documentary_code = Request["documentary_code"];
                string reason = Request["reason"];
                string out_in_come = Request["out_in_come"];
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Documentary doc = db.Documentaries.Find(documentary_id);
                    doc.documentary_code = documentary_code == "" ? null : documentary_code;
                    doc.reason = reason;
                    doc.out_in_come = out_in_come;
                    db.SaveChanges();
                }
                return Json(new { success = true, message = "Cập nhật thành công" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }

        [Route("phong-cdvt/quyet-dinh/delete")]
        [HttpPost]
        public ActionResult Delete()
        {
            try
            {
                int documentary_id = int.Parse(Request["documentary_id"]);
                using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
                {
                    Documentary doc = db.Documentaries.Find(documentary_id);
                    if (doc == null)
                        return Json(new { success = false, message = "Mã quyết định không tồn tại" });
                 
                    if (doc.documentary_code != null)
                        return Json(new { success = false, message = "Bạn không được xóa quyết định này" });

                    db.Documentaries.Remove(doc);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Xóa thành công" });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Có lỗi xảy ra" });
            }
        }
    }
}