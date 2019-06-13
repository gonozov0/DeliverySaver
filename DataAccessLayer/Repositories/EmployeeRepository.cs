using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IDisposable
    {
        private Context db;
        public EmployeeRepository()
        {
            db = new Context();
        }

        public void Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public Employee Read(int id)
        {
            return db.Employees.First(employee => employee.Id == id);
        }

        public IEnumerable<Employee> ReadAll()
        {
            return db.Employees.ToList();
        }

        public void Update(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            db.Employees.Remove(new Employee() { Id = id });
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
