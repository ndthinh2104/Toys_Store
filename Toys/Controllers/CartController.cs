using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toys.Models;

namespace Toys.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int productId, int amount)
        {
            var product = new ProductDAO().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.id == productId)
                        {
                            item.Amount += amount;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product.id = productId;
                    item.Amount = amount;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                // tao moi doi tuong cartitem
                var item = new CartItem();
                item.Product = product;
                item.Amount = amount;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}