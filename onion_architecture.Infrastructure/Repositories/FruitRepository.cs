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
    public class FruitRepository : GenericRepository<Fruit>, IFruitRepository
    {
        public FruitRepository(onion_architecture_Context context) : base(context)
        {
        }
    }
}
