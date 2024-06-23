using DAL.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;
using TT.DAL.Interfaces;
using TT.Models;

namespace TT.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UserInfo> _signInManager;
        private readonly UserManager<UserInfo> _userManager;
        private readonly AccountService _signInService;
        private readonly iUserInfoRepository _userRepository;
        private readonly iBaseRepository<Role> _RoleRepository;
        private readonly iBaseRepository<Employee> _EmployeeRepository;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<UserInfo> signInManager, UserManager<UserInfo> userManager, iUserInfoRepository userRepository, 
            AccountService signInService, 
            iBaseRepository<Role> RoleRepository,
            iBaseRepository<Employee> EmployeeRepository,
            ILogger<AccountController> logger
            )
        {
            //UserInfo user = new UserInfo()
            _logger = logger;
            _EmployeeRepository = EmployeeRepository;
            _RoleRepository = RoleRepository;
            _signInService = signInService;
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.FindUserAuth(model.Email, model.Password);

                if (user != null /*&& VerifyPassword(user, model.Password)*/)
                {
                    await _signInService.SignInAsync(user, model.RememberMe);
                    _logger.LogInformation("!!! вроде ок");
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        //private bool VerifyPassword(UserInfo user, string password)
        //{
        //    var hashedPassword = HashPassword(password);
        //    return user.PasswordHash == hashedPassword;
        //}

        //private string HashPassword(string password)
        //{
        //    using (var sha256 = SHA256.Create())
        //    {
        //        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        //    }
        //}


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string id = Guid.NewGuid().ToString();
                var emp = new Employee
                {
                    Position = "Rookie",
                    Subdivision = "Unknown",
                    Status = "Active",
                    OutOfOfficeBalance = 0,
                    Role = (await _RoleRepository.GetAll()).FirstOrDefault(r => r.RoleName == "User"),
                    Photo = "default.jpg",
                    UserInfoId = id
                };
                var user = new UserInfo
                {
                    //Id = id,
                    UserName = model.Email,
                    Email = model.Email,

                    Employee = emp
                };
                emp.UserInfo = user;

                var result = await _userManager.CreateAsync(user, model.Password);
                //await _EmployeeRepository.Create(user.Employee);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}
