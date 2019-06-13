using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Indication
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public DateTime WorkDateTime { get; set; }
    }
}
