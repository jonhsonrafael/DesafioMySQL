using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDell.Model
{
    public interface IEntityBase
    {
        int Id { get; set; }
        string Email { get; set; }

    }
}
