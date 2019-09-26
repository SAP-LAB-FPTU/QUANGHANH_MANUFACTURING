using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class ChungChi_NhanVien_Model
    {
        [Required(ErrorMessage = "Không để trống")]
        public string SoHieu { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public Nullable<System.DateTime> NgayCap { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public string MaNV { get; set; }
        [Required(ErrorMessage = "Không để trống")]
        public int MaChungChi { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public string TenNV { get; set; }
        public string TenChungChi { get; set; }

    }
}