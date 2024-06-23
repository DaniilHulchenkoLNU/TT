using DAL.Implementations;
using DAL.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;
using TT.DAL;
using TT.Models;

namespace TT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeService employeeService;
        private readonly iUserInfoRepository userInfoRepository;
        private readonly ApplicationDbContext applicationDbContext;
        private readonly SignInManager<UserInfo> _signInManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<UserInfo> signInManager, EmployeeService employeeService, iUserInfoRepository UserInfoRepository, ApplicationDbContext applicationDbContext)
        {
            _signInManager = signInManager;
            this.employeeService = employeeService;
            userInfoRepository = UserInfoRepository;
            this.applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //Employee data = await employeeService.Test();
            //UserInfo userInfo = userInfoRepository.FindUserByEmail("q@gmail.com");
            //userInfo.Employee = await employeeService.Test();
            //userInfoRepository.Update(userInfo);
            //applicationDbContext.SeedData();

            if (User.Identity.IsAuthenticated)
            {
                // Пользователь аутентифицирован
                _logger.LogInformation("+");
            }
            else
            {
                _logger.LogError("-");
                // Пользователь не аутентифицирован
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
