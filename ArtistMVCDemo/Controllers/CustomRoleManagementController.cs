using ArtistMVCDemo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtistMVCDemo.Controllers
{
    //φτιάξαμε την κλάση RoleName να παίζει τον ρόλο του enum
    [Authorize(Roles =RoleName.Administrator)]
    public class CustomRoleManagementController : Controller
    {
        // GET: CustomRoleManagement

        private ApplicationDbContext _context;
        private RoleManager<IdentityRole> roleManager;

        public CustomRoleManagementController()
        {
            _context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
        }

        public ActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            roleManager.Create(role);
            return RedirectToAction("Index", "CustomRoleManagement");
        }


        public ActionResult IdentityUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}