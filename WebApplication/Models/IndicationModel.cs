using System;
using System.Collections.Generic;
using System.Text;


namespace WebApplication.Models
{
    public class IndicationModel
    {
        public int Id { get; set; }
        public OrderModel Order { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime WorkDateTime { get; set; }
    }
}
