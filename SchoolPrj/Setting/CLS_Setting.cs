using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPrj.Setting
{
    class CLS_Setting
    {
        public static string datetoString(DateTime d)
        {
            string day = d.Day.ToString();
            string month = d.Month.ToString();
            string year = d.Year.ToString();
            return year + "/" + month + "/" + day;
        }
        public static string timetoString(DateTime d)
        {
            string hour = d.Hour.ToString();
            string minute = d.Minute.ToString();
            return hour + ":" + minute;
        }
    }
}
