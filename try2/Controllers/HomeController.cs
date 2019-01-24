using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try2.Models;
using Microsoft.AspNetCore.Mvc;
using try2.ViewModel;
using Npgsql;
using System.Data;
using try2.Services;

namespace try2.Controllers
{
    public class HomeController : Controller
    {

        private int num = 45;

        public IActionResult Insert()
        {
            try
            {
                using (var conn = new Connection().getDb())
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO zharbor.buyer VALUES (@i, 'diego')";
                        cmd.Parameters.AddWithValue("i", num++);
                        cmd.ExecuteNonQuery();
                    }
                    

                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return Index();
        }

        //next thing in urll
        public IActionResult Index()
        {
            var todoItems = new DataSet();
            try
            {
                using (var conn = new Connection().getDb())
                {
                    conn.Open();
                    

                    // Retrieve all rows
                    using (var cmd = new NpgsqlCommand("SELECT * FROM zharbor.buyer", conn))
                    {
                        var adapter = new NpgsqlDataAdapter(cmd);
                        adapter.Fill(todoItems);
                        foreach (DataRow row in todoItems.Tables[0].Rows)
                            ViewData["Message"] += $"id= {row["id"]}<br/>";
                        
                    }

                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }
            return View();
        }

        
    }
}