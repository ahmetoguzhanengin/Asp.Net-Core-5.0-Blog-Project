using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.ExtendedProperties;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }
        public void NameCall()
        {
            //isim getirme için
            Context c = new Context();
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

        public IActionResult InBox()
        {
            NameCall();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            NameCall();
            var value = mm.TGetById(id);

            return View(value);
        }
        public IActionResult SendBox()
        {
            NameCall();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendboxListByWriter(writerID);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()//Async metoda cevrildi
        {
            NameCall();
            //KUllanıcıları DropDown'a Çektiğimiz Alan            
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Email.ToString(),
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            //Burası Yukarıde Çektiğimiz Verileri Front-End Tarafına Taşıyoruz.
            ViewBag.RecieverUser = recieverUsers;//sonradan eklendi
     
 
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
         //   p.ReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("InBox");
        }

    }
}
