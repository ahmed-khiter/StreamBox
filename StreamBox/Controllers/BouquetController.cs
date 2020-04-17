using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StreamBox.Controllers
{
    public class BouquetController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

    }
}