﻿using SignalR.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Abstract
{
    public interface ICategorySErvice : IGenericDal<Category>
    {
        int CategoryCount();
        int ActiveCategoryCount();
		int PassiveCategoryCount();

	}
}
