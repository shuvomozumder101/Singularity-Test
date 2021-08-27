using HomeOfficeManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace HomeOfficeManagement.Controllers
{
    public class Dashboard : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public Dashboard(ApplicationDbContext applicationDbContext , SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
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

            //var roles =  _userManager.GetRolesAsync(user);
            return View();
        }
        public IActionResult UserDashboard()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}
