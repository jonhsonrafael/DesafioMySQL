using DesafioDell.Data.Abstract;
using DesafioDell.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDell.Data.Repositories
{
    public class CustomerRepository : EntityBaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DesafioDellContext context)
            : base(context)
        { }
    }
}
