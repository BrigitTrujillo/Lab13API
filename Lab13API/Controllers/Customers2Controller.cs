using Lab13API.Models;
using Lab13API.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Customers2Controller : ControllerBase
    {
        private readonly InvoiceContext _context;

        public Customers2Controller(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(CustomerV1 request)
        {

            Customer customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DocumentNumber = request.DocumentNumber,
                Active = true
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        [HttpPost]
        public void DeleteCustomer(CustomerV2 request)
        {
            var customer = _context.Products.Find(request.CustomerID);

            if (customer != null)
            {

                customer.IsActive = false;
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
            }

        }


        [HttpPost]
        public void UpdateDocumentNumber(CustomerV3 request)
        {
            var customer = _context.Customers.Find(request.CustomerId);

            if (customer != null)
            {
                customer.DocumentNumber = request.DocumentNumber;
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


        [HttpPost]
        public void InsertInvoiceCustomer(CustomerV4 request)
        {
            var customer = _context.Customers
                .Include(c => c.CustomerId)
                .FirstOrDefault(c => c.CustomerId == request.CustomerId);

            if (customer != null)
            {
                
                foreach (var invoice in request.Invoices)
                {
                    invoice.CustomerId = request.CustomerId;
                }

                _context.Invoices.AddRange(request.Invoices);
                _context.SaveChanges();
            }
        }



    }
}
