using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class IndicationsDeviceData
    {
        public string MAC { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
    }
}
