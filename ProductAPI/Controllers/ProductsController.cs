using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = ProductAPI.Models.Type;

namespace ProductAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductDbContext ProductDb;
        public ProductsController(ProductDbContext dbContext)
        {
            ProductDb = dbContext;
        }
        public IActionResult Products(int limit, int page)
        {
            IEnumerable<Product> list;
            if (limit != 0 && limit != 0) list = ProductDb.Products.Skip(limit * (page - 1)).Take(limit);
            else list = ProductDb.Products;
            return Content(JsonConvert.SerializeObject(list, Formatting.None), "application/json");
        }
        [Route("Search")]
        public IActionResult Search(string type, string color, int limit, int page)
        {
            IEnumerable<Product> list;
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(color))
                list = ProductDb.Products.Skip(limit * (page - 1)).Take(limit).ToList();
            else list = ProductDb.Products.Where(x => x.Type == Enum.Parse<Type>(type) && x.Color == Enum.Parse<Color>(color)).Skip(limit * (page - 1)).Take(limit).ToList();
            return Ok(list);
        }
    }
}
