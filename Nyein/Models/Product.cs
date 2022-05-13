using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nyein.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Consumable { get; set; }
        public string ConsumerGoods { get; set; }
        public string IndianPerfume { get; set; }
        public string MyanmatPerfume { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int ItemFlag { get; set; }
        public DateTime UploadDate { get; set; }
        public List<Product> lstproducts { get; set; } = new List<Product>();
        public List<AllItem> lstImage { get; set; } = new List<AllItem>();
    }
    public class AllItem
    {
        public string Image { get; set; }
    }
    public class AddtoCart
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public List<AddtoCart> lstAddToCartItems { get; set; } = new List<AddtoCart>();
        //for saving with customer info
        public string Name { get; set; }
        public string Phone { get; set; }
        public string city { get; set; }
        public string ward { get; set; }
        public string busstop { get; set; }
        public string street { get; set; }
        public string Item { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Qty { get; set; }
    }
    public class getQty
    {
        public string Qty { get; set; }
    }
    public class SaveOrderModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public List<AddtoCart> lstAddToCartItems { get; set; } = new List<AddtoCart>();
        //for saving with customer info
        public string Name { get; set; }
        public string Phone { get; set; }
        public string city { get; set; }
        public string ward { get; set; }
        public string busstop { get; set; }
        public string street { get; set; }
        public string Item { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Qty { get; set; }
    }
}
    