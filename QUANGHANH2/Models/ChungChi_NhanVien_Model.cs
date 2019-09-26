using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class ChungChi_NhanVien_Model:ChungChi_NhanVien
    {
        public string TenNV { get; set; }
        public string TenChungChi { get; set; }

    }
}