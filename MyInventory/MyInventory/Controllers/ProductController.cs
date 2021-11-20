using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyInventory.Data;
using MyInventory.Models;
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

        [HttpPost]
        public IActionResult Create(Product products)
        {
            string connectionString = Configuration["ConnectionStrings:Default"];

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"Insert into Products(Name, Description, Price, Image) Values('{products.Name}','{products.Description}', '{products.Price}', '{products.Image}')";
                //using (SqlCommand command = new SqlCommand(sql, con))
                //{
                //    command.CommandType = CommandType.Text;
                //    con.Open();
                //    command.ExecuteNonQuery();
                //    con.Close();
                //}
                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }

            return View();
        }
    }
}
