using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT.Thietbi
{
    public class NhomthietbiController : Controller
    {
        [Route("phong-cdvt/thiet-bi/nhom")]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Car/Nhomthietbi.cshtml");
        }

        [Route("phong-cdvt/nhom-thiet-bi/dac-tinh/getByID")]
        [HttpPost]
        public ActionResult GetByID()
        {
            string Equipment_category_attribute_id = Request["Equipment_category_attribute_id"];
            if (Equipment_category_attribute_id == "")
                return Json(new { success = false});
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                Equipment_category_attribute attribute = db.Equipment_category_attribute.Find(Equipment_category_attribute_id);
                if (attribute == null)
                    return Json(new { success = false });
                else
                    return Json(new { success = true, name = attribute.Equipment_category_attribute_name, unit = attribute.unit });
            }
        }
    }
}