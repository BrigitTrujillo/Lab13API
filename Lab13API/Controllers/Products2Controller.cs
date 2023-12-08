using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab13API.Models.Request;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Lab13API.Models;

namespace Lab13API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Products2Controller : ControllerBase
    {
        private readonly InvoiceContext _context;

        public Products2Controller(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProductsPrice(double price)
        {
            var response = _context.Products.Where(x => x.Price > price).ToList();

            return response;
        }

        [HttpGet]
        public Product GetProductPrice(double price)
        {
            var response = _context.Products.
                Where(x => x.Price > price).
                FirstOrDefault();

            return response;
        }

        [HttpPost]
        public void Insert(ProductV1 request)
        {

            Product product = new Product
            {
                Price = request.Price,
                Name = request.Name,
                IsActive = true
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        [HttpPost]
        public void UpdatePrice(ProductV2 request)
        {

            var product = _context.Products.Find(request.ProductID);
            product.Price = request.Price;
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        [HttpPost]
        public void InsertRange(List<ProductV1> request)
        {
            int cont = 0;
            List<Product> products = new List<Product>();

            foreach (var item in request)
            {
                cont++;
                Product product = new Product
                {
                    Price = item.Price,
                    Name = item.Name,
                    Active = true
                };
                if (cont == 2)
                    product.ProductID = 1;

                products.Add(product);
            }

            _context.Products.AddRange(products);
            _context.SaveChanges();


        }

        [HttpPost]
        public void DeleteProduct(ProductV3 request)
        {
            var product = _context.Products.Find(request.ProductID);

            if (product != null)
            {
            
                product.IsActive = false;
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }


        [HttpPost]
        public void UpdatePrice(ProductV4 request)
        {
            var product = _context.Products.Find(request.ProductId);

            if (product != null)
            {
                product.Price = request.Price;
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public void DeleteRange(List<ProductV3> request)
        {
            List<int> productsIdToDelete = request.Select(item => item.ProductID).ToList();

         
            var productsToDelete = _context.Products.Where(product => productsIdToDelete.Contains(product.ProductID)).ToList();

       
            _context.Products.RemoveRange(productsToDelete);
            _context.SaveChanges();
        }






    }
}





