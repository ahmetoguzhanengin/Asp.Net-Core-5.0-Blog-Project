using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            NameCall();//İsim için cagırma
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
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
    }
    
}
