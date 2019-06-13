using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DataAccessLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Device Device { get; set; }
        public Employee Employee { get; set; }
        public List<Product> Products { get; set; }
    }
}
