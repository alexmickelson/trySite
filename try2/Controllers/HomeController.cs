using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using try2.Models;
using Microsoft.AspNetCore.Mvc;
using try2.ViewModel;
using Npgsql;
using System.Data;

namespace try2.Controllers
{
    public class HomeController : Controller
    {
        


        public IActionResult About()
        {
            try
            {
                using (var conn = new NpgsqlConnection("Server=144.17.24.208;Port=5432;Database=postgres;User Id=postgres;"))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO todo (id, title, iscomplete) VALUES (@id, @title, @iscomplete)";
                        cmd.Parameters.AddWithValue("id", 1);
                        cmd.Parameters.AddWithValue("title", "new item");
                        cmd.Parameters.AddWithValue("iscomplete", false);
                        cmd.ExecuteNonQuery();
                    }

                    // Retrieve all rows
                    using (var cmd = new NpgsqlCommand("SELECT * FROM todo", conn))
                    {
                        var adapter = new NpgsqlDataAdapter(cmd);
                        var todoItems = new DataSet();
                        adapter.Fill(todoItems);
                        foreach (DataRow row in todoItems.Tables[0].Rows)
                            ViewData["Message"] += $"id= {row["id"]}; title={row["title"]}; isComplete={row["iscomplete"]}<br/>";
                    }

                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message;
            }

            return View();
        }

        //next thing in urll
        public IActionResult Index()
        {
            var print = new PrintThisPlz();
            return View(print);
        }

        
    }
}