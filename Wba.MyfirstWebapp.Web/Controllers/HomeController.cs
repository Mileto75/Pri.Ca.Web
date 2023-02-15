using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pri.Ca.Infrastructure.Data;
using System.Diagnostics;
using Wba.MyfirstWebapp.Web.Models;
using Wba.MyfirstWebapp.Web.ViewModels;

namespace Wba.MyfirstWebapp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbcontext _applicationDbcontext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbcontext applicationDbcontext)
        {
            _logger = logger;
            _applicationDbcontext = applicationDbcontext;
        }

        public async Task<IActionResult> Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.Games = await _applicationDbcontext.Games
                .Include(g => g.Categories).Select(g => new BaseViewModel
                { 
                    Id = g.Id,
                    Name = g.Name,
                }).ToListAsync();
            return View(homeIndexViewModel);
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