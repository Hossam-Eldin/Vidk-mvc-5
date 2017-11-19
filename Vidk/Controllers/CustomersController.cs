using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidk.Models;
using System.Data.Entity;
using Vidk.ViewModels;
namespace Vidk.Controllers
{
    public class CustomersController : Controller
    {
        private  ApplicationDbContext  _context;

            public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


       public ActionResult  New( )
        {

            var membershipType = _context.MemberShipTypes.ToList();

            var viewModel = new NewCustomerViewModel
            {
                MemberShipTypes = membershipType
            };

            return View(viewModel);
        }

        public ActionResult Create(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        // GET: Customers
        public ActionResult Index()
        {
            var Customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(Customers);
        }


        public ActionResult Details(int id)
        {
            var customer =_context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

         public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();


            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("New", viewModel);
        }   

    }
}