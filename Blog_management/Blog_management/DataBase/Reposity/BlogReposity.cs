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
    


       static BlogReposity bb=new BlogReposity(); 
        private static string _blogCode;

        public static string BlogCode
        {
            get
            {
                List<Blog> blogs = bb.GetAll();
              
                bool  go = true;
                string newCode = "";

                

                while (go)
                { 
                    int lastId = 0;
                    
                    
                    foreach (Blog blog in blogs)
                    {
                        if (blog.Id == newCode)
                        {
                            newCode = "BL" + _random.Next(10000,10000);
                            
                        }
                        lastId++;
                    }

                    if (lastId == blogs.Count)
                    {
                        go = false;

                    }
                  
                }


                return newCode;
            }
        }

        static BlogReposity()
        {
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("ayroali@gmail.com"), "Azerbaycan", "Qarabag Azerbaycandir", BlogStatus.Approve ,"BL11111" ));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("ayroali@gmail.com"), "Rusiya", "Rusiya cox iki uzlu dovletdir", BlogStatus.Created, "BL2222"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("ayroali@gmail.com"), "Iran", "Iran cox xain dovletdir", BlogStatus.Reject, "BL33333"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("haci@gmail.com"), "Amerika", "amerika cox demokratik ve alim quvvesi boyuk olan dovletdir", BlogStatus.Approve));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("haci@gmail.com"), "Ermenistan", "Mumkundurse bele dovlet hec yer uzunde olmasin", BlogStatus.Created, "BL55555"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("haci@gmail.com"), "Gurcustan", "Sakit ozu ucun yawiyan dovletdir", BlogStatus.Reject, "BL66666"));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("E@gmail.com"), "Pul", "Insanin insan kimi yawamasina gore vacib olan nesnedir", BlogStatus.Approve));
            DBcontect.Add(new Blog(UserReposity.GetUerByEmail("E@gmail.com"), "Vaxt", "Dunyanin en deyerli nesnesi", BlogStatus.Created, "BL88888"));


        }

    }
}
