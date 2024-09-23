using Kitaplik.Data;
using Kitaplik.Entities;

namespace Kitaplik.Business
{
    public class KitapServiceBase
    {
        private readonly KitapRepository _kitapRepository;

        public KitapServiceBase(KitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        public Kitap? GetKitapById(int id)
        {
            return _kitapRepository.GetById(id); // Repository'nin GetById metodunu çağır
        }
    }
}
