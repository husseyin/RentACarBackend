using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans.Messages
{
    public static class SuccessMessage
    {
        //CAR
        public static string CarAdded = "Araç eklendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarListed = "Araçlar listelendi.";
         
        //BRAND
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandListed = "Markalar listelendi.";
         
        //COLOR
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorListed = "Renkler listelendi.";

        //CUSTOMER
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";               

        //RENTAL
        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string RentalListed = "Kiralamalar listelendi.";

        //CarImage
        public static string CarImageAdded = "Resim eklendi.";
        public static string CarImageDeleted = "Resim silindi.";
        public static string CarImageUpdated = "Resim güncellendi.";
        public static string CarImageListed = "Resimler listelendi.";

        //USER
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
