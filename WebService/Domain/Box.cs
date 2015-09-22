using ServiceStack.DataAnnotations;

namespace WebService.Domain
{

    public class Box
    {
       [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public int Amount { get; set; }
    }
}