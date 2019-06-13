using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            OrderRepository orderRepository = new OrderRepository();
            IndicationRepository indicationRepository = new IndicationRepository();
            var order = orderRepository.ReadAll().First();
            Indication indication = new Indication() { Order = order, Humidity = 40, Temperature = 20 };
            indicationRepository.Add(order.Id, 40, 20, new DateTime());
            orderRepository.Dispose();
            indicationRepository.Dispose();
            */
            //DeviceRepository deviceRepository = new DeviceRepository();
            //Device device = new Device() { MAC = "80:7d:3a:7f:fa:a5" };
            //deviceRepository.Add(device);
            //deviceRepository.Dispose();
        }
    }
}
