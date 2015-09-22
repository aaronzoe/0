using System;
using ServiceStack.DataAnnotations;

namespace WebService.Domain
{

    public class Approval
    {
        [AutoIncrement]
        public int ID { get; set; }

        public int OrderID { get; set; }

        public decimal Je { get; set; }

        public DateTime CreateAt { get; set; }

        public string SqrID { get; set; }

        public string Neirong { get; set; }

        public string Qyjlyj { get; set; }
        public string QyjlID { get; set; }
        public DateTime QyjlTime { get; set; }


        public string Xszjyj { get; set; }
        public string XszjID { get; set; }
        public DateTime XszjTime { get; set; }


        public string Zjlyj { get; set; }
        public string ZjlID { get; set; }
        public DateTime ZjlTime { get; set; }
        public string SpUserID { get; set; }
        public string SpUserID2 { get; set; }
        public int FlowNo { get; set; }
        public string Atts { get; set; }

        public string QyjlName { get; set; }
        public string XszjName { get; set; }
        public string ZjlName { get; set; }
    }
}