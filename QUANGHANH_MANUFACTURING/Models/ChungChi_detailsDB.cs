using System;
using System.ComponentModel.DataAnnotations;

namespace QUANGHANH_MANUFACTURING.Models
{
    public class ChungChi_detailsDB:ChungChi
    {
        new public int MaChungChi { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public string TenChungChi { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public Nullable<int> ThoiHan { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public string KieuChungChi { get; set; }
    }
}