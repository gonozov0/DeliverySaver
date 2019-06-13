using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using AutoMapper;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("indication")]
    public class IndicationController : Controller
    {
        /*
        [HttpGet("choice")]
        public IActionResult Choice()
        {
            using (OrderRepository orderRepository = new OrderRepository())
            {
                ViewBag.Orders = Mapper.Map<List<OrderModel>>(orderRepository.ReadAll());
                ViewData["orederId"] = order == null ? -1 : order.Id;
                return View();
            }
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            if (date == null || order == null) return Redirect("~/indication/choice");
            using (IndicationRepository indicationRepository = new IndicationRepository())
            {
                ViewBag.Employee = order.Employee;
                var indications = Mapper.Map<List<IndicationModel>>(indicationRepository.Read(Mapper.Map<Order>(order), date));
                var productViewDataList = new List<ProductViewData>();
                foreach (var product in order.Products)
                {
                    productViewDataList.Add(new ProductViewData(product, indications));
                }
                return View(productViewDataList);
            }
        }
        /*
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost("choice")]
        public IActionResult Choice(int orderId, DateTime date)
        {
            using (OrderRepository orderRepository = new OrderRepository())
            {
                this.order = Mapper.Map<OrderModel>(orderRepository.Read(orderId));
            }
            this.date = date;
            return Redirect("~/indication/all");
        }
        */
        [HttpPost("from-device")]
        public void Add([FromBody] IndicationsDeviceData indicationsDeviceData)
        {
            IndicationRepository indicationRepository = new IndicationRepository();
            using (indicationRepository)
            {
                var newIndication = new Indication() { Temperature = indicationsDeviceData.Temperature, Humidity = indicationsDeviceData.Humidity, WorkDateTime = new DateTime()};
                indicationRepository.Add(newIndication, indicationsDeviceData.MAC);
            }
        }
    }
}