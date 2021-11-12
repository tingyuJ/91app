using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _91app.Models
{
    public class ViewModelOrderList
    {
        public string OrderId { set; get; }
        public string OrderItem { set; get; }
        public string Status { set; get; }
        public int Price { set; get; }
        public int Cost { set; get; }
        public bool Confirmed { set; get; }
    }
}
