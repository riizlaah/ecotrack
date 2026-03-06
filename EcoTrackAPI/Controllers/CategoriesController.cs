using EcoTrackAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EcoTrackContext dbc;
        public CategoriesController(EcoTrackContext ctx)
        {
            dbc = ctx;
        }
        [HttpGet]
        public IResult GetAll()
        {
            return Helper.Success(dbc.Categories.ToList(), "Categories fetched successfully.");
        }
    }
}
