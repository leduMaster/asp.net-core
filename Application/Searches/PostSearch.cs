﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class PostSearch : BaseSearch
    {
        public string Keyword { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
