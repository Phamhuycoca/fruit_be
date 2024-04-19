using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Fruit
{
    public class FruitCreate
    {
        public long FruitId { get; set; }
        public string? FruitName { get; set; }
        public string? FruitDescription { get; set; }
        public string? FruitQuantity { get; set; }
        public string? FruitPrice { get; set; }
        public long CategoriesId { get; set; }
        public string? Discount { get; set; }
        public string? PriceDiscount { get; set; }
        public string? FruitImg { get; set; }
        public IFormFile? fileImg { get; set; }
    }
}
