using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crud_dnf.Data;
using crud_dnf.Models;
using EntityState = System.Data.Entity.EntityState;
using System.Collections;

namespace crud_dnf.Controllers
{
    public class UsersController : Controller
    {
        private crud_dnfContext db = new crud_dnfContext();

        // GET: Users
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var users = await db.Users.ToListAsync();
            return Json(users,JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "FirstName,LastName,UserName,Password,EmailPass")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return Json(user);
            }

            return HttpNotFound();
        }

        // PUT: Users/Edit
        [HttpPut]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName,LastName,UserName,Password,EmailPass")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(user);
            }
            return HttpNotFound();
        }

        // DELETE: Users/Delete/5
        [HttpDelete]
        [Route("/Users/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Content("1");
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
