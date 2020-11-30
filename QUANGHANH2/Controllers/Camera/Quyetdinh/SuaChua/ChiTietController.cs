using Newtonsoft.Json.Linq;
using QUANGHANH2.Models;
using QUANGHANH2.SupportClass;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANH2.Controllers.Camera
{
    public class ChiTietController : Controller
    {
        [Auther(RightID = "193")]
        [Route("phong-cdvt/camera/quyet-dinh/sua-chua/chi-tiet")]
        public ActionResult Index()
        {
            int id = int.Parse(Request["id"]);
            using (QuangHanhManufacturingEntities db = new QuangHanhManufacturingEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                Documentary documentary = db.Documentaries.Find(id);
                if (documentary == null)
                    return Redirect("/phong-cdvt/camera/quyet-dinh/sua-chua");

                ViewBag.documentary_code = documentary.documentary_code;

                var listRooms = (from r in db.Rooms
                                 join d in db.Documentary_camera_repair_details on r.room_id equals d.room_id
                                 join depa in db.Departments on r.department_id equals depa.department_id
                                 where d.documentary_id == id
                                 select new RoomDetail
                                 {
                                     room_id = r.room_id,
                                     room_name = r.room_name,
                                     department_name = depa.department_name,
                                     broken_camera_quantity = d.broken_camera_quantity,
                                     repair_requirement = d.repair_requirement,
                                     note = d.note
                                 }).ToList();
                ViewBag.listRooms = listRooms;

                var listSupplies = (from r in db.Supply_Documentary_Camera
                                    join s in db.Supplies on r.supply_id equals s.supply_id
                                    select new
                                    {
                                        r.room_id,
                                        r.supply_id,
                                        r.quantity_plan,
                                        s.supply_name
                                    }).ToList();

                JObject temp = new JObject();
                foreach (var room in listRooms)
                {
                    JArray list = new JArray();
                    for (int i = 0; i < listSupplies.Count; i++)
                    {
                        var supply = listSupplies[i];
                        if (supply.room_id.Equals(room.room_id))
                        {
                            list.Add(JToken.FromObject(new
                            {
                                supply.supply_id,
                                supply.supply_name,
                                supply.quantity_plan
                            }));
                        }
                    }
                    temp.Add(room.room_id.ToString(), list);
                }
                ViewBag.listSupplies = temp.ToString();
            }
            return View("/Views/Camera/Quyetdinh/SuaChua/ChiTiet.cshtml");
        }

        public class RoomDetail : Documentary_camera_repair_details
        {
            public string room_name { get; set; }
            public string department_name { get; set; }
        }
    }
}