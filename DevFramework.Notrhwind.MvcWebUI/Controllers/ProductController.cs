using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Notrhwind.MvcWebUI.Models;

namespace DevFramework.Notrhwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll(),
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            { 
                CategoryId = 1, 
                ProductName = "Gsm", 
                QuantityPerUnit = "1", 
                UnitPrice = 21
            });
            return "Added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            { 
                CategoryId = 1, 
                ProductName = "Computer", 
                QuantityPerUnit = "1", 
                UnitPrice = 14
            }, new Product
            { 
                CategoryId = 1, 
                ProductName = "Computer 2", 
                QuantityPerUnit = "1", 
                UnitPrice = 30,
                ProductId = 2
            });

            return "Done";
        }
    }
}