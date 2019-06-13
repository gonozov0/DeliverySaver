using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Device
    {
        [Key]
        public string MAC { get; set; }
    }
}
