using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Application.Dto.Bill
{
    public class payNow
    {
        public long BillId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Total_amount { get; set; }
        public string? Payments { get; set; }
        public string? Phone { get; set; }
        public long UserId { get; set; }
        public int? Bill_Status { get; set; }
        public long? FruitId { get; set; }
    }
}
