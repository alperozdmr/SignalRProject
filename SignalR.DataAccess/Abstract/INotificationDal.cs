﻿using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccess.Abstract
{
	public interface INotificationDal :IGenericDal<Notification>
	{
		int NotificationCountByStatusFalse();
		List<Notification> GetAllNotificationsByFalse();
		void NotificationChangeToTrue(int id);
		void NotificationChangeToFalse(int id);
	}
}
