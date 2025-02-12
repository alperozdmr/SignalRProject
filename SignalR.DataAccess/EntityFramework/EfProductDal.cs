using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

		public List<Product> GetLast9Products()
		{
			using var context = new SignalRContext();
			var values = context.Products.Take(9).ToList();
			return values;
		}

		public List<Product> GetProductsWithCategories()
        {
           SignalRContext context = new SignalRContext();
            var values = context.Products.Include(x=> x.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
            using var context = new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context  = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();

		}

		public int ProductCountByCategoryNameHambuger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();

		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAVG()
		{
			using var context = new SignalRContext();
			return context.Products.Average(x => x.Price);		
		}

		public decimal ProductPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w=>w.Price);
		}

		public decimal ProductPriceBySteakBurger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductName == "Steak Burger").Select(x => x.Price).FirstOrDefault();
		}

		public decimal TotalPriceByDrinkCategory()
		{
			using var context = new SignalRContext();
			int id = context.Categories.Where(x => x.Name == "İçecek").Select(y=>y.CategoryID).FirstOrDefault();
			return context.Products.Where(z => z.CategoryID == id).Sum(c=>c.Price);
		}

		public decimal TotalPriceBySaladCategory()
		{
			using var context = new SignalRContext();
			int id = context.Categories.Where(x => x.Name == "Salata").Select(y => y.CategoryID).FirstOrDefault();
			return context.Products.Where(z => z.CategoryID == id).Sum(c => c.Price);
		}
	}
}
