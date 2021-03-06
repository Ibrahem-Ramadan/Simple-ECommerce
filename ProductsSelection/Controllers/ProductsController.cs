using ProductsSelection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsSelection.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        static ApplicationDbContext _dbContext;
        static List<Product> SelectedProducts;

        //initialize static data members 
        static ProductsController()
        {
            _dbContext = new ApplicationDbContext();
            SelectedProducts = new List<Product>();
        }
        //show all products
        public ActionResult Products()
        {
            return View(_dbContext.Products.ToList());
        }

        [HttpPost]
        //adding item to cart and return updated cart
        public ActionResult AddToCart(int? productId)
        {
            var selectedProduct = _dbContext.Products.Find(productId);
            if (selectedProduct != null && !SelectedProducts.Exists(p=> p.Id == selectedProduct.Id))
                SelectedProducts.Add(selectedProduct);
            return PartialView(SelectedProducts);

        }

        [HttpPost]
        //delete item from cart and return updated cart
        public ActionResult DeleteFromCart(int productId,string partialName)
        {
            if (SelectedProducts.Exists(p => p.Id == productId))
                SelectedProducts.Remove(SelectedProducts.Find(p=>p.Id==productId));
            return partialName== "AddToCart" ? PartialView(partialName, SelectedProducts): PartialView("CartDetails", SelectedProducts);

        }

        public void SaveSelectedProducts()
        {
            //remove old saved items and save new selected items
            foreach (var selectedProduct in _dbContext.SelectedProducts.ToList())
                _dbContext.SelectedProducts.Remove(selectedProduct);

            foreach (var product in SelectedProducts)
            {
                _dbContext.SelectedProducts.Add(new SelectedProduct { 
                    ProductName = product.ProductName, 
                    ProductCategory=product.ProductCategory,
                    ProductDiscription = product.ProductDiscription,
                    ProductImg = product.ProductImg,
                    ProductPrice=product.ProductPrice
                });
            }
            _dbContext.SaveChanges();
        }

        //popup partial view
        public ActionResult CartDetails()
        {
            return PartialView(SelectedProducts);
        }

    }
}