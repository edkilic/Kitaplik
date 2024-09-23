using Kitaplik.Business;
using Kitaplik.Entities;
using Kitaplık.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Web.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapService _kitapService;

        public KitapController(KitapService kitapService)
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

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var kitap = _kitapService.GetKitapById(id);
            if (kitap == null)
            {
                return NotFound(); // Kitap bulunamadıysa 404 döner
            }

            return View(kitap); // Guncelle view'ını döndürür ve kitap bilgilerini gönderir
        }

        // POST: /Kitap/Guncelle
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapService.UpdateKitap(kitap);
                return RedirectToAction("Index"); // Kitap güncellendikten sonra listeye döner
            }

            return View(kitap);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _kitapService.DeleteKitap(id); // KitapService'teki silme metodunu çağırır
                return RedirectToAction("Index"); // Başarılı olursa kitap listesini gösterir
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
        }


    }
}
