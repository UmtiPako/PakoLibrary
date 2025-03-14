using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PakoLibrary.Models;

namespace PakoLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PakoLibraryDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, 
            PakoLibraryDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string query)
        {
            List<Document> documents = _dbContext.Document.ToList();

            if (!query.IsNullOrEmpty())
            {
                documents = _dbContext.Document.Where(d => d.Name.Contains(query)
                || d.ShortDescription.Contains(query)).ToList();
            }

            return View(documents);
        }
        public IActionResult Contact()
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
