using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Store
{
    public class StoreQuery:BaseEntity
    {
        public long StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string Lat { get; set; }//Vĩ độ
        public string Lng { get; set; }//Kinh độ
    }
}
