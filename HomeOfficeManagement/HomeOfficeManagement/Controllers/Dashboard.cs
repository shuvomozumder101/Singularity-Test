using HomeOfficeManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using HomeOfficeManagement.Models;

namespace HomeOfficeManagement.Controllers
{
    public class Dashboard : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public Dashboard(ApplicationDbContext applicationDbContext , SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(UserId);
            var roles = await _userManager.GetRolesAsync(user);
            for (int i = 1; i<= roles.Count(); i++)
            {
                if (roles[i - 1].Trim().ToLower() == "superadmin")
                {
                    return RedirectToAction("AdminDashboard");

                }
                else if (roles[i - 1].Trim().ToLower() == "employee")
                {
                    return RedirectToAction("UserDashboard");
                }
                else
                    continue;
                
            }
            return View();

        }
        public IActionResult UserDashboard()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            var user = _applicationDbContext.AspNetUsers.ToList();
            ViewBag.user = user.Count();
            ViewBag.blockUser = user.Where(x => x.BlockStutas == true).Count();
            ViewBag.present = _applicationDbContext.Attendees.Where(x => x.Date == DateTime.Today).Count();
            return View(user);
        }
    }
}
