using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Util
    {
        public static int GetIntFromString(string strNumber)
        {
            int iNumber = 0;
            int.TryParse(strNumber, out iNumber);
            return iNumber;
        }

        public static short GetShortFromString(string shortNumber)
        {
            short shNumber = 0;
            short.TryParse(shortNumber, out shNumber);
            return shNumber;
        }
        public static DateTime GetDateTimeFromString(string strDateTime)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            if (strDateTime != null && strDateTime.Length >= 10)
            {
                DateTime.TryParse(strDateTime, out dt);
            }
            return dt;
        }

        public static DateTime GetDateTimeFromStringDateJS(string strDateTime)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            if (strDateTime != null && strDateTime.Length >= 10)
            {
                DateTime.TryParse(strDateTime, out dt);
            }
            return dt;
        }

        public static DateTime GetDateTimeFromFormatString(string strDateTime)
        {
            DateTime dt = new DateTime(1900, 1, 1);
            if (strDateTime != null && strDateTime.Length >= 10)
            {
                int dd = 0;
                int mm = 0;
                int yyyy = 0;
                int.TryParse(strDateTime.Substring(0, 4), out yyyy);
                int.TryParse(strDateTime.Substring(5, 2), out mm);
                int.TryParse(strDateTime.Substring(8, 2), out dd);

                if (dd > 0 && mm > 0 && yyyy > 0)
                {
                    dt = new DateTime(yyyy, mm, dd);
                }
                else
                {
                    int.TryParse(strDateTime.Substring(0, 2), out dd);
                    int.TryParse(strDateTime.Substring(3, 2), out mm);
                    int.TryParse(strDateTime.Substring(6, 4), out yyyy);
                }
            }
            return dt;
        }

        public static string GetDateTimeFormat(DateTime dtDateTime)
        {
            if (dtDateTime.Year > 1900)
            {
                return dtDateTime.ToString("dd/MM/yyyy");
            }
            return "";
        }
        public static string GetDateTimeHourFormat(DateTime dtDateTime)
        {
            if (dtDateTime.Year > 1900)
            {
                return dtDateTime.ToString("dd/MM/yyyy HH:mm");
            }
            return "";
        }

        public static bool GetBoolFromString(string strBool)
        {
            bool bl = false;
            bool.TryParse(strBool, out bl);
            return bl;
        }

        public static string CleanSpacesAndNulls(string strIn)
        {
            if (strIn != null)
            {
                return strIn.Trim();
            }
            else
            {
                return "";
            }
        }

        public static char CleanSpacesAndNullsChar(string strIn)
        {
            if (strIn != null)
            {
                strIn = strIn.Trim();
                if (strIn.Length > 0)
                {
                    return strIn.Trim().ToCharArray()[0];
                }
                else
                {
                    return ' ';
                }
            }
            else
            {
                return ' ';
            }
        }

        public class BodyResponse
        {
            public int status { get; set; }
            public object result { get; set; }
        }
        public class BodyResponseF
        {
            public int status { get; set; }
            public object result { get; set; }
            public string mensaje { get; set; }
        }

        public static object GetBodyResponse(int statusCode, object obj)
        {
            BodyResponse oBodyResponse = new BodyResponse();
            oBodyResponse.status = statusCode;
            oBodyResponse.result = obj;
            return oBodyResponse;
        }
        public static object GetBodyResponseF(int statusCode, object obj, string msj)
        {
            BodyResponseF oBodyResponse = new BodyResponseF();
            oBodyResponse.status = statusCode;
            oBodyResponse.result = obj;
            oBodyResponse.mensaje = msj;
            return oBodyResponse;
        }

        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}