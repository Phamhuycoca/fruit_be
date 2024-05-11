using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Helper
{
    public class CommonListQueryProducts
    {
        public int page { get; set; }
        public int limit { get; set; }
        public string? keyword { get; set; }
        public long CategoriesId { get; set; }
        public string? price {  get; set; }
        public string? sale { get; set; }
        public CommonListQueryProducts()
        {
            page = 1;
            limit = 10;
            keyword = "";
            price = "";
            sale = "";
                
        }
    }
}
