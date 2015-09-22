using System;

namespace WebService.Domain
{
    public class UserSign:EntityBase
    {
      
        public string Name { get; set; }
          public DateTime? SignTime { get; set; }
          public string Location { get; set; }

             public string IP { get; set; }

          public string CName { get; set; }

    }
}