using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Auth_Forms.Models;

namespace Auth_Forms.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        // GET: Item
        private UserContext context = new UserContext();

        public ActionResult Index()
        {
            string email = User.Identity.Name;
            List<Item> items = (from x in context.Items where x.Email == email select x).ToList();
         
            return View(items);
        }

       
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        
        public ActionResult Create(Item item)
        {
            string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
            string extension = Path.GetExtension(item.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            item.ImagePath = "~/images/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            item.ImageFile.SaveAs(fileName);
            
            var context = new UserContext();

            item.Email = User.Identity.Name;
            context.Items.Add(item);
            context.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var context = new UserContext();
            var i = context.Items.FirstOrDefault(x=>x.Id==id);
            context.Items.Remove(i);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var context = new UserContext();
            var i = context.Items.FirstOrDefault(x => x.Id == id);
            return View(i);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            var context = new UserContext();
            var i = context.Items.FirstOrDefault(x => x.Id == item.Id);
            if (i != null)
            {

                if (item.ItemName!=i.ItemName)
                {
                    i.ItemName = item.ItemName;
                }
                else
                {
                    i.ItemName = i.ItemName;
                }
                if (item.Description!=i.Description)
                {
                    i.Description = item.Description;
                }
                else
                {
                    i.Description = i.Description;
                }
                
                if (item.Price!=i.Price)
                {
                    i.Price = item.Price;
                }
                else
                {
                    i.Price = i.Price;
                }
                i.Email = User.Identity.Name;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var context = new UserContext();
            var item = context.Items.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        
    }
}