﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public List<Notification> TGetAllNotificationsByFalse()
		{
			return _notificationDal.GetAllNotificationsByFalse();
		}

		public void TAdd(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void TDelete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public Notification TGetByID(int id)
		{
			return _notificationDal.GetByID(id);
		}

		public List<Notification> TGetListAll()
		{
			return _notificationDal.GetListAll();
		}

		public int TNotificationCountByStatusFalse()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void TUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}

        public void TNotificationChangeToTrue(int id)
        {
            _notificationDal.NotificationChangeToTrue(id);
        }

        public void TNotificationChangeToFalse(int id)
        {
			_notificationDal.NotificationChangeToFalse(id);
        }
    }
}
