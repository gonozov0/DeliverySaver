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
using DataAccessLayer;

namespace WebApplication.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {

        [HttpGet("all")]
        public IActionResult All()
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                var employees = Mapper.Map<List<EmployeeModel>>(employeeRepository.ReadAll());
                return View(employees);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Info(int id)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                var employee = Mapper.Map<EmployeeModel>(employeeRepository.Read(id));
                return View(employee);
            }
        }
        
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(EmployeeModel employee)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                var newEmployee = Mapper.Map<Employee>(employee);
                employeeRepository.Add(newEmployee);
                return Redirect("~/employee/all");
            }
        }

        [HttpPost("{id}")]
        public IActionResult Update(EmployeeModel employee)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository())
            {
                var newEmployee = Mapper.Map<Employee>(employee);
                newEmployee.Id = Int32.Parse((string)RouteData.Values["id"]);
                employeeRepository.Update(newEmployee);
                return Redirect("~/employee/all");
            }
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(EmployeeModel employee)
        //{
        //    int id = Int32.Parse((string)RouteData.Values["id"]);
        //    employeeRepository.Remove(id);
        //    return RedirectToAction("all");
        //}
    }
}