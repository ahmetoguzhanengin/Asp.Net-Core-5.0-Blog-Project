using BusinessLayer.Concrete;
using BusinessLayer.ValidaitonRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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
        public IActionResult Index(int page = 1)
        {
            NameCall();//İsim için cagırma
            var values = cm.GetList().ToPagedList(page,3);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory() {
            NameCall();//İsim için cagırma
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);

            if (results.IsValid)
            {
                p.CategoryStatus= true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
        public IActionResult CategoryDelete(int id)
        {
            NameCall();//İsim için cagırma
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");

        }
    }
}
