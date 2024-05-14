using onion_architecture.Domain.Entity;
using onion_architecture.Domain.Repositories;
using onion_architecture.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Infrastructure.Repositories
{
    public class Bill_DetailRepository : GenericRepository<Bill_Detail>, IBill_DetailRepository
    {
        public Bill_DetailRepository(onion_architecture_Context context) : base(context)
        {
        }
    }
}
