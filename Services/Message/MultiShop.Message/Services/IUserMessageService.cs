using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services;

public interface IUserMessageService
{
    Task<ICollection<ResultMessageDto>> GetAllMessageAsync();
    Task<ICollection<ResultSendBoxMessageDto>> GetAllSendBoxMessageAsync(string? id);
    Task<ICollection<ResultInBoxMessageDto>> GetAllInBoxMessageAsync(string? id);
    Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
    Task DeleteMessageAsync(int id);
    Task CreateMessageAsync(CreateMessageDto createMessageDto);
    Task <int> GetCount();
    Task <int> GetCountByReceiverId(string id);
}