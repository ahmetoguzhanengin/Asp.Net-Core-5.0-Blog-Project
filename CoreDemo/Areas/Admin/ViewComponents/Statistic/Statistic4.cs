using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var nameSurname = c.Users.Where(x => x.UserName == userName).Select(y => y.NameSurname).FirstOrDefault();
            var writerAbout = c.Writers.Where(x => x.WriterID == userId).Select(y => y.WriterAbout).FirstOrDefault();
            var notification = c.Notifications.Count().ToString();
            var adminCount = c.Admins.Count().ToString();
            var roleCount = c.Roles.Count().ToString();
          

            ViewBag.v1 = c.Admins.Where(x => x.AdminID == userId).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminID == userId).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminID == userId).Select(y => y.ShortDescription).FirstOrDefault();
            ViewBag.v4 = nameSurname;
            ViewBag.v5 = userName;
            ViewBag.v6 = userMail;
            ViewBag.v7 = writerAbout;
            ViewBag.v8 = notification;
            ViewBag.v9 = adminCount;
            ViewBag.v10 = roleCount;


            return View();
        }

    }
}
