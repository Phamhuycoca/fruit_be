using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class Store:BaseEntity
    {
        public long StoreId { get; set; }
        public string? StoreName { get; set; }
        public string? StoreAddress{ get; set; }
        public string? Lat { get; set; }//Vĩ độ
        public string? Lng { get; set; }//Kinh độ
        public string? StoreType { get; set; }
        public string? StorePhone{ get; set; }
        public ICollection<Fruit>? Fruits { get; set;}
        public ICollection<Cart>? Carts { get; set; }

    }
}
