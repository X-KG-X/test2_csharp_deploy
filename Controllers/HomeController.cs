using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using belt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace belt.Controllers
{

    public class HomeController : Controller
    {
        private MyContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("register")]

        public IActionResult Register(IndexViewModel dataModel)
        {
            // Check initial ModelState
            if(ModelState.IsValid)
            {
                // If a User exists with provided email
                if(dbContext.Users.Any(u => u.Email == dataModel.NewUser.Email))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("NewUser.Email", "Email already in use!");
                    
                    // You may consider returning to the View at this point
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher =new PasswordHasher<User>();
                    dataModel.NewUser.Password=Hasher.HashPassword(dataModel.NewUser, dataModel.NewUser.Password);
                    dbContext.Add(dataModel.NewUser);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetInt32("UserId",(int)dataModel.NewUser.UserId);
                    return RedirectToAction("success");
                }
            }
            // other code
            return View("Index");
        } 


        [HttpPost("login")]
        public IActionResult Login(IndexViewModel dataModel)
        {
            if(ModelState.IsValid)
            {
                // If inital ModelState is valid, query for a user with provided email
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == dataModel.NewLogin.Email);
                // If no user exists with provided email
                if(userInDb == null)
                {
                    // Add an error to ModelState and return to View!
                    ModelState.AddModelError("NewLogin.Email", "Invalid Email");
                    return View("Index");
                }
                
                // Initialize hasher object
                var hasher = new PasswordHasher<Login>();
                
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(dataModel.NewLogin, userInDb.Password, dataModel.NewLogin.Password);
                
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    // handle failure (this should be similar to how "existing email" is handled)
                    ModelState.AddModelError("NewLogin.Password", "Password mismatch");
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId",userInDb.UserId);
                    return RedirectToAction("success");
                }
            }
            return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            if (HttpContext.Session.GetInt32("UserId")!=null)
            {
                int? _UserId=HttpContext.Session.GetInt32("UserId");
                ViewBag.userId= (int) _UserId;

                List<Product> _someProducts=dbContext.Products.OrderBy(p=>p.CreatedAt).Take(5).ToList();
                ViewBag.someProducts=_someProducts;

                List<Order> _someOrders=dbContext.Orders.Include(o=>o.Customer).Include(o=>o.Product).Take(3).ToList();
                ViewBag.someOrders=_someOrders; 

                List<Customer> _someCustomers= dbContext.Customers.OrderBy(c=>c.CreatedAt).Take(3).ToList();
                ViewBag.someCustomers=_someCustomers;

                return View("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("newOrder")]
        public IActionResult newOrder()
        {
            List <Order> _allOrders=dbContext.Orders.Include(o=>o.Customer).Include(o=>o.Product).ToList();
            ViewBag.allOrders=_allOrders;

            List<Customer> _allCustomers=dbContext.Customers.ToList();
            ViewBag.allCustomers=_allCustomers;

            List<Product> _allProducts=dbContext.Products.ToList();
            ViewBag.AllProducts=_allProducts;

            return View("Orders");
        }

        [HttpPost("addOrder")]
        public IActionResult addOrder(Order dataModel)
        {

            Product thisProduct= dbContext.Products.FirstOrDefault(p=>p.ProductId==dataModel.ProductId);
            if(thisProduct.Inventory<dataModel.Quantity)
            {
                ModelState.AddModelError("Quantity","Inventory is less than the Order Quantity!!!");

                List <Order> _allOrders=dbContext.Orders.OrderByDescending(o=>o.CreatedAt).Include(o=>o.Customer).Include(o=>o.Product).ToList();
                ViewBag.allOrders=_allOrders;

                List<Customer> _allCustomers=dbContext.Customers.ToList();
                ViewBag.allCustomers=_allCustomers;

                List<Product> _allProducts=dbContext.Products.ToList();
                ViewBag.AllProducts=_allProducts;

                return View("Orders");
            }
            thisProduct.Inventory-=dataModel.Quantity; 
            dbContext.Add(dataModel);
            dbContext.SaveChanges();
            return RedirectToAction("newOrder");

        }

        [HttpGet("newCustomer")]
        public IActionResult newCustomer()
        {
            List <Customer> _allCustomers=dbContext.Customers.ToList();
            ViewBag.allCustomers=_allCustomers;
            return View("Customers");
        }

        [HttpPost("addCustomer")]
        public IActionResult addCustomer(Customer dataModel)
        {
            if(ModelState.IsValid)
            {
                if (dbContext.Customers.Any(c=>c.Name==dataModel.Name))
                {
                    ModelState.AddModelError("Name","Customer Name already in use");
                    List <Customer> _Customers=dbContext.Customers.ToList();
                    ViewBag.allCustomers=_Customers;
                    return View("Customers");
                }
                dbContext.Add(dataModel);
                dbContext.SaveChanges();
                return RedirectToAction("newCustomer");
            }
            List <Customer> _allCustomers=dbContext.Customers.ToList();
            ViewBag.allCustomers=_allCustomers;
            return View("Customers");
        }

        [HttpGet("removeCustomer/{CustomerId}")]
        public IActionResult removeCustomer(int CustomerId)
        {
            Customer thisCustomer=dbContext.Customers.FirstOrDefault(c=>c.CustomerId==CustomerId);
            dbContext.Customers.Remove(thisCustomer);
            dbContext.SaveChanges();
            return RedirectToAction("newCustomer");
        }

        [HttpGet("newProduct")]
        public IActionResult newProduct()
        {
            List <Product> _allProducts=dbContext.Products.ToList();
            ViewBag.allProducts=_allProducts;
            return View("Products");
        }

        [HttpPost("addProduct")]
        public IActionResult addProduct(Product dataModel)
        {
            if (!ModelState.IsValid)
            {
                List <Product> _allProducts=dbContext.Products.ToList();
                ViewBag.allProducts=_allProducts;
                return View("Products");
            }
            dbContext.Add(dataModel);
            dbContext.SaveChanges();
            return RedirectToAction("newProduct");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
