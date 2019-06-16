using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class UserDTO : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted
        {
            get; set;
        }
        public int CreatedBy { get; set; }


    }
}
