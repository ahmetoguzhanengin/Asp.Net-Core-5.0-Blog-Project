using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userId = c.Users.Where(x => x.UserName == userName).Select(y => y.Id).FirstOrDefault();
            var messageCount = c.Message2s.Where(x => x.ReceiverID == userId).Count();

            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = messageCount;
            ViewBag.v3 = c.Comments.Count();

            string api = "2b264cc6f88b3b89e9780f4f5ce7da87";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;

            XDocument document = XDocument.Load(connection);
            ViewBag.v4=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
