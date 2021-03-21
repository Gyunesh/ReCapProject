using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Arac eklendi";
        public static string CarDeleted = "Arac silindi.";
        public static string CarUpdated = "Arac guncellendi.";
        public static string CarNameInvalid = "Arac ismi gecersiz";
        public static string MaintenanceTime = "Sistem bakimda.";
        public static string CarListed = "Araclar listelendi.";
        
        public static string BrandAdded="Marka Eklendi";
        public static string BrandNameInvalid="Arac adi gecersiz en az 2 karakter olmali.";
        public static string BrandDeleted="Marka silindi.";
        public static string BrandListed="Markalar listelendi.";
        public static string BrandUpdated="Markalar guncellendi.";
        
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorNameInvalid = "Renk adi gecersiz en az 2 karakter olmali.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorUpdated = "Renkler guncellendi.";
        
        public static string CarPriceInvalid="Girdiginiz rakam gecersiz 0 dan buyuk olmali.";
        
        public static string CustomerAdded="Musteri Eklendi.";
        public static string CustomerDeleted="Musteri Silindi.";
        public static string CustomerListed="Musteri Listelendi.";
        public static string CustomerUpdated="Musteri Guncellendi.";
        public static string RentalAddedError="Kiralama Basarisiz";
        public static string RentalAdded="Kiralama yapildi";
        public static string CarImageLimitExceeded="Arac fotograf limiti asildi.";
    }
}
