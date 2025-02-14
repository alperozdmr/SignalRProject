using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping() {
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            //CreateMap<Notification, GetNotificationDto>().ReverseMap();
        }
    }
}
