﻿using SignalR.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        int TProductCountByCategoryNameHambuger();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAVG();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
        decimal TProductPriceByHamburger();
        decimal TProductPriceBySteakBurger();
        decimal TTotalPriceByDrinkCategory();
        decimal TTotalPriceBySaladCategory();
        List<Product> TGetLast9Products();
	}
}
