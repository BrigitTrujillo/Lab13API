using Lab13API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailController : ControllerBase
    {

        private readonly InvoiceContext _context;

        public DetailController(InvoiceContext context)
        {
            _context = context;
        }



        [HttpGet("{invoiceNumber}")]
        public IActionResult GetInvoiceDetailsByNumber(string invoiceNumber)
        {
            var response = _context.Details
                .Include(x => x.invoice)
                    .ThenInclude(x => x.customer)
                .Where(x=> x.invoice.InvoiceNumber == invoiceNumber)
                .OrderBy(x => x.invoice.customer.FirstName)
                .ThenBy(x => x.invoice.InvoiceNumber)
                .ToList();

            return Ok(response);
        }

    }
}
