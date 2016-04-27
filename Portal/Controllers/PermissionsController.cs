using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Portal.Models;

namespace Portal.Controllers
{
    public class PermissionsController : BaseController
    {
        [Authorize]
        public ActionResult MakeMeAdmin()
        {
            ApplicationUser user = Db.Users.First(x => x.Email == User.Identity.Name);
            int acctualRole = user.Roles.First(x => x.UserId == user.Id).RoleId;

            if (acctualRole != 2)
            {
                CustomUserRole role = user.Roles.First(x => x.UserId == user.Id);
                user.Roles.Remove(role);
                CustomRole newRole = Db.Roles.First(x => x.Id == 2);
                ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                UserManager.AddToRole(user.Id, newRole.Name);

                Db.Users.Attach(user);
                Db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();

                return RedirectToAction("LogOffForTests", "Account");
            }
            else
                return RedirectToAction("Index", "Home");

        }
    }
}