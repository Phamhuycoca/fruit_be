﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Bill_Detail
{
    public class Bill_Detail_Fruit
    {
        public long? Bill_Detail_Id { get; set; }
        public long? BillId { get; set; }
        public long? FruitId { get; set; }
        public long? Quantity { get; set; }
        public string? FruitName { get; set; }
        public string? FruitImg { get; set; }
    }
}
