using System;
using System.Collections.Generic;
using System.Text;

namespace BootcampTap.Core.Models
{
    public class Promotion
    {
        public string Id { get; set; }
        public string Product { get; set; }
        public string StoreId { get; set; }
        public int Discount { get; set; }
    }
}
