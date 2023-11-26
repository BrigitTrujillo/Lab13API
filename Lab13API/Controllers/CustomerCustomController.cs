using Lab13API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCustomController : ControllerBase
    {

        private readonly InvoiceContext _context;

        public CustomerCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(Customer customer)
        {
            customer.Active = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

  
        [HttpGet]
        public List<Customer> GetOrderedCustomers()
        {
            var response = _context.Customers
                .Where(x => x.Active == true)
                .OrderByDescending(x => x.LastName)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            return response;
        }



        
    }
}