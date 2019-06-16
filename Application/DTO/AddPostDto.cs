using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class AddPostDto
    {
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Post name must have at least 3 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(3, ErrorMessage = "Post Description must have at least 3 characters.")]
        public string Description { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [MinLength(13, ErrorMessage = "Picture url must have at least 3 characters.")]
        public string Picture { get; set; }
    }
}
