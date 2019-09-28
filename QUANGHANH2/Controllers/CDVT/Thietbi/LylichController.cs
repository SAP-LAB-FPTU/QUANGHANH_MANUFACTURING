﻿using QUANGHANH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace QUANGHANHCORE.Controllers.CDVT
{

    public class LylichController : Controller
    {
        [HttpGet]
        [Route("phong-cdvt/thiet-bi")]
        public ActionResult Index()
        {
            return Redirect("/phong-cdvt/huy-dong");
        }

        [Route("phong-cdvt/thiet-bi")]
        [HttpPost]
        public ActionResult ABC(string id)
        {
            QUANGHANHABCEntities DBContext = new QUANGHANHABCEntities();
            //NK su co
            var years = DBContext.Database.SqlQuery<int>("SELECT distinct year(i.start_time) as years FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' order by years desc").ToList();
            List<IncidentByYear> listbyyear = new List<IncidentByYear>();
            foreach (int year in years)
            {
                int count = 0;
                IncidentByYear tempyear = new IncidentByYear();
                List<IncidentByDate> listbydate = new List<IncidentByDate>();
                var dates = DBContext.Database.SqlQuery<DateTime>("SELECT distinct i.start_time as dates FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' and year(start_time) = '" + year + "' order by dates desc").ToList();
                foreach (DateTime date in dates)
                {
                    IncidentByDate tempdate = new IncidentByDate();
                    tempdate.date = date;
                    tempdate.incidents = DBContext.Database.SqlQuery<IncidentDB>("SELECT d.department_name, " +
                        "i.* FROM Incident i inner join Equipment e on e.equipmentId = i.equipmentId inner join Department d " +
                        "on d.department_id = i.department_id where i.end_time is not null and e.equipmentId = '" + id + "' and start_time = '" + date + "' and year(start_time) = '" + year + "' order by start_time desc").ToList();
                    count += tempdate.incidents.Count;
                    listbydate.Add(tempdate);
                }
                tempyear.year = year;
                tempyear.IncidentByDates = listbydate;
                tempyear.count = count;
                listbyyear.Add(tempyear);
            }
            ViewBag.incidents = listbyyear;
            var equipment = DBContext.Database.SqlQuery<Equipment>("SELECT * FROM Equipment WHERE Equipment.equipmentId = '" + id + "'").First();
            ViewBag.equipment = equipment;
            //NK dieu dong
            var yearDD = DBContext.Database.SqlQuery<int>("SELECT distinct year(d.date_created) as years FROM Documentary d, Documentary_moveline_details dm, Equipment e where e.equipmentId = '" + id + "' and e.equipmentId = dm.equipmentId and dm.documentary_id = d.documentary_id order by years desc").ToList<int>();
            List<moveLineByYear> listDD = new List<moveLineByYear>();
            foreach (int year in yearDD)
            {
                List<myMoveline> listMML = DBContext.Database.SqlQuery<myMoveline>("select dm.equipmentId, dm.date_to,dm.department_detail,d.department_id,d.person_created,dm.documentary_id,d.reason,d.date_created from Equipment e, Documentary_moveline_details dm, Documentary d where e.equipmentId = dm.equipmentId and d.documentary_id = dm.documentary_id and dm.equipmentId = '" + id + "' and YEAR(d.date_created) = '" + year + "' ").ToList();
                moveLineByYear MLY = new moveLineByYear();
                foreach (var x in listMML)
                {
                    string s = toStringDate(x.date_created);
                    x.date = s;
                }
                MLY.listmoveline = listMML;
                MLY.year = year;
                MLY.count = listMML.Count();
                listDD.Add(MLY);
            }
            ViewBag.listDD = listDD;
            //NK sua chua
            var yearSC = DBContext.Database.SqlQuery<int>("select distinct YEAR(d.date_created) as years from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = '" + id + "' order by years desc").ToList<int>();
            List<repairByYear> listSC = new List<repairByYear>();
            foreach (int year in yearSC)
            {
                repairByYear rby = new repairByYear();
                List<myRepair> listrp = new List<myRepair>();
                var docID = DBContext.Database.SqlQuery<int>("select distinct d.documentary_id from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = '" + id + "'  and YEAR(d.date_created) = '"+year+"'").ToList<int>();
                foreach (int doc in docID)
                {
                    myRepair rp = DBContext.Database.SqlQuery<myRepair>("select dr.*,d.date_created from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = '" + id + "' and dr.documentary_id = '" + doc + "'").FirstOrDefault();
                    List<mySup_Doc> listTT = DBContext.Database.SqlQuery<mySup_Doc>("select sd.*,s.unit,s.supply_name from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = '" + id + "' and dr.documentary_id = '" + doc + "'and sd.supplyType = '0'  and YEAR(d.date_created) = '" + year + "'").ToList();
                    List<mySup_Doc> listTH = DBContext.Database.SqlQuery<mySup_Doc>("select sd.*,s.unit,s.supply_name from Documentary d, Documentary_repair_details dr, Supply s, Supply_Documentary_Equipment sd where sd.equipmentId = dr.equipmentId and dr.documentary_id = d.documentary_id and sd.supply_id = s.supply_id and sd.documentary_id = d.documentary_id and sd.equipmentId = '" + id + "' and dr.documentary_id = '" + doc + "'and sd.supplyType = '1'  and YEAR(d.date_created) = '" + year + "'").ToList();
                    rp.rowCount = listTH.Count();
                    if (listTT.Count() > listTH.Count())
                    {
                        rp.rowCount = listTT.Count();
                    }
                    List<mySupply> listsp = new List<mySupply>();
                    for (int i = 0; i < rp.rowCount; i++)
                    {
                        mySupply mp = new mySupply();
                        try
                        {
                            mp.VTTT = listTT.ElementAt(i);
                        }
                        catch (Exception e)
                        {
                            mp.VTTT = new mySup_Doc();
                        }
                        try
                        {
                            mp.VTTH = listTH.ElementAt(i);
                        }
                        catch (Exception e)
                        {
                            mp.VTTH = new mySup_Doc();
                        }
                        if(i == 0)
                        {
                            mp.flag = 0;
                        }
                        else
                        {
                            mp.flag = 1;
                        }
                        listsp.Add(mp);
                    }
                    if(rp.equipment_repair_status == 0)
                    {
                        rp.afterStatus = "Tốt";
                    }
                    else
                    {
                        rp.afterStatus = "Chưa được";
                    }
                    rp.listSup = listsp;
                    listrp.Add(rp);
                }
                rby.year = year;
                rby.list = listrp;
                rby.count = listrp.Count();
                listSC.Add(rby);
            }
            ViewBag.listSC = listSC;
            //NK hoat dong
            List<myAct> listHD = DBContext.Database.SqlQuery<myAct>("select a.*,d.department_name from Activity a, Equipment e, Department d where a.equipmentid = e.equipmentId and e.department_id = d.department_id and a.equipmentid = '" + id + "'").ToList();
            foreach(var item in listHD)
            {
                item.status = "Ổn định";
                item.actdate = item.date.ToString("dd/MM/yyyy");
            }
            ViewBag.listHD = listHD;
            //NK tieu thu
            List<myFuel> listFuel = DBContext.Database.SqlQuery<myFuel>("select f.*, d.department_name from Fuel_activities_consumption f, Equipment e, Department d where e.equipmentId = f.equipmentId and e.department_id =  d.department_id and e.equipmentId = '" + id + "' order by f.date desc").ToList();
            foreach (var item in listFuel)
            {
                item.status = "Ổn định";
                item.actdate = item.date.ToString("dd/MM/yyyy");
            }
            ViewBag.listF = listFuel;
            return View("/Views/CDVT/Thietbi/Lylich.cshtml");
        }

        public class myFuel : Fuel_activities_consumption
        {
            public string department_name { get; set; }
            public string actdate { get; set; }
            public string status { get; set; }
            public string note { get; set; }
        }

        public class  myAct : Activity
        {
            public string department_name { get; set; }
            public string actdate { get; set; }
            public string status { get; set; }
            public string note { get; set; }
        }

        public string toStringDate(DateTime date)
        {
            string data = date.ToString("dddd-dd-MM");
            string[] words = data.Split('-');
            string result = "";
            switch (words[0])
            {
                case "Monday": result += "Thứ 2"; break;
                case "Tuesday": result += "Thứ 3"; break;
                case "Wednesday": result += "Thứ 4"; break;
                case "Thursday": result += "Thứ 5"; break;
                case "Friday": result += "Thứ 6"; break;
                case "Saturday": result += "Thứ 7"; break;
                case "Sunday": result += "Chủ nhật"; break;
            }
            result += ", ngày " + words[1] + ", tháng " + words[2];
            return result;
        }


    }

    public class mySup_Doc : Supply_Documentary_Equipment
    {
        public string supply_name { get; set; }
        public string unit { get; set; }
    }

    public class mySupply
    {
        public int flag { get; set; }
        public mySup_Doc VTTT { get; set; }
        public mySup_Doc VTTH { get; set; }
    }

    public class repairByYear
    {
        public List<myRepair> list { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }

    public class myRepair : Documentary_repair_details
    {
        public string afterStatus { get; set; }
        public int rowCount { get; set; }
        public System.DateTime date_created { get; set; }
        public List<mySupply> listSup { get; set; }
    }


    public class moveLineByYear
    {
        public List<myMoveline> listmoveline { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
    public class myMoveline : Documentary_moveline_details
    {
        public string person_created { get; set; }
        public System.DateTime date_created { get; set; }
        public string reason { get; set; }
        public string department_id { get; set; }
        public string date { get; set; }
    }



    public class IncidentByDate
    {
        public List<IncidentDB> incidents { get; set; }
        public DateTime date { get; set; }
    }

    public class IncidentByYear
    {
        public int year { get; set; }
        public List<IncidentByDate> IncidentByDates { get; set; }
        public int count { get; set; }
    }

    public class IncidentDB
    {
        public string equipment_name { get; set; }
        public string equipmentId { get; set; }
        public string department_name { get; set; }
        public DateTime start_time { get; set; }
        public Nullable<DateTime> end_time { get; set; }
        public string reason { get; set; }
        public string incident_type { get; set; }
        public int incident_id { get; set; }
    }
}