﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Abstract
{
	public interface IOrderDal : IGenericDal<Order>
	{
		int TotalOrderCount();
		int ActiveOrderCount();
		int ActiveOrderCountByStatus();
		decimal LastOrderPrice();
		decimal TodayTotalPrice();
	}
}
