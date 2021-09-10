using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDetailsListed = "Araba detayları getirildi";
        public static string CarsListedByBrandId = "Arabalar marka numarasına göre listelendi ";
        public static string CarsListedByColorId = "Arabalar renk numarasına göre listelendi ";
        public static string CarsListed = "Arabalar listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string InvaidBrandName= "Marka ismi 2 karakterden fazla olmalıdır";
        public static string BrandsListed = "Markalar listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string InvaidColorName = "Renk ismi 2 karakterden fazla olmalıdır";
        public static string ColorsListed = "Renkler listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi";
        public static string InvaidUserName = "Kullanıcı ismi 2 karakterden fazla olmalıdır";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string RentralAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama bilgileri güncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string CarImagesListed = "Araba resimleri listelendi";
        public static string CarCountOfBrandError = "Bir markada en fazla 15 araba olabilir";
        public static string CarNameAlreadyExists = "Bu isimde zaten bir araba var";
        public static string BrandLimitExceded = "Marka limiti aşıldı. Marka sayısı 10'dan çok olamaz";
        public static string CarImageNotFound="Araba resmi bulunamadı";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarImageLimitExceeded="Araba resmi limiti aşıldı";
        public static string AuthorizationDenied = "Yetkilendirmeniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Yanlış parola";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string RentalDetailsListed="Kiralama detayları listelendi";
        public static string RentalAdded = "Araba kiralama işlemi başarıyla gerçekleşti.";
        public static string RentalDelivered = "Araba teslim etme işlemi başarıyla gerçekleşti.";
        public static string RentalReturnDateIsNull = "Araba henüz teslim edilmemiştir, kiralanamaz.";
        public static string RentalReturnDateIsNotNull = "Araba zaten teslim edilmiştir, tekrar teslim işlemi yapılamaz.";
        public static string RentalDateOk = "Araba istenen tarihlerde işlenebilir.";
        public static string PaymentAdded = "Ödeme aracı eklendi.";
    }
}
