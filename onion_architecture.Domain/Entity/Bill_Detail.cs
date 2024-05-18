using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class Bill_Detail : BaseEntity
    {
        public long? Bill_Detail_Id { get; set; }
        public long? BillId { get; set; }
        public long? FruitId { get; set; }
        public long? Quantity { get; set; }
        public long? StoreId { get; set; }
        public Store? Store { get; set; }
        public Fruit? Fruit { get; set;}
        public Bill? Bill { get; set; }
    }
}
