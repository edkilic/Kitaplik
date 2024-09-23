using Kitaplik.Data;
using Kitaplik.Entities;
using System.Collections.Generic;

namespace Kitaplik.Business
{
    public class KitapService
    {
        private readonly IKitapRepository _kitapRepository; // Arayüz kullanımı

        public KitapService(IKitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        public void AddKitap(Kitap kitap)
        {
            _kitapRepository.Add(kitap); // Kitap ekleme işlemi
        }

        public void Delete(int id)
        {
            var kitap = _kitapRepository.GetById(id);
            if (kitap == null)
            {
                throw new Exception("Kitap bulunamadı");
            }
            _kitapRepository.Delete(id);
        }

        public Kitap? GetKitapById(int id)
        {
            return _kitapRepository.GetById(id); // Kitap ID ile alma işlemi
        }

        public IEnumerable<Kitap> GetKitaplar()
        {
            return _kitapRepository.GetAll(); // Tüm kitapları alma işlemi
        }

        public void UpdateKitap(Kitap kitap)
        {
            _kitapRepository.Update(kitap);
        }

        public void DeleteKitap(int id)
        {
            _kitapRepository.Delete(id); 
        }

    }
}

