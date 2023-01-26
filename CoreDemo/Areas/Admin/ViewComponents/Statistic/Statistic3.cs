using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userCount = c.Users.Count().ToString();
            var contactCount = c.Contacts.Count().ToString();
            var categoryCount = c.Categories.Count().ToString();


            ViewBag.v1 = userCount;
            ViewBag.v2 = contactCount;
            ViewBag.v3 = categoryCount;
          

            return View();
        }

    }
}
