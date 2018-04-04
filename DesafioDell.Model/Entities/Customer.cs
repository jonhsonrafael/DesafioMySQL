using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDell.Model
{
    public class Customer : IEntityBase
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
