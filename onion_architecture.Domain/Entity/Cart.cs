using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class Cart:BaseEntity
    {
        public long CartId { get; set; }
        public long FruitId { get; set; }
        public long Quantity { get; set; } 
        public long UserId { get; set; }
        public Fruit? Fruit { get; set;}
        public User? User { get; set; }
    }
}
