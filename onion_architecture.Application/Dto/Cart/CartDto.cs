using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Cart
{
    public class CartDto
    {
        public long CartId { get; set; }
        public long FruitId { get; set; }
        public long Quantity { get; set; }
        public long UserId { get; set; }
        public long StoreId { get; set; }
    }
}
