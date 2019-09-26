﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QUANGHANH2.Models
{
    public class ChungChi_detailsDB:ChungChi
    {
        [Required(ErrorMessage = "Không được để trống")]
        new public string TenChungChi { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public string ThoiHan { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        new public string KieuChungChi { get; set; }
    }
}