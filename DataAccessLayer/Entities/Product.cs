using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LowerTemperatureLevel { get; set; }
        public int UpperTemperatureLevel { get; set; }
        public int LowerHumidityLevel { get; set; }
        public int UpperHumidityLevel { get; set; }
    }
}
