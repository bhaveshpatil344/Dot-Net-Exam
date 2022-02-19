using DotNetExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JkJan22; Integrated Security = True";
            sq.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sq;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products";
            List<Product> prod = new List<Product>();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    prod.Add(new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) });

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sq.Close();
            }
            return View(prod);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id = 0)
        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JkJan22; Integrated Security = True";
            sq.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sq;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Products where ProductId = @ProductId";
            cmd.Parameters.AddWithValue("ProductId", id);
            SqlDataReader dr = cmd.ExecuteReader();
            Product p = null;
            if (dr.Read())
            {
                p = new Product { ProductId = dr.GetInt32(0), ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName = dr.GetString(4) };

            }
            else
            {
                ViewBag.ErrorMessage = "Not Found";
            }
            sq.Close();
            return View(p);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product obj)

        {
            SqlConnection sq = new SqlConnection();
            sq.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JkJan22; Integrated Security = True";
            sq.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sq;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateData";
            cmd.Parameters.AddWithValue("ProductId", obj.ProductId);
            cmd.Parameters.AddWithValue("ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("Rate", obj.Rate);
            cmd.Parameters.AddWithValue("Description", obj.Description);
            cmd.Parameters.AddWithValue("CategoryName", obj.CategoryName);
            try
            {
                // TODO: Add update logic here

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                sq.Close();
            }
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
