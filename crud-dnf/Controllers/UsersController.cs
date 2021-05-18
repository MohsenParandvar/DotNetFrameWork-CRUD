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
using crud_dnf.DTOs;
using crud_dnf.ModelBinders;
using crud_dnf.Services;
using crud_dnf.Repositories;

namespace crud_dnf.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            var users = new UserRepository();
            return Json(users.GetUsers(), JsonRequestBehavior.AllowGet);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = new UserRepository().GetUserDetails(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        
        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(CreateUser user)
        {
            if (ModelState.IsValid)
            {
                new UserRepository().UserCreate(user);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return HttpNotFound();
        }
        
        // PUT: Users/Edit
        [HttpPut]
        [Route("/Users/Edit/{id}")]
        public ActionResult Edit(int id,EditUser user)
        {
            if (ModelState.IsValid)
            {
                new UserRepository().UserEdit(id, user);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return HttpNotFound();
        }


        // DELETE: Users/Delete/5
        [HttpDelete]
        [Route("/Users/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            new UserRepository().UserDelete(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        
    }
}
