﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.Controllers
{
 
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            //isim getirme için
            Context c = new Context();
            var username = User.Identity.Name;
            var userid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var UserName = c.Writers.Where(x => x.WriterID == writerid).Select(y => y.WriterName).FirstOrDefault();
            var DateNow = DateTime.Now.ToString("dd-MMM-yyyy");
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerid).Count().ToString();
            ViewBag.v3 = c.Categories.Count().ToString();
            ViewBag.v4 = UserName;
            ViewBag.v5 = DateNow;//
            return View();
        }
    }
}
