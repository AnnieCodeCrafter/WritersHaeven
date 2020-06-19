﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryService.Models
{
    public class Story
    {

        public int StoryID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public int AuthorID { get; set; }
    }
}
