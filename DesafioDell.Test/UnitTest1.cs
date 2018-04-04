using DesafioDell.Data.Abstract;
using DesafioDell.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DesafioDell.Test
{
    [TestClass]
    public class UnitTest1
    {
        private ICustomerRepository _customerRepository;

        [TestMethod]
        public void TestMethod1()
        {


            IEnumerable<Customer> _customers = _customerRepository.GetAll()
                .OrderBy(u => u.Id)
                .ToList();

                        

        }

    }    
}



