using AutoMapper;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Profiles;

public class UserMessageMapper:Profile
{
    public UserMessageMapper()
    {
        CreateMap<CreateMessageDto, UserMessage>();
        CreateMap<UpdateMessageDto, UserMessage>();
        CreateMap<UserMessage, ResultInBoxMessageDto>();
        CreateMap<UserMessage, ResultSendBoxMessageDto>();
        CreateMap<UserMessage, ResultMessageDto>();
        CreateMap<UserMessage, GetByIdMessageDto>();
        
    }
}