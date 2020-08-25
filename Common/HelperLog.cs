using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HelperLog
    {
        private static object locker = new Object();
        private static void WriteLog(string Message)
        {

            string LocationLog = AppDomain.CurrentDomain.BaseDirectory;
            string Root = LocationLog + @"\CentrixLogs\";
            string lsYear = DateTime.Today.Year.ToString().PadLeft(4, '0');
            string lsMonth = DateTime.Today.Month.ToString().PadLeft(2, '0');
            string lsDay = DateTime.Today.Day.ToString().PadLeft(2, '0');
            string lsHour = DateTime.Now.ToLongTimeString();
            Root = Root + @"\" + lsYear + @"\" + lsMonth + @"\";
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            Root += "Log" + lsDay + ".txt";
            lock (locker)
            {
                using (StreamWriter Write = new StreamWriter(Root, true))
                {
                    Write.WriteLine(lsHour + "-" + Message);
                    Write.Flush();
                    Write.Close();
                    Write.Dispose();
                }
            }
        }
        public static void PutLine(string Message)
        {
            WriteLog(Message);
        }
        public static void PutLineError(string Message)
        {
            WriteLog("ERROR ====> " + Message);
        }
        public static void PutStackTrace(Exception ex)
        {
            StackTrace stacktrace = new StackTrace(ex, true);
            StackFrame stackframe = stacktrace.GetFrame(0);
            string _FunctionName = stackframe.GetMethod().Name;
            string _Namespace = stackframe.GetType().ToString();
            string _FileName = stackframe.GetMethod().GetGenericArguments().ToString();
            string _line = string.Empty;
            string _te = ex.StackTrace.ToString();
            int _lis = _te.IndexOf("line") == -1 ? _te.IndexOf("línea") : _te.IndexOf("line");
            _line = _te.Substring(_lis, 7);
            string gop = stacktrace.GetFrame(0).GetFileLineNumber().ToString();
            WriteLog("----------------------------------------------");
            WriteLog("--------------------ERROR--------------------");
            WriteLog("----------------------------------------------");
            WriteLog("Exception Message :" + ex.Message);
            WriteLog("Exception Detail :" + ex.StackTrace);
            WriteLog("----------------------------------------------");
            //WriteLog("Exception Function Name :" + _FunctionName);
            //WriteLog("Exception Message :" + _Namespace);
            //WriteLog("Exception On Line Number :" + _line);
        }
    }
}
