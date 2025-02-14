using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;
using SignalRApı.Models;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableId(int id)
        {
            var values = _basketService.TGetBasketByTableNumber(id);
            return Ok(values);  
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableID == id)
                .Select(z=> new ResultBasketListWithProducts {
                    BasketID = z.BasketID,
                    Count = z.Count,
                    MenuTableID = z.MenuTableID,
                    Price = z.Price,
                    ProductID = z.ProductID,
                    TotalPrice = z.TotalPrice,
                    ProductName = z.Product.ProductName
                }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto var)
        {
            using var context = new SignalRContext();
            var product = context.Baskets.FirstOrDefault(x => x.ProductID == var.ProductID);
            if (product != null)
            {
                if (product.Count >= 1)
                {
                    decimal count = product.Count++;
                    product.TotalPrice = product.Price * count;
                    _basketService.TUpdate(product);
                }
            }
            else
            {
                _basketService.TAdd(new Basket
                {
                    ProductID = var.ProductID,
                    MenuTableID = var.MenuTableID,
                    Count = 1,
                    Price = context.Products.Where(x => x.ProductID == var.ProductID).Select(y => y.Price).FirstOrDefault(),
                    TotalPrice = (context.Products.Where(x => x.ProductID == var.ProductID).Select(y => y.Price).FirstOrDefault()) * 1,
                });
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id) {
            var value = _basketService.TGetByID(id);
            if (value.Count > 1)
            {
                decimal count = value.Count--;
                value.TotalPrice = value.Price *count;
                _basketService.TUpdate(value);
            }
            else
            {
                _basketService.TDelete(value);
            }
            return Ok("sepetteki seçilen ürün silindi");
        }
    }
}
