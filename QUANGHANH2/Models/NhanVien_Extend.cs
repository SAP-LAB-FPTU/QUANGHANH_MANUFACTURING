using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class NhanVien_Extend : NhanVien
    {

        public List<int> MaNhiemVu { get; set; }
        public NhanVien_Extend()
        {
            MaNhiemVu = new List<int>();
        }

    }
}