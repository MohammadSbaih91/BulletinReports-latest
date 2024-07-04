using BulletinReport.Common.Utilities;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace BulletinReports.UIHelper
{
    public static class LanguageSettingsHelper
    {
        private static readonly Dictionary<string, string> Cultures = new Dictionary<string, string>()
        {
            {"ar", "ar-SA"},
            {"en", "en-US"},
        };

        public static string LanguageKey { get { return "lang"; } }
        public static string DefaultLanguage { get { return "ar"; } }
        public static string DefaultCultureName { get { return Cultures[DefaultLanguage]; } }

        public static bool IsArabic
        {
            get { return LanguageHelper.IsArabic; }
        }


        public static void AddLocalizedRoutes(RouteCollection routes)
        {
            string languagesConstraint
                = string.Join("|", Cultures.Select(kv => kv.Key)); //@"en|ar"

            routes.MapRoute(
                name: "Localized",
                url: "{" + LanguageKey + "}/{controller}/{action}/{id}",
                constraints: new { language = languagesConstraint },
                defaults:
                    new { language = DefaultLanguage, controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "LocalizedDefault",
                url: "{controller}/{action}/{id}",
                constraints: new { language = languagesConstraint },
                defaults:
                    new { language = DefaultLanguage, controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }

        public static void SetCulture(RouteData routeData)
        {
            string language = (string)routeData.Values["lang"];
            var cultureName = !String.IsNullOrWhiteSpace(language)
                                 && Cultures.ContainsKey((language = language.ToLower()))
                ? Cultures[language]
                : DefaultCultureName;

            //string routeValueDictionary = routeData.Values[LanguageKey].ToString().ToLower();

            //var cultureName = Cultures.ContainsKey(routeValueDictionary)
            //    ? Cultures[routeValueDictionary]
            //    : DefaultCultureName;

            SetCulture(cultureName);
        }

        public static void SetCulture(string cultureName)
        {
            var cultureInfo = new CultureInfo(cultureName) { DateTimeFormat = { Calendar = new GregorianCalendar() } };

            // Set datetime patterns/formats
            //switch (cultureInfo.TwoLetterISOLanguageName.ToLower())
            //{
            //    case "en":
            //        cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            //        break;
            //}
            //cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            //cultureInfo.DateTimeFormat.Calendar = new GregorianCalendar();
            //Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new CultureInfo("en-US").DateTimeFormat;
            Thread.CurrentThread.CurrentCulture = cultureInfo /*en*/;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}