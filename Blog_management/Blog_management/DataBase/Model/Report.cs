using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_management.DataBase.Model
{
    internal class Report : Entity<int>
    {
        public string Content { get; set; }

        public User From { get; set; }

        public User To { get; set; }

        public DateTime ReportDate { get; set; } = DateTime.Now;

        public Report(string content, User from, User to, int? id = null)
        {
            Content = content;
            From = from;
            To = to;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserReposity.IdCounter;
            }
        }

        public string GetInfo()
        {
            return $"From : {From.Email}, To : {To.Email}, Content : {Content},Is Admin{To is Admin}, Report date: {ReportDate.ToString("HH:mm dd.MM.yyyy")}";
        }
    }
}
