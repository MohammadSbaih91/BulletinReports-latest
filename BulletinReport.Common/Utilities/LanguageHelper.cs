using System.Threading;

namespace BulletinReport.Common.Utilities
{
    public class LanguageHelper
    {
        public static bool IsArabic
        {
            get { return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToLower() == "ar"; }
        }
    }
}
