using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WebApplication.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DeviceModel Device { get; set; }
        public EmployeeModel Employee { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
