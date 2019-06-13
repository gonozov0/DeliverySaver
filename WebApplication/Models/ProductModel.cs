using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LowerTemperatureLevel { get; set; }
        public int UpperTemperatureLevel { get; set; }
        public int LowerHumidityLevel { get; set; }
        public int UpperHumidityLevel { get; set; }
    }
}
