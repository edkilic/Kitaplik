using Kitaplik.Business;
using Kitaplik.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Web.Controllers
{
    public class KGelenController : Controller
    {
        private readonly KitapService _kitapService;

        public KGelenController(KitapService kitapService)
        {
            _kitapService = kitapService;
        }

        // Kitapları listeleme
        public IActionResult Index()
        {
            var kitaplar = _kitapService.GetKitaplar();
            return View(kitaplar); // Index.cshtml
        }

        // Kitap ekleme formu
        [HttpGet]
        public IActionResult Add()
        {
            return View(); // Add.cshtml
        }

        // Kitap ekleme işlemi
        [HttpPost]
        public IActionResult Add(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapService.AddKitap(kitap);
                return RedirectToAction("Index"); // Kitap eklendikten sonra listeleme sayfasına yönlendirme
            }
            return View(kitap); // Formdaki hatalar varsa, aynı sayfayı tekrar göster
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Kitabı repository üzerinden sil
            try
            {
                _kitapService.Delete(id); // Kitabı silme işlemi
                TempData["Message"] = "Kitap başarıyla silindi."; // Başarı mesajı
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata: {ex.Message}"; // Hata mesajı
            }

            return RedirectToAction("Index"); // Kitap listesine geri dön
        }

    }
}
