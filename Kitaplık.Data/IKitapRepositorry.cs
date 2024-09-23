using Kitaplik.Data;
using Kitaplik.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Kitaplık.Data
{
    public interface IKitapRepository
    {
        IEnumerable<Kitap> GetAll();
        Kitap GetById(int id);
        void Add(Kitap kitap);
        void Update(Kitap kitap);
        void Delete(int id);
    }

    public class KitaplikRepository : IKitapRepository
    {
        private readonly KitaplikDbContext _context;

        public KitaplikRepository(KitaplikDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Kitap> GetAll()
        {
            return _context.Kitaplar.ToList();
        }

        public Kitap GetById(int id)
        {
            return _context.Kitaplar.Find(id) ?? throw new Exception("Kitap bulunamadı");
        }

        public void Add(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
        }

        public void Update(Kitap kitap)
        {
            var existingKitap = _context.Kitaplar.Find(kitap.Id);
            if (existingKitap == null)
            {
                throw new Exception("Kitap bulunamadı");
            }
            _context.Kitaplar.Update(kitap);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Kitap bulunamadı");
            }
        }
    }
}
