using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PakoLibrary.Filter;
using PakoLibrary.Models;
using System.Linq.Expressions;

namespace PakoLibrary.Controllers
{
    [UserFilter]
    public class DocumentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PakoLibraryDbContext _dbContext;

        public DocumentController(ILogger<HomeController> logger,
            PakoLibraryDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] Document model)
        {
            try
            {
                if (model != null)
                {
                    var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    // Resim dosyası
                    var pictureFile = Request.Form.Files.FirstOrDefault(f => f.Name == "PicturePath");
                    string picturePath = null;

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var pictureSavePath = Path.Combine(wwwRootPath, "img");
                        var pictureFileName = $"{DateTime.Now:MMddHHmmss}.{pictureFile.FileName.Split(".").Last()}";  // Benzersiz dosya adı
                        var pictureFileUrl = Path.Combine(pictureSavePath, pictureFileName);

                        // Dosyayı kaydet
                        using (var fileStream = new FileStream(pictureFileUrl, FileMode.Create))
                        {
                            await pictureFile.CopyToAsync(fileStream);
                        }

                        picturePath = $"/img/{pictureFileName}";  // Web yolu
                    }

                    // PDF dosyası
                    var pdfFile = Request.Form.Files.FirstOrDefault(f => f.Name == "PDF_Link");
                    string pdfPath = null;

                    if (pdfFile != null && pdfFile.Length > 0)
                    {
                        var pdfSavePath = Path.Combine(wwwRootPath, "pdf");
                        var pdfFileName = $"{DateTime.Now:MMddHHmmss}.{pdfFile.FileName.Split(".").Last()}";  // Benzersiz dosya adı
                        var pdfFileUrl = Path.Combine(pdfSavePath, pdfFileName);

                        // Dosyayı kaydet
                        using (var fileStream = new FileStream(pdfFileUrl, FileMode.Create))
                        {
                            await pdfFile.CopyToAsync(fileStream);
                        }

                        pdfPath = $"/pdf/{pdfFileName}";  // Web yolu
                    }

                    // Yolu modelin alanlarına ekle
                    model.PicturePath = picturePath;
                    model.PDF_Link = pdfPath;


                    // Veritabanına kaydet
                    await _dbContext.AddAsync(model);
                    await _dbContext.SaveChangesAsync();

                    return Json(true);  // Başarı mesajı
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}, StackTrace: {ex.StackTrace}");
                return Json(new { success = false, message = ex.Message });
            }
            return Json(false);


        }


        public IActionResult DeleteDoc(int? id)
        {
            _dbContext.Remove(_dbContext.Document.FirstOrDefault(d => d.ID == id));
            _dbContext.SaveChanges();

            return RedirectToAction("Docs", "Admin");
        }

    }
}
