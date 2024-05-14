using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class Bill:BaseEntity
    {
        public long BillId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Total_amount { get; set; }
        public string? Payments { get; set; }
        public string? Phone { get; set; }
        public long UserId { get; set; }
        public int? Bill_Status { get; set; }
        public User? User { get; set; }
        public ICollection<Bill_Detail>? Bill_Details { get; set; }

    }
}
