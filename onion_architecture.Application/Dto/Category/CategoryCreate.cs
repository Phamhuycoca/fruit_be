using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Category
{
    public class CategoryCreate
    {
        public long CategoriesId { get; set; }
        public string? CategoriesName { get; set; }
    }
}
