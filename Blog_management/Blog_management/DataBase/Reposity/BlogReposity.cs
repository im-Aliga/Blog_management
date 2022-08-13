using Blog_management.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Reposity
{
    public class BlogReposity : Common.Reposity<Blog, string>
    {
        static Random _random = new Random();

        private static string _blogCode;
        public static string BlogCode
        {
            get
            {
                _blogCode = "BL" + _random.Next(10000, 100000);
                return _blogCode;
            }
        }

        static BlogReposity()
        {
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("ayroali@gmail.com"), "Azerbaycan", "Qarabag Azerbaycandir", BlogStatus.Approve, "BL11111"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("ayroali@gmail.com"), "Rusiya", "Rusiya cox iki uzlu dovletdir", BlogStatus.Created, "BL22222"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("ayroali@gmail.com"), "Iran", "Iran cox xain dovletdir", BlogStatus.Reject, "BL33333"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("haci@gmail.com"), "Amerika", "amerika cox demokratik ve alim quvvesi boyuk olan dovletdir", BlogStatus.Approve, "BL44444"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("haci@gmail.com"), "Ermenistan", "Mumkundurse bele dovlet hec yer uzunde olmasin", BlogStatus.Created, "BL55555"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("haci@gmail.com"), "Gurcustan", "Sakit ozu ucun yawiyan dovletdir", BlogStatus.Reject, "BL66666"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("E@gmail.com"), "Pul", "Insanin insan kimi yawamasina gore vacib olan nesnedir", BlogStatus.Approve, "BL77777"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("E@gmail.com"), "Vaxt", "Dunyanin en deyerli nesnesi", BlogStatus.Created, "BL88888"));


        }

    }
}
