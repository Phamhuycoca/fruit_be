﻿using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class Category:BaseEntity
    {
        public long CategoriesId { get; set; }
        public string? CategoriesName { get; set; }
        public ICollection<Fruit>? Fruits { get; set; }

    }
}
