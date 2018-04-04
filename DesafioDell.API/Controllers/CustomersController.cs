using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioDell.Data.Abstract;
using DesafioDell.Model;
using DesafioDell.API.ViewModels;
using AutoMapper;
using DesafioDell.API.Core;


namespace DesafioDell.API.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private ICustomerRepository _customerRepository;
                
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Get()
        {
            
            IEnumerable<Customer> _customers = _customerRepository.GetAll()                
                .OrderBy(u => u.Id)                
                .ToList();

            IEnumerable<CustomerViewModel> _customersVM = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(_customers);
                       
            return new OkObjectResult(_customers);
        }


        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            Customer _customer = _customerRepository.GetSingle(u => u.Id == id);

            if (_customer != null)
            {
                CustomerViewModel _customerVM = Mapper.Map<Customer, CustomerViewModel>(_customer);
                return new OkObjectResult(_customerVM);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody]CustomerViewModel customer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            Customer _customer = _customerRepository.GetByEmail(customer.Email);

            if(_customer != null)
            {
                //Se exite Atualiza

                _customer.Name = customer.Name;                
                _customerRepository.Commit();

                CreatedAtRouteResult resultEdit = CreatedAtRoute("GetCustomer", new { controller = "Customers", id = _customer.Id }, _customer);
                return resultEdit;

            }

            Customer _newCustomer = new Customer { Name = customer.Name, Email = customer.Email };

            _customerRepository.Add(_newCustomer);
            _customerRepository.Commit();

            customer = Mapper.Map<Customer, CustomerViewModel>(_newCustomer);

            CreatedAtRouteResult result = CreatedAtRoute("GetCustomer", new { controller = "Customers", id = customer.Id }, customer);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer _customerDb = _customerRepository.GetSingle(id);

            if (_customerDb == null)
            {
                return NotFound();
            }
            else
            {
                _customerDb.Name = customer.Name;
                _customerDb.Email = customer.Email;
                _customerRepository.Commit();
            }

            customer = Mapper.Map<Customer, CustomerViewModel>(_customerDb);

            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer _customerDb = _customerRepository.GetSingle(id);

            if (_customerDb == null)
            {
                return new NotFoundResult();
            }
            else
            {                
                _customerRepository.Delete(_customerDb);

                _customerRepository.Commit();

                return new NoContentResult();
            }
        }        
    }
}
