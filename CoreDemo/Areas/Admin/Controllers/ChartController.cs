using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ChartController : Controller
    {
        public void NameCall()//İsim cagırmak ıcın
        {
            //isim getirme için
            Context c = new Context();
            var NavUsername = User.Identity.Name;
            var NavUserid = c.Users.Where(x => x.UserName == NavUsername).Select(y => y.Id).FirstOrDefault();
            var NavUsermail = c.Users.Where(x => x.UserName == NavUsername).Select(y => y.Email).FirstOrDefault();
            var NavWriterid = c.Writers.Where(x => x.WriterMail == NavUsermail).Select(y => y.WriterID).FirstOrDefault();
            var NavUserName = c.Writers.Where(x => x.WriterID == NavWriterid).Select(y => y.WriterName).FirstOrDefault();
            var NavDateNow = DateTime.Now.ToString("dd-MMM-yyyy");

            ViewBag.v1 = NavUserName;
            ViewBag.v2 = NavDateNow;//
        }
        public IActionResult Index()
        {
            NameCall();//İsim için cagırma
            return View();
        }
        
        public IActionResult CategoryChart()
        {
            NameCall();//İsim için cagırma
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass 
            { categoryname = "Teknoloji",
              categorycount = 10 
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 14
            }); 
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sinema",
                categorycount = 2
            });
            return Json(new { jsonlist = list});
        }
    }
}
