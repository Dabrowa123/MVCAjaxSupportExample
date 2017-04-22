using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCAjaxSupportExample.Models;
using System.Collections;
using System.Threading;

namespace MVCAjaxSupportExample.Controllers
{

    public class UserController : Controller
    {

        private readonly User[] userData =
        {
         new User {FirstName = "Edy", LastName = "Clooney", Role = Role.Admin},
         new User {FirstName = "David", LastName = "Sanderson", Role = Role.Admin},
         new User {FirstName = "Pandy", LastName = "Griffyth", Role = Role.Normal},
         new User {FirstName = "Joe", LastName = "Gubbins", Role = Role.Normal},
         new User {FirstName = "Mike", LastName = "Smith", Role = Role.Guest}
      };

        public ActionResult Index()
        {
            return View(userData);
        }

        public PartialViewResult GetUserData(string selectedRole = "All")
        {
            IEnumerable data = userData;

            if (selectedRole != "All")
            {
                var selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = userData.Where(p => p.Role == selected);
            }

            return PartialView(data);
        }

        public ActionResult GetUser(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }

        public ActionResult MyAjax()
        {
            return View();
        }

        public PartialViewResult MyPartial()
        {
            Thread.Sleep(2000);
            return PartialView();
        }

    }
}