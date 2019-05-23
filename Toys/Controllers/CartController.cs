using Models.DAO;
using Models.Framework;
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

        ToysDBContext db;
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            

            return View();
        }
        public ActionResult Add(int id,int amount = 1)
        {
            ProductDAO pro = new ProductDAO();
            product product = pro.ViewDetail(id);
            cart Cart = (cart)Session["Cart"];
            if (Cart == null)
            {
                Cart = new cart();  
            }
            if (product.price == 0)
                Cart.AddItem(product.id, product.name, product.big_photo, product.price_old,amount);
            else Cart.AddItem(product.id, product.name, product.big_photo, product.price,amount);

            Session["Cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult AddMany(int id, int amount )
        {
            amount = Convert.ToInt16(Request.Form["amount"]);
            id = Convert.ToInt16( Request.Form["id"]);
            ProductDAO pro = new ProductDAO();
            product product = pro.ViewDetail(id);
            cart Cart = (cart)Session["Cart"];
            if (Cart == null)
            {
                Cart = new cart();
            }
            if (product.price == 0)
                Cart.AddItem(product.id, product.name, product.big_photo, product.price_old, amount);
            else Cart.AddItem(product.id, product.name, product.big_photo, product.price, amount);

            Session["Cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult delete(int id)
        {
            ProductDAO pro = new ProductDAO();
            product product = pro.ViewDetail(id);
            cart Cart = (cart)Session["Cart"];
            if (Cart == null)
            {
                Cart = new cart();
            }
            Cart.delete(id);
            Session["Cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult update()
        {
                String temp;
                cart cart = (cart)Session["cart"];
                for (int i = 0; i < cart.lstcart.Count(); i++)
                {
                    temp = Request.Form[cart.lstcart[i].Id_Product.ToString()];
                    if (temp == null && cart.lstcart[i].Amount != null)
                    {
                      continue;
                    }
                    else if (temp == null || Int32.Parse(temp) == 0)
                    {
                        cart.lstcart.RemoveAt(i);
                    }
                    else
                    {
                        cart.lstcart[i].Amount = Int32.Parse(temp);
                        //cart.lstcart[i].Total = (Double)cart.lst[i].amount * cart.lst[i].price;
                    }
                }
            Session["Cart"] = cart;
            return View();
        }


        [HttpPost]
        public ActionResult pay( bill ttKhachHang )
        {
            ttKhachHang.create_date = DateTime.Now.Date;
            db = new ToysDBContext();
            db.bills.Add(ttKhachHang);


            cart cart = (cart)Session["cart"];
            foreach(CartItem item in cart.lstcart)
            {
                bill_detail detail = new bill_detail();
                detail.bill_id = ttKhachHang.id;
                detail.product_id = item.Id_Product;
                detail.amount = item.Amount;
                detail.price = item.Amount * item.price;
                db.bill_detail.Add(detail);
            }

            int stt = db.SaveChanges();
            string message = "Luư dữ liệu lỗi";
            if (stt > 0)
            {
                 message = "Lưu dữ liệu thành công";
            }
            Session["message"] = message;
            Session["Cart"] = null;

            return RedirectToAction("Index","Home");

        }
    }
}