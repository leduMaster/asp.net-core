using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Post : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PostTag> PostTags { get; set; }


    }
}
