using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IDisposable
    {
        private Context db;
        public OrderRepository()
        {
            db = new Context();
        }

        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void Add(string MAC, int employeeId, int[] productIDs)
        {
            Device device = db.Devices.First(d => d.MAC == MAC);
            Employee emplyee = db.Employees.First(e => e.Id == employeeId);
            List<Product> products = db.Products.Where(p => productIDs.Contains(p.Id)).ToList();
            db.Orders.Add(new Order() { Device = device, Employee = emplyee, Products = products});
            db.SaveChanges();
        }

        public Order Read(int id)
        {
            return db.Orders.Include(order => order.Products)
                .Include(d => d.Employee)
                .Include(order => order.Device)
                .First(d => d.Id == id);
        }

        public IEnumerable<Order> ReadAll()
        {
            return db.Orders.Include(order => order.Products)
                .Include(d => d.Employee)
                .Include(order => order.Device)
                .ToList();
        }

        public void Update(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }

        public void Update(int id, string MAC, int employeeId, int[] productIDs)
        {
            Device device = db.Devices.First(d => d.MAC == MAC);
            Employee emplyee = db.Employees.First(e => e.Id == employeeId);
            List<Product> products = db.Products.Where(p => productIDs.Contains(p.Id)).ToList();
            db.Orders.Update(new Order() { Id = id, Device = device, Employee = emplyee, Products = products });
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            db.Orders.Remove(new Order() { Id = id });
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
