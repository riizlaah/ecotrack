using EcoTrackAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly EcoTrackContext dbc;
        public TransactionsController(EcoTrackContext ctx)
        {
            dbc = ctx;
        }

        [Authorize]
        [HttpGet]
        public IResult GetAll()
        {
            if(!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Helper.errResponse("User id not valid!", 400);
            }
            return Helper.Success(dbc.Transactions.Include(t => t.Category).Where(t => t.UserId == userId).ToList());
        }
        [Authorize]
        [HttpPost]
        public IResult Create(TransactionCustomerDTO input)
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Helper.errResponse("User id not valid!", 400);
            }
            if (input.weight < 0.000001m) return Helper.errResponse("Weight must be greater than zero.");
            var category = dbc.Categories.Find(input.categoryId);
            if (category is null) return Helper.errResponse("Category not found.");
            var totalPrice = category.PricePerKg * input.weight ?? 0m;
            var transac = input.toTransaction(userId, totalPrice);
            dbc.Transactions.Add(transac);
            return Helper.Success(new
            {
                transactionId = transac.Id,
                userId = userId,
                categoryName = category.Name,
                weight = input.weight,
                totalPrice = transac.TotalPrice,
            }, "Transaction success.");
        }
    }
}
