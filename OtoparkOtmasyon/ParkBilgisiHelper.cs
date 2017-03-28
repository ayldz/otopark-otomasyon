using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkOtmasyon
{
    class ParkBilgisiHelper
    {
        protected List<ParkBilgisi> parkBilgisi = new List<ParkBilgisi>();

        public void Giris(ParkBilgisi park)
        {
            parkBilgisi.Add(park);
        }

        public void Cikis(ParkBilgisi park)
        {
            ParkBilgisi existingInfo = parkBilgisi.Where(p => p.plaka == park.plaka && p.slot == park.slot).FirstOrDefault();
            if (existingInfo == null)
            {
                throw new Exception("Kayıt bulunamadı");
            }
            else {
                parkBilgisi.Remove(existingInfo);
            }
        }

        public List<ParkBilgisi> getList()
        {
            return parkBilgisi;
        }

        public bool SlotStatus()
        {
            return true;
        }
    }
}
