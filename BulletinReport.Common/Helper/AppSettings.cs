using System.Configuration;

namespace BulletinReport.Common.Helper
{
    public class AppSettings
    {
        public static bool IsMobile => IsMobileCheck("IsMobile");
        public static bool IsFrontEnd => IsFrontEndCheck("IsFrontEnd");

        public static string LogFilePath => GetValue("LogFilePath");
        private static bool IsFrontEndCheck(string key)
        {

            string value = GetValue(key);
            if (value?.ToLower() == "true")
            {
                return true;
            }
            return false;
        }
        private static bool IsMobileCheck(string key)
        {

            string value = GetValue(key);
            if (value?.ToLower() == "true")
            {
                return true;
            }
            return false;
        }

        private static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static class AnonymousUserInformation
        {
            public static string Username => GetValue("Anonymous_Username");
            public static string Password => GetValue("Anonymous_Password");

            // public static string K2AnonymousImpersonatedUsername => GetValue("K2AnonymousImpersonatedUsername");
        }

        public static bool DisableHandleWebExceptions => GetValue("DisableHandleWebExceptions") == "1";
    }
}
