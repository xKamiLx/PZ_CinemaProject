using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Portal.Models;
using Portal.ViewModels;

namespace Portal.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : BaseController
    {
        // GET: ApplicationUsers
        public ActionResult Index()
        {
            List<ApplicationUser> dbUsers = Db.Users.ToList();
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var item in dbUsers)
            {
                UserViewModel user = new UserViewModel(item);
                int roleId = item.Roles.First(x => x.UserId == item.Id).RoleId;
                user.RoleName = Db.Roles.First(x => x.Id == roleId).Name;

                users.Add(user);
            }

            return View(users);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser dbUser = Db.Users.Find(id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }
            UserViewModel user = new UserViewModel();
            user.Id = dbUser.Id;
            user.Email = dbUser.Email;

            var roleslist = Db.Roles.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();
            user.RolesList = roleslist;
            user.SelectedRoleId = dbUser.Roles.First(x => x.UserId == dbUser.Id).RoleId;

            return View(user);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string roleName = "";
                try
                {
                    ApplicationUser user = Db.Users.Find(model.Id);
                    user.Email = model.Email;
                    int acctualRole = user.Roles.First(x => x.UserId == user.Id).RoleId;
                    if (acctualRole != model.SelectedRoleId)
                    {
                        CustomUserRole role = user.Roles.First(x => x.UserId == user.Id);
                        user.Roles.Remove(role);
                        CustomRole newRole = Db.Roles.First(x => x.Id == model.SelectedRoleId);
                        ApplicationUserManager UserManager =
                            HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        UserManager.AddToRole(user.Id, newRole.Name);
                        roleName = newRole.Name;
                    }
                    else
                        roleName = Db.Roles.First(x => x.Id == acctualRole).Name;

                    Db.Users.Attach(user);
                    Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    Db.SaveChanges();
                }
                catch (System.Exception)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser dbUser = Db.Users.Find(id);
            if (dbUser == null)
            {
                return HttpNotFound();
            }
            UserViewModel user = new UserViewModel(dbUser);

            return View(user);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ApplicationUser dbUser = Db.Users.Find(id);
                Db.Users.Remove(dbUser);
                Db.SaveChanges();
            }
            catch (System.Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return RedirectToAction("Index");
        }
    }
}
