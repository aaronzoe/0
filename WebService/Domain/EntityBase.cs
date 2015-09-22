using System;
using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class EntityBase
    {
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }

        public EntityBase()
        {
            CreateAt = DateTime.Now;
        }
    }
}
