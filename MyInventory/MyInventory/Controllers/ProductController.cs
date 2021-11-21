﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyInventory.Data;
using MyInventory.Models;
using MyInventory.Models.ViewModels;
using System.Data;

namespace MyInventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        public IConfiguration Configuration { get; }

        public ProductController(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            Configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var products = await context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Product products)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"Insert into Products(Name, Description, Price) Values('{products.Name}','{products.Description}', '{products.Price}')";
                //using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                //{
                //    command.CommandType = CommandType.Text;
                //    sqlConnection.Open();
                //    command.ExecuteNonQuery();
                //    sqlConnection.Close();
                //}

                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var findById = await context.Products.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            if(findById == null)
            {
                return NotFound();
            }
            
            return View(findById);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product products, int? id)
        {
            var findById = await context.Products.FindAsync(id);

            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"Update Products Set Name='{products.Name}', Description='{products.Description}', Price='{products.Price}' where Id='{products.Id}'";
                //using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                //{
                //    command.CommandType = CommandType.Text;
                //    sqlConnection.Open();
                //    command.ExecuteNonQuery();
                //    sqlConnection.Close();
                //}

                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var findById = await context.Products.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            if (findById == null)
            {
                return NotFound();
            }

            return View(findById);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Product products)
        {
        
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"Delete from Products where Id='{products.Id}'";
                //using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                //{
                //    command.CommandType = CommandType.Text;
                //    sqlConnection.Open();
                //    command.ExecuteNonQuery();
                //    sqlConnection.Close();
                //}

                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            var findById = await context.Products.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }

            if (findById == null)
            {
                return NotFound();
            }

            OrderProductViewModel orderProductViewModel = new OrderProductViewModel()
            {
                Order = new Order(),
                Product = findById
            };

            return View(orderProductViewModel);
        }


        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    menuItemViewModel.MenuItem = await db.MenuItems.Include(m => m.Category).Include(m => m.Subcategory).SingleOrDefaultAsync(m => m.Id == id);

        //    if (menuItemViewModel.MenuItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(menuItemViewModel);
        //}
    }
}
