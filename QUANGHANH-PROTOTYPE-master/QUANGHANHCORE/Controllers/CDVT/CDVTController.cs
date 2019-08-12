using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QUANGHANHCORE.Controllers.CDVT
{
    public class CDVTController : Controller
    {
        // GET: /<controller>/
        [Route("CDVT")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
