using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _91app.Models
{
    [Table(name:"Products")]
    public class Products
    {
        [Key]
        public string ProductName { set; get; }
        public int Price { set; get; }
        public int Cost { set; get; }

        [NotMapped]
        public Orders Orders { get; set; }
    }
}
