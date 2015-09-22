using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class GoodsMaterial
    {
        [AutoIncrement]
        public int ID { get; set; }

        public int GoodsID { get; set; }

        public int MaterialID { get; set; }

        public decimal Num { get; set; }

        public string MaterialTypeName { get; set; }
        public string MaterialName { get; set; }
        public string Unit { get; set; }
    }
}