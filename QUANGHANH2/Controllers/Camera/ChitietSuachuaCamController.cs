using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace QUANGHANH2.Controllers.Camera
{
    public class ChitietSuachuaCamController : Controller
    {
        [HttpGet]
        public ActionResult LoadPage(String id)
        {
            ViewBag.id = id.ToString().Split('^')[0];

            return View("/Views/Camera/Chi_tiet_sua_chua.cshtml");
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public class CameraDetail: Models.Camera
        {
            public string room_name { get; set; }
            public string reason { get; set; }
            public int documentary_id { get; set; }
            public string idAndEquip { get; set; }
        }

        [HttpPost]
        public ActionResult Detail()
        {
            string requestID = Request["sessionId"];
            int id = Int32.Parse(requestID);
            int start = Convert.ToInt32(Request["start"]);
            int length = 10;
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                try
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    string query = "select c.camera_id, c.camera_name, r.room_name, doc.reason, docCam.documentary_id from Documentary_camera_repair_details docCam join " +
                        "Documentary doc on doc.documentary_id = docCam.documentary_id join Camera c on c.camera_id = docCam.camera_id join " +
                        "Room r on r.room_id = c.room_id join Department d on d.department_id = r.department_id where docCam.documentary_id = @requestID";
                    List<CameraDetail> documentariesList = db.Database.SqlQuery<CameraDetail>(query, new SqlParameter("requestID", requestID)).ToList();
                    foreach (var el in documentariesList)
                    {
                        el.idAndEquip = el.documentary_id + "^" + el.camera_id;
                    }
                    int totalrows = documentariesList.Count;
                    int totalrowsafterfiltering = documentariesList.Count;

                    //sorting
                    documentariesList = documentariesList.OrderBy(sortColumnName + " " + sortDirection).ToList<CameraDetail>();
                    //paging

                    documentariesList = documentariesList.Skip(start).Take(length).ToList<CameraDetail>();
                    Console.WriteLine(Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet));

                    var js = Json(new { success = true, data = documentariesList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);

                    var result = new JavaScriptSerializer().Serialize(js.Data);
                    ViewBag.count = 0;
                    return js;
                }catch(Exception e)
                {
                    e.Message.ToString();
                    return null;
                }
            }
        }

        [Route("camera/GetSupply")]
        [HttpPost]
        public ActionResult GetSupply(string documentary_id, string equipmentId)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            List<Supply_Detail> supplies = DBContext.Database.SqlQuery<Supply_Detail>("select s.supply_id, s.supply_name, sdc.quantity_plan, sdc.supplyStatus from Supply_Documentary_Camera sdc join Supply s on sdc.supply_id = s.supply_id where documentary_id = @documentary_id and sdc.camera_id = @equipmentId",
                new SqlParameter("equipmentId", equipmentId),
                new SqlParameter("documentary_id", documentary_id)).ToList();
            int count = supplies.Count;
            if (count == 0)
            {
                return Json(new
                {
                    success = false,
                    data = supplies,
                    message = "Không có vật tư nào!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new
                {
                    success = true,
                    data = supplies
                }, JsonRequestBehavior.AllowGet);

        }
        public class Supply_Detail
        {
            public string supply_id { get; set; }
            public string supply_name { get; set; }
            public int quantity_plan { get; set; }
            public string supplyStatus { get; set; }
        }
    }

   
}