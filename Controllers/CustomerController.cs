using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICustomer.Data;
using APICustomer.Models;

namespace APICustomer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly APIDbContext _db;
        public CustomerController(APIDbContext apidbcontext)
        {
            _db = apidbcontext;
        }

        //GET: api/Customer
        [HttpGet]
        public IResult GetCustomers()
        {
            var customers = _db.Customers;
            if (customers == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(_db.Customers);
            }
        }

        //GET: api/Customer/1
        [HttpGet("{id}")]
        public IResult GetCustomers(int id)
        {
            var customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public IResult CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return Results.BadRequest(customer);
            }
            else
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return Results.Created($"/Customer/{customer.Id}", customer);
            }
        }

        //PUT: api/Customer/id
        [HttpPut("{id}")]
        public IResult UpdateCustomer(int id, Customer customerPUT)
        {
            if (id == 0)
            {
                return Results.BadRequest(id);
            }
            else
            {
                var customer = _db.Customers.Find(id);
                if (customer == null)
                {
                    return Results.NotFound(customer);
                }
                else
                {
                    customer.PhoneNumber = customerPUT.PhoneNumber;
                    customer.Name = customerPUT.Name;

                    _db.Customers.Update(customer);
                    _db.SaveChanges();
                    return Results.NoContent();
                }
            }
        }

        //DEL: api/Customer/id
        [HttpDelete("{id}")]
        public IResult DeleteCustomer(int id)
        {
            if (id == 0)
            {
                return Results.BadRequest(id);
            }
            else
            {
                var customer = _db.Customers.Find(id);
                if (customer == null)
                {
                    return Results.NotFound(customer);
                }
                else
                {
                    _db.Customers.Remove(customer);
                    _db.SaveChanges();
                    return Results.Ok(customer);
                }
            }
        }
    }
}
