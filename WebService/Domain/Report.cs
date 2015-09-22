using System;
using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class Report
    {
             [AutoIncrement]
        public int ID { get; set; }
           public int Wid { get; set; }
        public DateTime Rq { get; set; }
           public string Sj { get; set; }

        public string Gzjh { get; set; }

        public string Sjdc { get; set; }

        public string UserID { get; set; }

    }
}