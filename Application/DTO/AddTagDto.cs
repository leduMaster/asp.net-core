using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class AddTagDto
    {

        [Required]
        public string Content { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
