using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers.Customers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
       
            return View(GetCustomers());
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
                
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer() {Name = "Json", Id = 1},
                new Customer() {Name = "Python", Id= 2},
            };

            return customers;

        }
        
    }
}