using Kitaplik.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kitaplik.Data
{
    public interface IKitapRepository
    {
        object Kitaplar { get; set; }

        List<Kitap> GetAll();
        Kitap? GetById(int id);
        void Add(Kitap kitap);
        void Update(Kitap kitap);
        void Delete(int id);
        void AddBook(Kitap kitap);
        void SaveChanges();
        object FirstOrDefault(Func<object, bool> value);
        void UpdateBook();
        void Update();
        void DeleteBook(int id);
    }

    public class KitapRepository : IKitapRepository
    {
        private readonly KitaplikDbContext _context;

        public object Kitaplar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public KitapRepository(KitaplikDbContext context)
        {
            _context = context;
        }



        List<Kitap> IKitapRepository.GetAll()
        {
            return _context.Kitaplar.ToList();

        }

        Kitap? IKitapRepository.GetById(int id)
        {
            return _context.Kitaplar.Find(id);
        }

        void IKitapRepository.Add(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
        }

        void IKitapRepository.Update(Kitap kitap)
        {
            _context.Kitaplar.Update(kitap);
            _context.SaveChanges();
        }

        void IKitapRepository.Delete(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
            }
        }

        void IKitapRepository.AddBook(Kitap kitap)
        {
            // Kitabı veritabanına ekleme işlemi
            _context.Kitaplar.Add(kitap);

            // Veritabanına değişiklikleri kaydetme
            _context.SaveChanges();
        }

        public Kitap? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
        public void UpdateBook(Kitap kitap)
        {
            var existingKitap = _context.Kitaplar.Find(kitap.Id); // Kitap mevcut mu kontrol et
            if (existingKitap != null)
            {
                existingKitap.Ad = kitap.Ad;
                existingKitap.Yazar = kitap.Yazar;
                existingKitap.SayfaSayisi = kitap.SayfaSayisi;



                // Diğer güncellenebilir alanları da buraya ekleyin

                _context.Kitaplar.Update(existingKitap);
                _context.SaveChanges(); // Değişiklikleri kaydet
            }
            else
            {
                throw new Exception("Kitap bulunamadı.");
            }

        }

        public object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}