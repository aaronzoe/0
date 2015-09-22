using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class Goods
    {
        [AutoIncrement]
        public int ID { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }


        //[Sqlserver.Column("Code", "nvarchar(200)", "", false)]
        //public string Code { get; set; }





        public string Img { get; set; }

      //[Sqlserver.Column("SN", "varchar(200)", "", false)]


        //public string SN { get; set; }


      

        public string Size { get; set; }


    
        public decimal Price1 { get; set; }



        public decimal Price2 { get; set; }

        public string NewName {
            get { return Category + "-" + Name ; }
        }
      
        public decimal Weight { get; set; }



           public decimal Volume { get; set; }  
    }
}