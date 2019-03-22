using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserProfileAPIDemo.DAL;
using UserProfileAPIDemo.Models;
using System.IO;
using System.Security.Cryptography;
using System.Data.Entity.Infrastructure;
using System.Text;
using UserProfileAPIDemo.Areas.Common;

namespace UserProfileAPIDemo.Controllers
{
    public class UserProfileController : Controller
    {
        private UserProfileContext db = new UserProfileContext();

        // GET: UserProfile
        public ActionResult Index()
        {
            return View(db.UserProfile.ToList());
        }

        // GET: UserProfile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProfile userProfile = db.UserProfile.Find(id);
            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // GET: UserProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userProfile)
        {
            byte[] salt = PasswordEncryption.GenerateSalt();
            var password = Encoding.UTF8.GetBytes(userProfile.Password);
            string generatedSalt = Convert.ToBase64String(salt);

            var hashedPassword   = PasswordEncryption.HashPasswordWithSalt(password, salt);
            userProfile.Password = Convert.ToBase64String(hashedPassword);


            if (userProfile.Image != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(userProfile.ImageFile.FileName);
                string extension = Path.GetExtension(userProfile.ImageFile.FileName);
                string imageFolderPath = "~/Images/";

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                userProfile.Image = imageFolderPath + fileName;
                fileName = Path.Combine(Server.MapPath(imageFolderPath), fileName);

                userProfile.ImageFile.SaveAs(fileName);
            }


            if (ModelState.IsValid)
            {
                db.UserProfile.Add(userProfile);
                db.SaveChanges();
                ModelState.Clear();

                return RedirectToAction("Index");
            }

            return View(userProfile);
        }

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            UserProfile userProfile = db.UserProfile.Find(id);

            if (userProfile == null)
                return HttpNotFound();

            return View(userProfile);
        }

        // POST: UserProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userProfile)
        {
            byte[] salt = PasswordEncryption.GenerateSalt();
            var password = Encoding.UTF8.GetBytes(userProfile.Password);
            string generatedSalt = Convert.ToBase64String(salt);

            var hashedPassword = PasswordEncryption.HashPasswordWithSalt(password, salt);
            userProfile.Password = Convert.ToBase64String(hashedPassword);

            if (ModelState.IsValid)
            {
                db.Entry(userProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfile);
        }

        // GET: UserProfile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserProfile userProfile = db.UserProfile.Find(id);

            if (userProfile == null)
            {
                return HttpNotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userProfile = db.UserProfile.Find(id);
            db.UserProfile.Remove(userProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
