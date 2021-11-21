using Microsoft.AspNetCore.Mvc;
using MyInventory.Data;
using System.Security.Claims;

namespace MyInventory.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;

        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var claimsIdentity = (ClaimsIdentity)this.User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    var returnClaimValue = await context.UserInfo.Where(m => m.Id != claim.Value).ToListAsync();
        //    return View(returnClaimValue);
        //}
    }
}
