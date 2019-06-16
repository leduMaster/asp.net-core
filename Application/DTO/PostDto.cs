using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.DTO
{
    public class PostDto : BaseDto
    {

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Category name must have at least 3 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Category Description must have at least 3 characters.")]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<string> TagsName { get; set; }
    }
}
