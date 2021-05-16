using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Yacth Message
        public static string YacthAdded = "Yat Eklendi";
        public static string YacthNameInvalid = "Yat ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string YacthListed = "Yatlar listelendi";
        public static string ErrorYacthListed = "Yatlar listelenemedi";
        public static string DailyPriceInvalid = "Geçersiz fiyat";
        public static string SuccessYacthDelete = "Yat silindi";
        public static string SuccessYacthUpdated = "Yat güncellendi";
        public static string ErrorYacthUpdated = "Yat güncellenemedi";
        public static string YacthGet = "Yatlar getirildi";
        public static string GetYacthsByBrandIdMessage = "Yatlar Brand Id ye göre listelenmiştir";
        public static string GetYacthsDetailMessage = "Yatların detayları getirildi";
        public static string GetYacthDetailMessage = "Yat detayları getirildi";
        public static string GetUnitPriceMessage = "Arabalar günlük fiyata göre listelenmiştir";
        public static string YacthNameAlreadyExists = "Aynı modelde yat var zaten";

        //Customer Message
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerAddedError = "Müşteri Eklenemedi";
        public static string CustomerNameInvalid = "Müşteri ismi geçersiz";
        public static string CustomerListed = "Müşterilar listelendi";
        public static string ErrorCustomerListed = "Müşterilar listelenemedi";
        //public static string ErrorDelete = "Müşteri silinemedi";
        public static string SuccessCustomerDelete = "Müşteri silindi";
        public static string SuccessCustomerUpdated = "Müşteri bilgileri güncellendi";
        public static string ErrorUpdated = "Müşteri güncellenemedi";
        public static string CustomerGet = "Müşteri getirildi";
        public static string CustomerGetError = "Müşteri bulunamadı";
        public static string GetCustomerDetailsMessage = "Müşteri detayları getirildi";

        //Rental Message
        public static string RentalAddedError = "Kiralanamadı";
        public static string RentalAdded = "Kiralandı";
        public static string GetAllRental = "Kiralıklar listelendi";
        public static string RentalUpdate = "Kira güncellendi";
        public static string RentalDelete = "Kira silindi";
        public static string GetRentalDto = "Kira bilgileri getirildi";
        public static string GetRentalById = "Kira getirildi";

        //User Message
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserAddedError = "Kullanıcı eklenemedi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserUpdatedError = "Kullanıcı güncellenemedi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserGet = "Kullanıcı getirildi";
        public static string AuthorizationDenied = "Yetkin Yok";
        public static string UserRegistered = "Kayıt başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        //Brand Message
        public static string BrandAdded = "Marka eklendi";
        public static string BrandAddedError = "Marka eklenemedi";
        public static string GetBrandByIdMessage = "Markalar Brand Id ye göre listelenmiştir";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandUpdatedError = "Marka güncellenemedi";
        public static string BrandDeleted = "Marka silindi";
        public static string GetBrandMessage = "Brand Id ye göre getirildi";

        //Color Message
        public static string ColorListed = "Renkler listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorAddedError = "Renk eklenemedi";
        public static string GetColorByIdMessage = "Renk Color Id ye göre listelenmiştir";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorUpdatedError = "Renk güncellenemedi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorNameAlreadyExists = "Renk zaten var";
        public static string GetYacthsByColorIdMessage = "Arabalar Color Id ye göre listelenmiştir";

        //CarImages Message
        public static string YacthImageListed = "Resimler listelendi";
        public static string YacthImageAdded = "Yat resmi eklendi";
        public static string YacthImageAddedError = "Resim eklenemedi";
        public static string GetYacthImageByIdMessage = "Resim Yat Image Id ye göre listelenmiştir";
        public static string YacthImageUpdated = "Resim güncellendi";
        public static string YacthImageUpdatedError = "Resim güncellenemedi";
        public static string YacthImageDeleted = "Resim silindi";
        public static string GetAllYacthByImage = "Yat resimleri getirildi";
        public static string ImageLimitError = "Resim sınırına ulaşıldı";

        public static string PaymentAdded = "Ödeme başarıyla kaydedildi";
        public static string GetErrorYacthMessage = "Araç bilgisi / bilgileri getirilemedi.";
        public static string RentalDetails = "Kiralama bilgileri getirildi";
        public static string ChangedPassword = "Şifre değiştirildi";

        //Card
        public static string CardAdded = "Kart bilgileri kaydedildi";
        public static string CardDelete = "Kart bilgileri silindi";
        public static string EarnedFindex = "Findex puan kazandınız";
        public static string PaymentSuccessful = "Ödeme başarılı";
        public static string PaymentError = "Ödeme başarısız";
        public static string NoRentAYacth = "Kiralık Araç yok";

        //Brand Images
        public static string BrandImageListed = "Marka resimleri listelendi";
        public static string BrandImageUpdated = "Marka resimleri güncellendi";
        public static string BrandImageAdded = "Marka resmi eklendi";
        public static string GetErrorBandMessage = "Marka bilgileri getirilemedi";
        public static string GetBandMessage = "Marka bilgileri getirildi";
    }
}
