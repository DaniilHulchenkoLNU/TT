using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;
using TT.Models;

namespace TT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeService employeeService;

        public HomeController(ILogger<HomeController> logger, EmployeeService employeeService)
        {
            this.employeeService = employeeService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Employee data = await employeeService.Test();
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
