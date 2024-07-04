using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Bulitten.Common.Helper
{
    public static class UIHelper
    {
        #region Data members

        private const string _dateFormat = "dd/MM/yyyy";
        private const string _datePickerFormat = "dd-MM-yyyy";
        private const string _dateTimeFormat = "dd/MM/yyyy H:mm:ss";
        private const string _dateTimeFormatAMPM = "dd/MM/yyyy hh:mm tt";
        private const string _datestringFormat = "dd/MM/yyyy";
        private const string _dateFormat2 = "yyyy-MM-dd";
        private const string _timeFormat = "HH:mm";

        private static string[] allFormats ={"yyyy/MM/dd","yyyy/M/d",
                                        "dd/MM/yyyy","d/M/yyyy",
                                        "dd/M/yyyy","d/MM/yyyy","yyyy-MM-dd",
                                        "yyyy-M-d","dd-MM-yyyy","d-M-yyyy",
                                        "dd-M-yyyy","d-MM-yyyy","yyyy MM dd",
                                        "yyyy M d","dd MM yyyy","d M yyyy",
                                        "dd M yyyy","d MM yyyy" , "dd/MM/yyyy hh:mm tt" , "dd/MM/yyyy H:mm:ss" , "dd/MM/yyyy H:mm:ss م"};


        private static Random _rnd = new Random(Environment.TickCount);
        public static string GetCurrentDate()
        {
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fffffff",
                                         System.Globalization.CultureInfo.InvariantCulture);
            return date;
        }
        #endregion

        #region Constructor

        //static UIHelper()
        //{
        //    _settings = ConfigurationManager.AppSettings;
        //}
        public static string ConvertDateTimeToTimeString(DateTime date)
        {
            if (date != null)
                return date.ToString(_timeFormat, System.Globalization.CultureInfo.InvariantCulture);
            else
                return string.Empty;
        }
        #endregion
        public static DateTime ConvertStringToDate(string value)
        {
            CultureInfo arSA = new CultureInfo("ar-SA");
            arSA.DateTimeFormat.Calendar = new HijriCalendar();

            return DateTime.ParseExact(value, allFormats,
                                   arSA, DateTimeStyles.AllowWhiteSpaces);


            //return DateTime.ParseExact(value.Trim(), /*_dateFormat*/ "dd/MM/yy", culture);
        }

        public static string ConvertDateToString(DateTime? date)
        {
            if (date != null)
                return date.Value.ToString(_dateFormat, System.Globalization.CultureInfo.InvariantCulture);
            return string.Empty;
        }

        public static DateTime ConvertStringToDateTime(string dateString)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(dateString, out parsedDate))
            {
                return parsedDate;
            }
            return DateTime.MinValue; // Or handle this however you deem appropriate
        }

        public static string ConvertDateTimeToStringWithAMPM(DateTime date)
        {
            return date.ToString(_dateTimeFormatAMPM, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertStringToDateTimeAMPM(string value)
        {
            try
            {
                return DateTime.ParseExact(value.Trim(), _dateTimeFormatAMPM, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public static string ConvertDateTimeToString(DateTime date)
        {
            return date.ToString(_dateTimeFormat, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string ConvertDateTimeToDateString(DateTime date)
        {
            if (date != null)
                return date.ToString(_dateFormat, System.Globalization.CultureInfo.InvariantCulture);
            else
                return string.Empty;
        }

        public static string ConvertDateTimeToDateStringBulliten(DateTime date)
        {
            if (date != null)
                return date.ToString(_dateFormat2, System.Globalization.CultureInfo.InvariantCulture);
            else
                return string.Empty;
        }

        public static string ConvertDateTimeToStringMonthName(DateTime date)
        {
            return date.ToString(_datestringFormat, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string ConvertDateToStringFormat(DateTime date)
        {
            return date.ToString(_dateTimeFormatAMPM, System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        }

        //public static int GetCurrentCultureId()
        //{
        //    switch (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
        //    {
        //        case Constants.Languages.Arabic:
        //            return Enums.CultureID.Ar;

        //        case Constants.Languages.English:
        //            return Enums.CultureID.En;

        //        default:
        //            return Enums.CultureID.Ar;
        //    }
        //}


        //public static string GetCurrentUser()
        //{
        //    var claims = System.Web.HttpContext.Current.Request.GetOwinContext().Authentication.User.Claims;
        //    var claim = claims.Where(x => x.Type == EWallet.Common.Constants.Claims.UserName).SingleOrDefault();

        //    if (claim == null)
        //    {
        //        return string.Empty;
        //    }

        //    return claim.Value;
        //}

        //public static string GetCurrentUserID()
        //{

        //    var claims = System.Web.HttpContextExtensions.GetOwinContext().Authentication.User.Claims;
        //    var claim = claims.Where(x => x.Type == "UserName").SingleOrDefault();

        //    if (claim == null)
        //    {
        //        return string.Empty;
        //    }

        //    return claim.Value;
        //}

        public static string GetQueryString(NameValueCollection qString)
        {
            StringBuilder sb = new StringBuilder();
            if (qString != null)
            {
                if (qString.Count > 0)
                {
                    sb.Append(string.Format("?{0}={1}", qString.Keys[0], qString[0]));
                }
                if (qString.Count > 1)
                {
                    for (int i = 1; i < qString.Count; i++)
                    {
                        sb.Append(string.Format("&{0}={1}", qString.Keys[i], qString[i]));
                    }
                }
            }
            return sb.ToString();
        }

        public static int GenerateRandomNumber()
        {
            var num1 = _rnd.Next(1, 99999999);

            int walletNumber = num1;
            return walletNumber;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
