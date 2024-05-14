using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class Fruit:BaseEntity
    {
        public long FruitId { get; set; }
        public string? FruitName { get; set; }
        public string? FruitDescription { get; set; }
        public string? FruitQuantity { get; set; }
        public string? FruitPrice {  get; set; }
        public long CategoriesId { get; set; }
        public string? Discount {  get; set; }
        public string? PriceDiscount {  get; set; }
        public string? FruitImg {  get; set; }
        public long StoreId { get; set; }
        public Store? Store { get; set; }
        public Category? Category { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Bill_Detail>? Bill_Details { get; set; }


    }
}
