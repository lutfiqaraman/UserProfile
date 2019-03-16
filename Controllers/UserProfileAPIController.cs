using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UserProfileAPIDemo.DAL;
using UserProfileAPIDemo.Models;

namespace UserProfileAPIDemo.Controllers
{
    public class UserProfileAPIController : ApiController
    {
        private UserProfileContext db = new UserProfileContext();

        // GET: api/UserProfileAPI
        public IQueryable<UserProfile> GetUserProfile()
        {
            return db.UserProfile;
        }

        // GET: api/UserProfileAPI/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult GetUserProfile(int id)
        {
            UserProfile userProfile = db.UserProfile.Find(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Json(userProfile);
        }

        // PUT: api/UserProfileAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserProfile(int id, UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(userProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserProfileAPI
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult PostUserProfile(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfile.Add(userProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userProfile.Id }, userProfile);
        }

        // DELETE: api/UserProfileAPI/5
        [ResponseType(typeof(UserProfile))]
        public IHttpActionResult DeleteUserProfile(int id)
        {
            UserProfile userProfile = db.UserProfile.Find(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            db.UserProfile.Remove(userProfile);
            db.SaveChanges();

            return Ok(userProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserProfileExists(int id)
        {
            return db.UserProfile.Count(e => e.Id == id) > 0;
        }
    }
}