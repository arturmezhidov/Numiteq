﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Numiteq.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NumberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}