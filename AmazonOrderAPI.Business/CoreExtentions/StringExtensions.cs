using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AmazonOrderAPI.Business.CoreExtentions
{
    public static class StringExtensions
    {
        /// <summary>
        /// True, if string has value
        /// </summary>
        /// <param name="str">a string</param>
        /// <returns>Boolean</returns>
        public static bool IsNotNull(this string str)
        {
            return !str.IsNull();
        }

        /// <summary>
        /// True, if string is null or empty
        /// </summary>
        /// <param name="str">a string</param>
        /// <returns>Boolean</returns>
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        ///  To get the trimmed value from string.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns></returns>
        public static string ToTrimmedValue(this string str)
        {
            return str.IsNotNull() ? str.Trim() : string.Empty;
        }

        /// <summary>
        /// To check whthere the primary string is start with the prefix test or not
        /// </summary>
        /// <param name="primary">Primary Text</param>
        /// <param name="prefix">Prefix Text</param>
        /// <returns></returns>
        public static bool IsStartWithIgnoreCase(this string primary, string prefix)
        {
            if (primary.IsNull() || prefix.IsNull())
                return false;
            return primary.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// True, if string is null or empty
        /// </summary>
        /// <param name="str">a string</param>
        /// <returns>Boolean</returns>
        public static bool IsEqualsIgnoreCase(this string str, string other)
        {
            if (str.IsNull() && other.IsNull())
                return true;
            if (str.IsNull() || other.IsNull())
                return false;
            return str.ToTrimmedValue().Equals(other.ToTrimmedValue(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        public static bool IsStartsWithIgnoreCase(this string str, string other)
        {
            if (str.IsNull() && other.IsNull())
                return true;
            if (str.IsNull() || other.IsNull())
                return false;
            return str.ToTrimmedValue().StartsWith(other.ToTrimmedValue(), StringComparison.OrdinalIgnoreCase);
        }
        public static bool IsEndsWithIgnoreCase(this string str, string other)
        {
            if (str.IsNull() && other.IsNull())
                return true;
            if (str.IsNull() || other.IsNull())
                return false;
            return str.ToTrimmedValue().EndsWith(other.ToTrimmedValue(), StringComparison.OrdinalIgnoreCase);
        }
        /// Converts value of given string to Int32.
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>Int32</returns>
        public static int ToInt32(this string str)
        {
            int intEquiv = default(int);
            Int32.TryParse(str, out intEquiv);
            return intEquiv;
        }

        /// <summary>
        /// Converts value of given string to Nullable Int.
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>Nullable Int32</returns>
        public static int? ToNullableInt(this string str)
        {
            if (str.IsNull())
                return null;
            return str.ToInt32();
        }


        /// <summary>
        ///  To get the two string.
        /// </summary>
        /// <param name="first">Value of first String.</param>
        /// <param name="last">Value of last String.</param>
        /// <returns></returns>
        public static string ToJoin(this string first, string last)
        {
            return string.Format("{0} {1}", first, last);
        }

        /// <summary>
        ///  To get the two string.
        /// </summary>
        /// <param name="first">Value of first String.</param>
        /// <param name="last">Value of last String.</param>
        /// <returns></returns>
        public static string ToJoinedWithSepartor(this string first, string last)
        {
            return string.Format("{0} - {1}", first, last);
        }

        /// <summary>
        ///  To get the default value ,if primary string is emptyg.
        /// </summary>
        /// <param name="primary">Primary</param>
        /// <param name="last">DefaulValue</param>
        /// <returns></returns>
        public static string ToDefaultString(this string primary, string defaulValue = "")
        {
            return primary.IsNotNull() ? primary : defaulValue;
        }

        /// <summary>
        /// To get the original reference record name.
        /// </summary>
        /// <param name="name">Name With KVK Fund Prefix.</param>
        /// <returns></returns>
        public static string ToRemovePrefix(this string name)
        {
            return name.IsNull() ? string.Empty : name.Substring(name.IndexOf(" ") + 1);
        }

        /// <summary>
        /// To check whether can change the string as datetime or not
        /// </summary>
        /// <param name="value">string in common format.</param>
        /// <param name="dateFormat">Date Format</param>
        /// <returns></returns>
        public static bool IsDate(this string value, string dateFormat)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
        }

        /// <summary>
        /// To check whether can change the string as datetime or not
        /// </summary>
        /// <param name="value">string in common format.</param>
        /// <param name="dateFormat">Date Format</param>
        /// <returns></returns>
        public static DateTime? ToDate(this string value, string dateFormat)
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(value, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            return null;
        }
        

        public static DateTime? StringToNullableDateTime(this string stringVal)
        {
            DateTime dat;
            if (DateTime.TryParse(stringVal, out dat))
                return dat;
            return null;
        }


        public static bool IsValidDateTime(this string stringVal)
        {
            DateTime dat;
            return DateTime.TryParseExact(stringVal.Substring(0, 24), "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dat);
        }

        public static DateTime ToGridDateConversion(this string stringval)
        {
            var datestring = stringval;
            DateTime dt = DateTime.ParseExact(datestring.Substring(0, 24), "ddd MMM dd yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            return dt;
        }

        public static string GetCurrenyFormat(this double doublevalue)
        {
            return doublevalue != null ? doublevalue.ToString("c2") : string.Empty;
        }

        public static double StringToDouble(this string stringval)
        {
            double doubleval = Convert.ToDouble(stringval);
            return doubleval;

        }



        public static string CurrencyFormat(this double val)
        {
            return val.ToString("c2");
        }

        /// <summary>
        /// True, if string is null or empty
        /// </summary>
        /// <param name="str">a string</param>
        /// <returns>Boolean</returns>
        public static bool EqualsIgnoreCase(this string str, string other)
        {
            return str.Equals(other, StringComparison.OrdinalIgnoreCase);
        }
        

        /// <summary>
        /// To get trimmed lowercase string
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns></returns>
        public static string ToTrimmedLower(this string name)
        {
            return name.IsNull() ? string.Empty : name.Trim().ToLower();
        }

        /// <summary>
        /// To add the version to avois the file cache.
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        public static string ToAddVersion(this string fileUrl)
        {
            var date = DateTime.Now.Ticks;
            return fileUrl.IsNull() ? string.Empty : String.Format("{0}?version={1}", fileUrl, date);
        }

        /// <summary>
        /// To change the boolean to string.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string ToYesNo(this bool status)
        {
            return status ? "Yes" : "No";
        }

        /// <summary>
        /// To change the string to Nullable double.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static double? ToDouble(this string value)
        {
            double output;
            if (double.TryParse(value, out output))
                return output;
            return default(double?);
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
