using BusinessLayer.Concrete;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        Context c = new Context();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public void NameCall()
        {
            //isim getirme için

            var NavUsername = User.Identity.Name;
            var NavUserid = c.Users.Where(x => x.UserName == NavUsername).Select(y => y.Id).FirstOrDefault();
            var NavUsermail = c.Users.Where(x => x.UserName == NavUsername).Select(y => y.Email).FirstOrDefault();
            var NavWriterid = c.Writers.Where(x => x.WriterMail == NavUsermail).Select(y => y.WriterID).FirstOrDefault();
            var NavUserName = c.Writers.Where(x => x.WriterID == NavWriterid).Select(y => y.WriterName).FirstOrDefault();
            var NavDateNow = DateTime.Now.ToString("dd-MMM-yyyy");
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == NavWriterid).Count().ToString();
            ViewBag.v3 = c.Categories.Count().ToString();
            ViewBag.v4 = NavUserName;
            ViewBag.v5 = NavDateNow;//
        }
        //public WriterController(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        [Authorize]
        public IActionResult Index()
        {
            NameCall();
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();

            ViewBag.v2 = writerName;
            return View();
        }
        public IActionResult WriterProfile()
        {
            NameCall();
            return View();
        }

        public IActionResult WriterMail()
        {

            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            NameCall();
            //Orjinal
            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //UserUpdateViewModel model = new UserUpdateViewModel();
            //model.mail = values.Email;
            //model.namesurname = values.NameSurname;
            //model.imageurl = values.ImageUrl;
            //model.username = values.UserName;

            Context c = new Context();
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.username = values.UserName;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            //WriterValidator wl = new WriterValidator();
            //ValidationResult results = wl.Validate(p);
            //if (results.IsValid)
            //{
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
            
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.mail;
            values.UserName = model.username;
            var result = await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");


                //Orjinal hali

            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //values.NameSurname = model.namesurname;
            //values.ImageUrl = model.imageurl;
            //values.Email = model.mail;
            //values.UserName = model.username;
            //values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
            //var result = await _userManager.UpdateAsync(values);



        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd() { 
            NameCall();
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");

        
        }
    }
}
