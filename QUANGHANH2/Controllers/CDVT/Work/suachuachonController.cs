using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace QUANGHANHCORE.Controllers.CDVT.Work
{
    public class suachuachonController : Controller
    {
        [Route("phong-cdvt/sua-chua-chon")]
        [HttpGet]
        public ActionResult Index()
        {
            return View("/Views/CDVT/Work/suachuachon.cshtml");
        }

        //public ActionResult GetID(List<String> idCarSelect)
        //{
        //    return GetData(idCarSelect);
        //}

        [Route("phong-cdvt/sua-chua-chon")]
        [HttpPost]
        public ActionResult GetData()
        {
            var listSelected = HttpContext.Request.Cookies["SuaChuaThietBi"].Value;
            var listConvert = JsonConvert.DeserializeObject<List<String>>(listSelected);
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                var result = db.Equipments.Where(s => listConvert.Contains(s.equipmentId)).ToList();
                var js = Json(new { success = true, data = result });
                ViewBag.hihi = new JavaScriptSerializer().Serialize(js.Data);

                return js;
            }

        }
    }
}