using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _91app.Models
{
    [Table(name: "Orders")]
    public class Orders
    {
        [Key]
        public string OrderId { set; get; }
        public string OrderItem { set; get; }
        public string Status { set; get; }
        public string UserName { set; get; }
        public bool Confirmed { set; get; }

        [NotMapped]
        [ForeignKey("OrderItem")]
        public Products Products { set; get; }
    }
}
