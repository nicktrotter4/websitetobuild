﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class webController : Controller
    {
        // GET: web
        public ActionResult TestWebsite()
        {
            return View();
        }
    }
}