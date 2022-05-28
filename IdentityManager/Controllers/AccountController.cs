using Microsoft.AspNetCore.Mvc;
using IdentityManager.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityManager.Controllers
{
    public class AccountController : Controller
    {
        //Adding User Manager via Dependency Injection 
        private readonly UserManager<IdentityUser> _userManager;

        //Signin manager
        private readonly SignInManager<IdentityUser> _signInManager;

        //Constructor for UserManager & SignInManager
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Registration
        [HttpGet]
        public async Task<ActionResult> Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel(); 
            return View(registerViewModel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Server Side Validation 
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name }; //Populating new user object using entered data 
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home"); 
                }
                AddErrors(result);
                 
            }
           return View(model);
        }

        //Logoff 
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //Helper Method to Add Errors 
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description); 
            }
        }
    }
}
