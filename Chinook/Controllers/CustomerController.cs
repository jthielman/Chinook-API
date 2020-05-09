using System.Linq;
using Chinook.Data;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer/brazil
        [HttpGet("{country}")]
        public IActionResult GetByCountry(string country)
        {
            var repo = new CustomerRepository();
            var customers = repo.GetByCountry(country);

            if (!customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET: api/Customer/brazil/invoices
        [HttpGet("{country}/invoices")]
        public IActionResult GetInvoicesByCountry(string country)
        {
            var repo = new CustomerRepository();
            var invoices = repo.GetInvoicesByCountry(country);

            if (!invoices.Any())
            {
                return NotFound();
            }
            return Ok(invoices);
        }
    }
}
