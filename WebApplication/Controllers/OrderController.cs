using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using AutoMapper;

namespace WebApplication.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        [HttpGet("all")]
        public IActionResult All()
        {
            using (OrderRepository orderRepository = new OrderRepository())
            {
                var orders = Mapper.Map<List<OrderModel>>(orderRepository.ReadAll());
                return View(orders);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Info(int id)
        {
            DeviceRepository deviceRepository = new DeviceRepository();
            ProductRepository productRepository = new ProductRepository();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            OrderRepository orderRepository = new OrderRepository();
            IndicationRepository indicationRepository = new IndicationRepository();
            using (orderRepository) using (deviceRepository) using (productRepository) using (employeeRepository) using (indicationRepository)
            {
                ViewBag.Employees = Mapper.Map<List<EmployeeModel>>(employeeRepository.ReadAll());
                ViewBag.Products = Mapper.Map<List<ProductModel>>(productRepository.ReadAll());
                ViewBag.Devices = Mapper.Map<List<DeviceModel>>(deviceRepository.ReadAll());
                var order = Mapper.Map<OrderModel>(orderRepository.Read(id));
                var indications = Mapper.Map<List<IndicationModel>>(indicationRepository.Read(Mapper.Map<Order>(order)));
                var productViewDataList = new List<ProductViewData>();
                foreach (var product in order.Products)
                {
                    productViewDataList.Add(new ProductViewData(product, indications));
                }
                ViewBag.productViewDataList = productViewDataList;
                return View(order);
            }
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            DeviceRepository deviceRepository = new DeviceRepository();
            ProductRepository productRepository = new ProductRepository();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            using (deviceRepository) using (productRepository) using (employeeRepository)
            {
                ViewBag.Employees = Mapper.Map<List<EmployeeModel>>(employeeRepository.ReadAll());
                ViewBag.Products = Mapper.Map<List<ProductModel>>(productRepository.ReadAll());
                ViewBag.Devices = Mapper.Map<List<DeviceModel>>(deviceRepository.ReadAll());
                return View();
            }
        }

        [HttpPost]
        public IActionResult Add(string MAC, int employeeId, int[] productIDs)
        {
            OrderRepository orderRepository = new OrderRepository();
            using(orderRepository)
            {
                orderRepository.Add(MAC, employeeId, productIDs);
                return Redirect("~/order/all");
            }
        }

        [HttpPost("{id}")]
        public IActionResult Update(string MAC, int employeeId, int[] productIDs)
        {
            using (OrderRepository orderRepository = new OrderRepository())
            {
                int id = Int32.Parse((string)RouteData.Values["id"]);
                orderRepository.Update(id, MAC, employeeId, productIDs);
                return Redirect("~/order/all");
            }
        }
    }
}