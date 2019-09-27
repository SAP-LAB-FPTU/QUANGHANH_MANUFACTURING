using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class ChungChi_NhanVien_Model : ChungChi_NhanVien
    {
        [Required(ErrorMessage = "Không được để trống")]
        new public string SoHieu { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public Nullable<System.DateTime> NgayCap { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public string MaNV { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public int MaChungChi { get; set; }
        public string TenNV { get; set; }
        public string TenChungChi { get; set; }

        public string isConHan { get; set; }
        public int? SoNgay { get; set; }
    }
}