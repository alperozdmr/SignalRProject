using AutoMapper;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Mapping
{
	public class MessageMapping : Profile
	{
		public MessageMapping() {
			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
			CreateMap<Message, GetByIdMessageDto>().ReverseMap();
		}
	}
}
