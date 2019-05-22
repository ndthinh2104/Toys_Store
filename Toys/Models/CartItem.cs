using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toys.Models
{
    [Serializable]
    public class CartItem
    {
        public int Id_Product { get; set; }
        public int Amount { get; set; }
        public decimal? price { get; set; } 
        public string name { get; set; }
        public string img { get; set; }
    }
}