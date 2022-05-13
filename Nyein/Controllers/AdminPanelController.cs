using Nyein.Common;
using Nyein.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nyein.Controllers
{
    public class AdminPanelController : Controller
    {
        SqlDataAccess _conn = new SqlDataAccess();

        #region AdminPanel
        // GET: AdminPanel
        [Authorize]
        public ActionResult AdminPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminPage(Product model, HttpPostedFileBase[] files)
        {
            try
            {
                foreach (HttpPostedFileBase file in files)
                {
                    Random generator = new Random(); //get random number
                    string str = generator.Next(0, 10000).ToString("D5");//get 5 digit of random number
                    string FileName_ = Path.GetFileNameWithoutExtension(file.FileName);
                    string FileName = str + FileName_;
                    string FileExtension = Path.GetExtension(file.FileName);//file name casting to prevent duplicate name
                    var supportedExtension = new[] { ".jpg", ".jpeg", ".png" };//extension checking
                    if (!supportedExtension.Contains(FileExtension))
                    {
                        ViewBag.ErrorMessage = "File Extension Is InValid - Only Upload image format";
                        return ViewBag.ErrorMessage;
                    }
                    else
                    {
                        if (FileName != null)
                        {
                            string imageName = FileName.Trim() + FileExtension;
                            string imagePath = Path.Combine(Server.MapPath("~/Content/image"), imageName);
                            file.SaveAs(imagePath);
                            model.Image += imageName + " ";
                        }
                    }

                }
                string qurey = "INSERT INTO Product(Title,Description,Price,Image,Category,ItemFlag,UploadDate) VALUES(@Title,@Description,@Price,@Image,@Category,@ItemFlag,@UploadDate)";
                SqlCommand cmd = new SqlCommand(qurey, _conn.Connect());
                cmd.Parameters.AddWithValue("@Title", model.Title);
                cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                cmd.Parameters.AddWithValue("@Price", model.Price);
                cmd.Parameters.AddWithValue("@Image", model.Image.TrimEnd(' '));
                cmd.Parameters.AddWithValue("@Category", model.Category);
                if (model.Category == "Consumable")
                {
                    cmd.Parameters.AddWithValue("@ItemFlag", 1);
                }
                if (model.Category == "ConsumerGoods")
                {
                    cmd.Parameters.AddWithValue("@ItemFlag", 2);
                }
                if (model.Category == "IndianPerfume")
                {
                    cmd.Parameters.AddWithValue("@ItemFlag", 3);
                }
                if (model.Category == "MyanmatPerfume")
                {
                    cmd.Parameters.AddWithValue("@ItemFlag", 4);
                }
                if (model.Category == "Popular")
                {
                    cmd.Parameters.AddWithValue("@ItemFlag", 0);
                }
                cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                cmd.ExecuteNonQuery();
                
                _conn.Connect().Close();
                TempData["Message"] = "True";
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        #endregion

        #region uploadedProductList
        //Get and display list for uploaded product by admin
        [Authorize]
        [Route("UploadedHistory")]
        public ActionResult UploadedProduct()
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
                List<Product> lstProduct = ds.Tables[0].AsEnumerable().Select(row => new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = row["Image"].ToString(),
                    UploadDate = Convert.ToDateTime(row["UploadDate"])
                }).ToList();
                Product model = new Product()
                {
                    lstproducts = lstProduct
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DeleteItem
        //Delete Item
        public ActionResult Delete(int id)
        {
            string sql = "DELETE FROM Product WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(sql, _conn.Connect());
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            _conn.Connect().Close();
            TempData["DeletMessage"] = true;
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ChooseService
        [Authorize]
        [Route("ChooseService")]
        public ActionResult ChooseService()
        {
            return View();
        }
        #endregion

        #region PopularProductHistory
        //Popular history
        public ActionResult PopularHistory()
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
                Product model = new Product()
                {
                    lstproducts=lstProduct
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsumableProductHistory
        //Consumable
        [Authorize]
        public ActionResult ConsumableHistory()
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
                Product model = new Product()
                {
                    lstproducts = lstProduct
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ConsumerGoodProductHistory
        //Consumergood
        [Authorize]
        public ActionResult ConsumerGoodHistory()
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
                Product model = new Product()
                {
                    lstproducts = lstProduct
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region IndiaProductHistory
        [Authorize]
        public ActionResult IHistory()
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
                Product model = new Product()
                {
                    lstproducts = lstProduct
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MyanmarProductHistory
        [Authorize]
        public ActionResult MyanmarProductHistory()
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
                Product model = new Product()
                {
                    lstproducts = lstProduct
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}