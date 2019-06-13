using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class IndicationRepository : IDisposable
    {
        private Context db;
        public IndicationRepository()
        {
            db = new Context();
        }

        public void Add(Indication indication, string MAC)
        {
            indication.Order = db.Orders.Where(o => o.Device.MAC == MAC).OrderByDescending(o => o.Id).First();
            db.Indications.Add(indication);
            db.SaveChanges();
        }

        public void Add(int orderId, int temperature, int humidity, DateTime dateTime)
        {
            Order order = db.Orders.Find(orderId);
            db.Indications.Add(new Indication() { Order = order, Humidity = humidity, Temperature = temperature, WorkDateTime = dateTime });
            db.SaveChanges();
        }

        public List<Indication> Read(Order order)
        {
            return db.Indications.Include(indication => indication.Order)
                .Where(indication => (indication.Order.Id == order.Id)).ToList();
        }

        public IEnumerable<Indication> ReadAll()
        {
            return db.Indications.Include(indicate => indicate.Order)
                .ToList();
        }

        public void Update(Indication indication)
        {
            db.Indications.Update(indication);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            db.Indications.Remove(new Indication() { Id = id });
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
