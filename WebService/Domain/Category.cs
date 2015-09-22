using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class Category
    {
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

    

    }
}