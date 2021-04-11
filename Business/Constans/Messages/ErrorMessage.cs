using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans.Messages
{
    public static class ErrorMessage
    {
        public static string CarNameInvalid = "Araç adı geçersiz!";
        public static string CarRented = "Araç kiralanmış!";
        public static string BrandNameInvalid = "Marka adı geçersiz!";
        public static string CarImageLimitExceeded = "Bir arabanın en fazla 5 resmi olabilir!";
        public static string MaintenanceTime = "Sistem bakımda!";
        public static string AuthorizationDenied = "Yetkiniz yoktur!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Kullanıcı bulunamadı!";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
    }
}
