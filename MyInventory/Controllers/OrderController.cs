using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyInventory.Data;
using MyInventory.Models;

namespace MyInventory.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var order = await context.Orders.ToListAsync();
            return View(order);
        }

        //public async Task<IActionResult> Create(int id, Order order, Product product)
        //{
        //    var findfromDb = await context.Orders.Where(m => order.ProductId == product.Id).FirstOrDefaultAsync();
        //    return View(findfromDb);
        //}

        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Create(ShoppingCart shoppingCart, Order order)
        //{
        //    //string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        //    ////string query = $"select * into Orders from ShoppingCart ";            
        //    //string query = $"insert into Orders(Count,ProductId, UserInfoId, Price) Values(1,1,1,1.0)";
        //    ////string query = $"Insert into Orders(UserInfoId, ProductId, Count, TotalPrice) Values((Select UserInfoId from ShoppingCart where ShoppingCart.UserInfoId = '" + findIdFromDb + "'), (Select ProductId from ShoppingCart where ShoppingCart.UserInfoId = '" + findIdFromDb + "'), (Select Count from ShoppingCart where ShoppingCart.UserInfoId = '" + findIdFromDb + "'), (Select sum(Price) from ShoppingCart where ShoppingCart.UserInfoId = '" + findIdFromDb + "'))";
        //    ////context.ShoppingCart.FromSqlRaw("Insert into dbo.ShoppingCart(Name, ProductId) Values ('Select Name, Id from dbo.Products')");
        //    ////context.ShoppingCart.FromSqlRaw("Insert into ShoppingCart(Name, ProductId)Values(Select Name from Products,Select Id from Products)");
        //    ////await context.SaveChangesAsync();
        //    ////var findIdFromDb = context.ShoppingCart.Find(id);
        //    ////SqlDataAdapter sda = new SqlDataAdapter("Insert into Orders(UserInfoId, ProductId, Count, TotalPrice) Values((Select UserInfoId from ShoppingCart where Id = '" + findIdFromDb + "'), (Select ProductId from ShoppingCart where Id = '" + findIdFromDb + "'), (Select Count from ShoppingCart where Id = '" + findIdFromDb + "'), (Select TotalPrice from ShoppingCart where Id = '" + findIdFromDb + "'))", sqlConnection);

        //    //using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //    //{


        //    //    //SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
        //    //    //DataTable dt = new DataTable();
        //    //    //sda.Fill(dt);
        //    //    using (SqlCommand command = new SqlCommand(query, sqlConnection))
        //    //    {
        //    //        command.CommandType = CommandType.Text;
        //    //        sqlConnection.Open();
        //    //        command.ExecuteNonQuery();
        //    //        sqlConnection.Close();
        //    //    }
        //    //}

        //    //context.ShoppingCart.First().Count = order.Count;
        //    //context.ShoppingCart.First().ProductId = order.ProductId;
        //    //context.ShoppingCart.First().UserInfoId = order.UserInfoId;
        //    //context.ShoppingCart.First().Price = order.Price;
        //    context.Orders.Add(order);
        //    context.SaveChanges();

        //    return View();
        //}

    }
}
