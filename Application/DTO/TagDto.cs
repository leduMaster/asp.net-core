using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class TagDto : BaseDto
    {
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
