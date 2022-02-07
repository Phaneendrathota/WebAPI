using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.Net_Core_WebAPI.Services;
using ASP.Net_Core_WebAPI.Models;

namespace ASP.Net_Core_WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("api/Customers/Get")]
        [HttpGet]
        public ActionResult<List<Customers>> Get() =>
            _customerService.Get();

        [Route("api/Customers/Get/{id}")]
        [HttpGet]
        //[HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customers> Get(string id)
        {
            var cust = _customerService.Get(id);

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }

        [Route("api/Customers/GetCustomerbyName/{name}")]
        [HttpGet]
        //[HttpGet("{name}")]
        public ActionResult<Customers> GetCustomerbyName(string name)
        {
            var cust = _customerService.GetCustomerbyName(name);

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }

        [Route("api/Customers/GetCustomerbyUserName/{username}")]
        [HttpGet]
        //[HttpGet("{username}")]
        public ActionResult<Customers> GetCustomerbyUserName(string username)
        {
            var cust = _customerService.GetCustomerbyUserName(username);

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }

        [Route("api/Customers")]
        [HttpPost]
        public async Task<IActionResult> Post(Customers newBook)
        {
            await _customerService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [Route("api/Customers")]
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Customers updatedBook)
        {
            var book = _customerService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _customerService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [Route("api/Customers")]
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = _customerService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            await _customerService.RemoveAsync(book.Id);

            return NoContent();
        }


    }
}
