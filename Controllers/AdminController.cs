using Microsoft.AspNetCore.Mvc;
using PakoLibrary.Filter;
using PakoLibrary.Models;

namespace PakoLibrary.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PakoLibraryDbContext _dbContext;

        public AdminController(ILogger<HomeController> logger,
            PakoLibraryDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string Name, string Password)
        {
            var admin = _dbContext.Admin.FirstOrDefault(a => a.Name == Name
            && a.Password == Password);

            if (admin == null)
            {
                return RedirectToAction(nameof(Index));
            }

            HttpContext.Session.SetInt32("id", admin.ID);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [UserFilter]
        public IActionResult Docs()
        {
            List<Document> documents = _dbContext.Document.ToList();
            return View(documents);
        }


    }
}
