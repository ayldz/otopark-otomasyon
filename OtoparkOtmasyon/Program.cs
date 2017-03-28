using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkOtmasyon
{
    class Program
    {

        protected static ParkBilgisiHelper helper = new ParkBilgisiHelper();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("İşlem Seçiniz :\n(1)Giriş\n(2)Çıkış\n(3)Listele");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Giris();
                    break;
                case "2":
                    Cikis();
                    break;
                case "3":
                    Listele();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Bilgi: Hatalı işlem seçtiniz! Aşağıdaki numaralardan birini giriniz.");
                    Menu();
                    break;
            }
        }

        static void Giris()
        {
            ParkBilgisi info = new ParkBilgisi();

            Console.WriteLine("Giriş Bilgilerini Giriniz :\nPlaka : ");
            info.plaka = Console.ReadLine();

            info.girisSaati = DateTime.Now;

            info.cikisSaati = null;

            Console.WriteLine("Slot Bilgisi : ");
            info.slot = int.Parse(Console.ReadLine());

            info.status = true;

            helper.Giris(info);

            Menu();
        }

        static void Cikis()
        {
            ParkBilgisi info = new ParkBilgisi();

            Console.WriteLine("Çıkış Bilgilerini Giriniz :\nPlaka : ");
            info.plaka = Console.ReadLine();

            info.cikisSaati = DateTime.Now;

            Console.WriteLine("Slot Bilgisi : ");
            info.slot = int.Parse(Console.ReadLine());

            info.status = false;

            try
            {
                helper.Cikis(info);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Menu();
        }

        static void Listele()
        {
            List<ParkBilgisi> PB = helper.getList();

            Console.WriteLine("Plaka\t|Slot\t|Giriş\t|Çıkış");
            Console.WriteLine("--------------------------------");
            foreach (ParkBilgisi info in PB)
            {
                Console.WriteLine("{0}|{1}\t|{2}|{3}",info.plaka, info.slot, info.girisSaati, info.cikisSaati);
            }
            Console.WriteLine("--------------------------------");
            Menu();
        }

    }
}
