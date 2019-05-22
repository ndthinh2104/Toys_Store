using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
namespace Toys.Models
{
    public class cart
    {
        public List<CartItem> lstcart = new List<CartItem>();
        public int getSoLuong()
        {
            int count = 0;

            foreach (CartItem item in lstcart)
            {
                count = count + item.Amount;
            }
            return count;
        }

        public decimal? getTongTien()
        {
            decimal? price = 0;
            foreach (CartItem item in lstcart)
            {
                price = price + item.price;
            }
            return price;
        }

        public void AddItem(int id, string name,string img, decimal? price)
        {

            bool exist = false;
            foreach(CartItem i in lstcart)
            {
                if(i.Id_Product == id)
                {
                    exist = true;
                    i.Amount++;
                    break;
                }
            }
            
            if (!exist)
            {
                CartItem cart = new CartItem();
                cart.Id_Product = id;
                cart.price = price;
                cart.img = img;
                cart.name = name;
                cart.Amount = 1;
                lstcart.Add(cart);
            }
          
        }
        public void delete(int id)
        {
            for(int i=0; i <lstcart.Count() ;i ++)
            {
                if (lstcart.ElementAt(i).Id_Product == id)
                {
                    lstcart.RemoveAt(i);
                    break;
                }
            }
        }

        public void update(int id, int amount)
        {
            for (int i = 0; i < lstcart.Count(); i++)
            {
                if (lstcart.ElementAt(i).Id_Product == id)
                {
                    lstcart.ElementAt(i).Amount = amount;
                    break;
                }
            }
        }
    }
}