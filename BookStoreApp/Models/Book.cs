﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public String ImageURL { get; set; }

        public Author Author { get; set; }

    }
}
