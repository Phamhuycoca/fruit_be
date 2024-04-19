using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Helper
{
    public class CommonListQuery
    {
        public int page { get; set; }
        public int limit { get; set; }
        public string? keyword { get; set; } 
        public CommonListQuery()
        {
            page = 1;
            limit = 10;
            keyword = "";
        }

    }
}
