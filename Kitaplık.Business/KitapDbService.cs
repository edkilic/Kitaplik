using Kitaplik.Data;
using Kitaplik.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Kitaplik.Data.KitapRepository;

public class KitapDbService
{
    
        private readonly IKitapRepository _kitapRepository;

    public KitapDbService(IKitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        public List<Kitap> GetKitaplar()
        {
            return _kitapRepository.GetAll().ToList(); // Repository'den kitapları al
        }

    public void AddKitap(Kitap kitap)
    {
        _kitapRepository.AddBook(kitap); // Repository'de kitap ekleme
    }

    public IEnumerable<Kitap> GetAll()
    {
        return _kitapRepository.GetAll(); // veya _context.Kitaplar.AsQueryable();
    }
}
