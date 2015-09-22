using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class Customer
    {
        [AutoIncrement]
        public int ID { get; set; }
        public string Khqd { get; set; }
        public string Khmc { get; set; }
        public string Lxr { get; set; }
        public string Lxdh { get; set; }
        public string Shdz { get; set; }

        public string Qy { get; set; }
    }
}