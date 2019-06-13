using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class DeviceRepository : IDisposable
    {
        private Context db;
        public DeviceRepository()
        {
            db = new Context();
        }
        public void Add(Device device)
        {
            db.Devices.Add(device);
            db.SaveChanges();
        }

        public List<Device> ReadAll()
        {
            return db.Devices.ToList();
        }

        public Device Read(string MAC)
        {
            return db.Devices.First(device => device.MAC == MAC);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
