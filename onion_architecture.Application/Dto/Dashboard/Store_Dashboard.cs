using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Dashboard
{
    public class Store_Dashboard
    {
        public long StoreId { get; set; }
        public string? StoreName { get; set; }
        public long Revenue {  get; set; } //Doanh thu
    }
}
