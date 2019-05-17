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
        public product Product { get; set; }
        public int Amount { get; set; }
        
    }
}