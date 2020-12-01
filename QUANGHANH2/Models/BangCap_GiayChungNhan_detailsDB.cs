//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;

//namespace QUANGHANH2.Models
//{
//    public class BangCap_GiayChungNhan_detailsDB:ChiTiet_BangCap_GiayChungNhan
//    {
//        [Required(ErrorMessage = "Không được để trống")]
//        new public string SoHieu { get; set; }
//        [Required(ErrorMessage = "Không được để trống")]
//        new public int MaBangCap_GiayChungNhan { get; set; }
//        [Required(ErrorMessage = "Không được để trống")]
//        new public Nullable<System.DateTime> NgayCap { get; set; }
//        [Required(ErrorMessage = "Không được để trống")]
//        new public string MaNV { get; set; }
//        new public Nullable<System.DateTime> NgayTra { get; set; }
//        public string TenBangCap { get; set; }
//        public string Ten { get; set; }
//    }
//}