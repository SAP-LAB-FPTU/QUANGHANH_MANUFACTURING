
using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq.Dynamic;
using System.Data.Entity;
using QUANGHANH2.SupportClass;
using System.Data.SqlClient;

namespace QUANGHANH2.Controllers.Camera
{
    public class NghiemThuCamController : Controller
    {
        public class Document
        {
            public string documentary_type { get; set; }
            public int documentary_id { get; set; }

            public string equipmentId { get; set; }
            public int countID { get; set; }
        }

        public class Documentary_Extend_Cam : Documentary
        {
            public string tempId { get; set; }
            public string camera_id { get; set; }
            public string camera_name { get; set; }
            public string idAndid { get; set; }
            public bool du_phong { get; set; }
            public bool di_kem { get; set; }
            public bool can { get; set; }
            public string documentary_name { get; set; }

            public string temp { get; set; }
            public Nullable<System.DateTime> acceptance_date { get; set; }
            public int count { get; set; }
            public int cameraStatus { get; set; }
            public LinkIdCode2 linkIdCode { get; set; }
        }


        [Auther(RightID = "194")]
        [Route("camera/nghiem-thu")]
        public ActionResult Index()
        {
            return View("/Views/Camera/Nghiemthu.cshtml");
        }

        [Route("camera/nghiem-thu/search")]
        [HttpPost]
        public ActionResult Search(string document_code, string equiment_id, string equiment_name)
        {
            //Server Side Parameter
            //string requestID = Request["sessionId"];
            //string departID = Session["departID"].ToString();
            string departID = "CDVT";
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = Request["search[value]"];
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];
            List<Documentary_Extend_Cam> docList = new List<Documentary_Extend_Cam>();
            List<Document> documentList = new List<Document>();
            //
            using (QUANGHANHABCEntities db = new QUANGHANHABCEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                if (departID.Contains("PX"))
                {
                    docList = (from a in db.Camera_Acceptance
                               join b in db.Cameras on a.camera_id equals b.camera_id
                               join e in db.Rooms.Where(x => x.department_id.Equals(departID)) on b.room_id equals e.room_id
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.cameraStatus == 2 || a.cameraStatus == 3) && (c.documentary_code.Contains(document_code)) && (a.camera_id.Contains(equiment_id)) && (b.camera_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new
                               {
                                   documentary_id = a.documentary_id,
                                   camera_id = b.camera_id,
                                   camera_name = b.camera_name,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem,
                                   cameraStatus = a.cameraStatus

                               }).ToList().Select(p => new Documentary_Extend_Cam
                               {
                                   documentary_id = p.documentary_id,
                                   camera_id = p.camera_id,
                                   camera_name = p.camera_name,
                                   documentary_code = p.documentary_code,
                                   documentary_type = p.documentary_type,
                                   documentary_name = p.documentary_name,
                                   du_phong = p.du_phong,
                                   di_kem = p.di_kem,
                                   cameraStatus = p.cameraStatus,
                               }).ToList();
                }
                else
                {
                    docList = (from a in db.Camera_Acceptance
                               join b in db.Cameras on a.camera_id equals b.camera_id
                               join e in db.Rooms on b.room_id equals e.room_id
                               join c in db.Documentaries on a.documentary_id equals c.documentary_id
                               where (a.cameraStatus == 3 || a.cameraStatus == 2) && (c.documentary_code.Contains(document_code)) && (a.camera_id.Contains(equiment_id)) && (b.camera_name.Contains(equiment_name))
                               join d in db.DocumentaryTypes on c.documentary_type equals d.documentary_type
                               select new
                               {
                                   documentary_id = a.documentary_id,
                                   camera_id = b.camera_id,
                                   camera_name = b.camera_name,
                                   documentary_code = c.documentary_code,
                                   documentary_type = c.documentary_type,
                                   documentary_name = d.documentary_name,
                                   du_phong = d.du_phong,
                                   di_kem = d.di_kem,
                                   can = d.can,
                                   cameraStatus = a.cameraStatus

                               }).ToList().Select(p => new Documentary_Extend_Cam
                               {
                                   documentary_id = p.documentary_id,
                                   camera_id = p.camera_id,
                                   camera_name = p.camera_name,
                                   documentary_code = p.documentary_code,
                                   documentary_type = p.documentary_type,
                                   documentary_name = p.documentary_name,
                                   du_phong = p.du_phong,
                                   di_kem = p.di_kem,
                                   can = p.can,
                                   cameraStatus = p.cameraStatus
                               }).ToList();
                }

                foreach (Documentary_Extend_Cam item in docList)
                {
                    item.temp = item.documentary_id + "^" + item.documentary_code;
                }


                foreach (Documentary_Extend_Cam items in docList)
                {
                    items.idAndid = items.camera_id + "^" + items.documentary_id + "^" + items.cameraStatus;
                    items.linkIdCode = new LinkIdCode2();
                    switch (items.documentary_type)
                    {
                        case 1:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 2:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 3:
                            items.linkIdCode.link = "vat-tu-kem-theo";
                            break;
                        case 4:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 5:
                            items.linkIdCode.link = "vat-tu";
                            break;
                        case 6:
                            items.linkIdCode.link = "vat-tu";
                            break;
                    }
                    items.linkIdCode.code = items.camera_id;
                    items.linkIdCode.id = items.camera_id;
                    items.linkIdCode.doc = items.documentary_id;
                }




                //docList = db.Documentaries.ToList<Documentary>();
                int totalrows = docList.Count;
                int totalrowsafterfiltering = docList.Count;
                //sorting
                docList = docList.OrderBy(sortColumnName + " " + sortDirection).ToList<Documentary_Extend_Cam>();
                //paging
                docList = docList.Skip(start).Take(length).ToList<Documentary_Extend_Cam>();
                return Json(new { success = true, data = docList, draw = Request["draw"], recordsTotal = totalrows, recordsFiltered = totalrowsafterfiltering }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("camera/nghiem-thu/Edit")]
        public ActionResult Edit(string id, string documentary_code, string documentary_id)
        {
            QUANGHANHABCEntities db = new QUANGHANHABCEntities();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Camera_Acceptance acceptance = db.Camera_Acceptance.Find(id, int.Parse(documentary_id));
                    acceptance.cameraStatus = 2;
                    db.SaveChanges();

                    int acceptanced = db.Database.SqlQuery<Camera_Acceptance>("SELECT * FROM Camera_Acceptance WHERE documentary_id = @documentary_id AND cameraStatus = 2",
                        new SqlParameter("documentary_id", int.Parse(documentary_id))).ToList().Count;

                    int total = db.Database.SqlQuery<Camera_Acceptance>("SELECT * FROM Camera_Acceptance WHERE documentary_id = @documentary_id",
                        new SqlParameter("documentary_id", int.Parse(documentary_id))).ToList().Count;
                    Documentary documentary = db.Documentaries.Find(int.Parse(documentary_id));
                    if (total == acceptanced)
                    {
                        documentary.documentary_status = 3;
                    }
                    Models.Camera equipment = db.Cameras.Find(id);
                    Documentary_camera_repair_details documentary_Repair_Details = db.Database.SqlQuery<Documentary_camera_repair_details>("SELECT * FROM Documentary_camera_repair_details WHERE documentary_id = @documentary_id AND camera_id = @equipmentId",
                        new SqlParameter("equipmentId", id),
                        new SqlParameter("documentary_id", documentary.documentary_id)).First();
                    equipment.camera_status = 2;

                    db.SaveChanges();
                    transaction.Commit();
                    return Json(new { success = true, message = "Nghiệm thu thành công" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    transaction.Rollback();
                    return Json(new { success = false, message = "Nghiệm thu thất bại" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }

}