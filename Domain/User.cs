using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public Role Role { get; set; }

    }
}
