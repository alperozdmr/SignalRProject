﻿using SignalR.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        public int ProductCount();
		int ProductCountByCategoryNameHambuger();
		int ProductCountByCategoryNameDrink();
        decimal ProductPriceAVG();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductPriceByHamburger();
	}
}
