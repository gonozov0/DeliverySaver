using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        [HttpGet("all")]
        public IActionResult All()
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                var products = Mapper.Map<List<ProductModel>>(productRepository.ReadAll());
                return View(products);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Info(int id)
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                var product = Mapper.Map<ProductModel>(productRepository.Read(id));
                return View(product);
            }
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Add(ProductModel product)
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                var newProduct = Mapper.Map<Product>(product);
                productRepository.Add(newProduct);
                return Redirect("~/product/all");
            }
        }

        [HttpPost("{id}")]
        public IActionResult Update(ProductModel product, int id)
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                var newProduct = Mapper.Map<Product>(product);
                newProduct.Id = Int32.Parse((string)RouteData.Values["id"]);
                productRepository.Update(newProduct);
                return Redirect("~/product/all");
            }
        }
    }
}