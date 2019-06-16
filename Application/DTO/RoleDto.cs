using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class RoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
