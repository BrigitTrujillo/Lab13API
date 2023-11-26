using Lab13API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
       
            private readonly InvoiceContext _context;

            public FacturaController(InvoiceContext context)
            {
                _context = context;
            }

        [HttpGet]
        public IActionResult GetInvoicesByCustomerFirstName(string firstName)
        {
            var response = _context.Invoices
                .Include(i => i.customer) .Where(i => i.customer != null && 
                i.customer.FirstName.Contains(firstName))
                .OrderByDescending(i => i.customer.FirstName)
                .ToList();

            return Ok(response);
        }







    }
}
