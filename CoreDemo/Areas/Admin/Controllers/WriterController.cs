using BusinessLayer.Concrete;
using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

        public IActionResult Index()
        {
            NameCall();
            return View();
        }
        public IActionResult WriterList()
        {
            NameCall();

            var jsonWriters = JsonConvert.SerializeObject(writers);

            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerid)
        {
            NameCall();
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);

            var jsonWriters = JsonConvert.SerializeObject(findWriter);

            return Json(jsonWriters);

        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            NameCall();
            writers.Add(w);

            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);

        }
        public IActionResult DeleteWriter(int id)
        {
            NameCall();
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            NameCall();
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }


        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "Ayşe"

            },
            new WriterClass
            {
                Id = 2,
                Name = "Ahmet"

            },
            new WriterClass
            {
                Id = 3,
                Name = "Buse"

            }
        };

        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> AdminWriterEditProfile()
        {
            NameCall();

            //Context c = new Context();
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var id = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var values = userManager.TGetById(id);

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AdminUserUpdateViewModel model = new AdminUserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;
            return View(model);
        }
        [Area("Admin")]
        //Admin Writer düzenleme kısmı
        [HttpPost]
        public async Task<IActionResult> AdminWriterEditProfile(AdminUserUpdateViewModel model, Writer p)
        {
            //WriterValidator wl = new WriterValidator();
            //ValidationResult results = wl.Validate(p);
            //if (results.IsValid)
            //{
            //}
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.mail;
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            // values.UserName = model.username;

            //Writer about denemesi
            //Context c = new Context();
            //var Username = User.Identity.Name;
            //var Userid = c.Users.Where(x => x.UserName == Username).Select(y => y.Id).FirstOrDefault();
            //var Usermail = c.Users.Where(x => x.UserName == Username).Select(y => y.Email).FirstOrDefault();
            //var Writerid = c.Writers.Where(x => x.WriterMail ==Usermail).Select(y => y.WriterID).FirstOrDefault();
            //var WriterAbout = c.Writers.Where(x=>x.WriterID == Userid).Select(y => y.WriterAbout).FirstOrDefault();
            //WriterAbout = model.writerabout;
            //

            return RedirectToAction("Index", "Dashboard");

            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }



    }

}



