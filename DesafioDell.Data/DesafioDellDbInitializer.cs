using DesafioDell.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDell.Data
{
    public class DesafioDellDbInitializer
    {
        private static DesafioDellContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (DesafioDellContext)serviceProvider.GetService(typeof(DesafioDellContext));

            //InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            /*
            if(!context.Customers.Any())
            {
                Customer customer_01 = new Customer { Name = "Jonhson Rafael", Email = "johnson.rafael@gmail.com", DateCreated = DateTime.Now };

                context.Customers.Add(customer_01);

                context.SaveChanges();

            }
            */
        }
    }
}
