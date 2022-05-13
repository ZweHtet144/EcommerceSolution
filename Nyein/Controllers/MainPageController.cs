using Nyein.Common;
using Nyein.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nyein.Controllers
{
    public class MainPageController : Controller
    {
        SqlDataAccess _conn = new SqlDataAccess();

        #region ConsumableProduct
        // GET: MainPage for ConsumableProduct
        [Route("Consumable")]
        public ActionResult Consumable()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ItemFlag='1' ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<Product> lstProduct = ds.Tables[0].AsEnumerable().Select(row => new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = row["Image"].ToString(),
                    ItemFlag = Convert.ToInt32(row["ItemFlag"])
                }).ToList();
                //Product product = new Product();
                //product.lstproducts = lstProduct;
                //return View(product);
                var lstImg = SelectForAllItem();
                Product model = new Product()
                {
                    lstproducts = lstProduct,
                    lstImage = lstImg
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AllItem> SelectForAllItem()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<AllItem> lstAllItem = ds.Tables[0].AsEnumerable().Select(row => new AllItem
                {
                    Image = row["Image"].ToString(),
                }).ToList();
                return lstAllItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsumerGood
        //For Consumergoods product
        [Route("ConsumerGood")]
        public ActionResult ConsumerGood()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ItemFlag='2' ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<Product> lstProduct = ds.Tables[0].AsEnumerable().Select(row => new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = row["Image"].ToString(),
                    ItemFlag = Convert.ToInt32(row["ItemFlag"])
                }).ToList();
                //Product product = new Product();
                //product.lstproducts = lstProduct;
                //return View(product);
                Product model = new Product()
                {
                    lstproducts = lstProduct,
                    //popularProducts = lstpopularItem
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PopularProduct
        //Popular product
        public ActionResult Popular()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ItemFlag='0' ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<Product> lstProduct = ds.Tables[0].AsEnumerable().Select(row => new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = row["Image"].ToString(),
                    ItemFlag = Convert.ToInt32(row["ItemFlag"])
                }).ToList();
                var lstImg = SelectForAllItem();
                Product model = new Product()
                {
                    lstproducts = lstProduct,
                    lstImage = lstImg
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region IndiaProduct
        //For Indian Perfume
        [Route("IndiaProduct")]
        public ActionResult IndiaProduct()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ItemFlag='3' ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<Product> lstProduct = ds.Tables[0].AsEnumerable().Select(row => new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = row["Image"].ToString(),
                    ItemFlag = Convert.ToInt32(row["ItemFlag"])
                }).ToList();
                //Product product = new Product();
                //product.lstproducts = lstProduct;
                //return View(product);
                Product model = new Product()
                {
                    lstproducts = lstProduct,
                    //popularProducts = lstpopularItem
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MyanmarProduct
        //For MyanmarPerfume
        [Route("MyanmarProduct")]
        public ActionResult MyanmarProduct()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ItemFlag='4' ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<Product> lstProduct = ds.Tables[0].AsEnumerable().Select(row => new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Description = row["Description"].ToString(),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = row["Image"].ToString(),
                    ItemFlag = Convert.ToInt32(row["ItemFlag"])
                }).ToList();
                //Product product = new Product();
                //product.lstproducts = lstProduct;
                //return View(product);
                Product model = new Product()
                {
                    lstproducts = lstProduct,
                    //popularProducts = lstpopularItem
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region AddToCartList
        //get addtoCart Items and show as List
        public ActionResult AddtoCartItem(AddtoCart model)
        {
            if (Session["Cart"] == null)
            {
                List<AddtoCart> lstAddCartItem = new List<AddtoCart>();
                lstAddCartItem.Add(model);
                Session["Cart"] = lstAddCartItem;
                Session["Count"] = 0;
            }
            else
            {
                List<AddtoCart> lstAddCartItem = (List<AddtoCart>)Session["Cart"];
                lstAddCartItem.Add(model);
                Session["Cart"] = lstAddCartItem;
                Session["Count"] = Convert.ToInt32(lstAddCartItem.Count);
            }
            return Json(JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region RemoveAddToCart Item
        //Remove from AddtoCart
        public ActionResult RemoveAddtocartItem(AddtoCart model)
        {
            List<AddtoCart> lstItem = (List<AddtoCart>)Session["Cart"];
            lstItem.RemoveAll(i => i.Id == model.Id);
            Session["Cart"] = lstItem;
            Session["Count"] = Convert.ToInt32(lstItem.Count);
            return RedirectToAction("MainPage", "OrderPage");
        }
        #endregion

        #region remove with trashbox 
        //remove trashbox inside addtocartpage
        public ActionResult RemoveCardInternal(AddtoCart model)
        {
            List<AddtoCart> lstItem = (List<AddtoCart>)Session["Cart"];
            lstItem.RemoveAll(i => i.Id == model.Id);
            Session["Cart"] = lstItem;
            Session["Count"] = Convert.ToInt32(lstItem.Count);
            if (lstItem.Count < 1)
            {
                Session.Clear();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Cart_List
        [Route("Cart_List")]
        public ActionResult Cart_List()
        {
            return View((List<AddtoCart>)Session["Cart"]);
        }
        #endregion

        #region Order
        //get method for checkoutpage
        public ActionResult Order()
        {
            return View((List<AddtoCart>)Session["Cart"]);
        }
        
        //Post method for checkoutpage
        [HttpPost]
        public ActionResult CheckOut(AddtoCart model)
        {
            try
            {
                //foreach (var item in (List<AddtoCart>)Session["Cart"])
                //{
                //    model.Title += item.Title + ","+item.Price;
                //}
                string query = "INSERT INTO SaveOrder(Name,Phone,City,Ward,Street,BusStop,Item,TotalPrice,OrderDate) VALUES(@Name,@Phone,@City,@Ward,@Street,@BusStop,@Item,@TotalPrice,@OrderDate)";
                SqlCommand cmd = new SqlCommand(query, _conn.Connect());
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@City", model.city);
                cmd.Parameters.AddWithValue("@Ward", model.ward);
                cmd.Parameters.AddWithValue("@Street", model.street);
                cmd.Parameters.AddWithValue("@BusStop", model.busstop);
                cmd.Parameters.AddWithValue("@Item", model.Title.TrimEnd(','));
                cmd.Parameters.AddWithValue("@TotalPrice", model.TotalPrice);
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                _conn.Connect().Close();
                Session.Clear();
                return Json(JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region OrderedCustomerList
        //Get OrderedCustomerList
        [Authorize]
        [Route("CustomerOrderList")]
        public ActionResult OrderedCustomerList()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SaveOrder ORDER BY Id DESC", _conn.Connect());
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.CommandTimeout = 18000;
                _conn.Connect().Close();
                List<AddtoCart> lstSaveInfo = ds.Tables[0].AsEnumerable().Select(row => new AddtoCart
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Phone = row["Phone"].ToString(),
                    city = row["City"].ToString(),
                    ward = row["Ward"].ToString(),
                    busstop = row["busstop"].ToString(),
                    street = row["street"].ToString(),
                    Item = row["Item"].ToString(),
                    TotalPrice = Convert.ToInt32(row["TotalPrice"].ToString()),
                    OrderDate = Convert.ToDateTime(row["OrderDate"].ToString()),
                }).ToList();
                return View(lstSaveInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}