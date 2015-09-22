using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class FamilyTree
    {
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Job { get; set; }

        public string Area { get; set; }

        public string Tel { get; set; }

        public string Wx { get; set; }

        public string QQ { get; set; }

        public string EMail { get; set; }

        public string ShortNum { get; set; }

        public string Address { get; set; }
    }
}