using Blog_management.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Reposity
{
    internal class ReportReposity : Common.Reposity<Report, int>
    {
        private static int _idCounter;

        public static int IdCounter
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }
        }

        public static Report Add(User from, User to, string content)
        {
            Report report = new Report(content, from, to, IdCounter);
            DBcontect.Add(report);
            return report;
        }
        static ReportReposity()
        {
            DBcontect.Add(new Report("salam xaiw edirem bu user i bloklayin", UserReposity.GetUerByEmail("haci@gmail.com"), UserReposity.GetUerByEmail("ayroali@gmail.com"), 1));
        }
    }
}
