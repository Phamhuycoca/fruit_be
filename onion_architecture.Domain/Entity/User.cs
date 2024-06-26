﻿using onion_architecture.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Domain.Entity
{
    public class User:BaseEntity
    {
        public long UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PassWord { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set;}
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string? Role { get; set; }
        public bool? Is_Active { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Refresh_Token>? Refresh_Tokens{ get; set; }
        public ICollection<Bill>? Bills { get; set; }

    }
}
