using Lab13API.Models;
using Lab13API.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Invoices2Controller : ControllerBase
    {
        public class InvoicesController : ControllerBase
        {
            private readonly InvoiceContext _context;

            public InvoicesController(InvoiceContext context)
            {
                _context = context;
            }


            [HttpPost]
            public void Insert(InvoiceV1 request)
            {

                Invoice invoice = new Invoice
                {
                    InvoiceId = request.InvoiceID,
                    Date = request.Date,
                    InvoiceNumber = request.InvoiceNumber,
                    Total = request.Total,

                };

                _context.Invoices.Add(invoice);
                _context.SaveChanges();
            }


        }
     






    }
}
