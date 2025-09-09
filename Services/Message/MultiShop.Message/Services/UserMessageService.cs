using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services;

public class UserMessageService(MessageContext context, IMapper mapper) : IUserMessageService
{
    public async Task<ICollection<ResultMessageDto>> GetAllMessageAsync()
    {
        return mapper.Map<ICollection<ResultMessageDto>>(await context.Set<UserMessage>().AsNoTracking().ToListAsync());
    }

    public async Task<ICollection<ResultSendBoxMessageDto>> GetAllSendBoxMessageAsync(string? id)
    {
        return mapper.Map<ICollection<ResultSendBoxMessageDto>>(await context.Set<UserMessage>().AsNoTracking()
            .Where(x => x.SenderId == id).ToListAsync());
    }

    public async Task<ICollection<ResultInBoxMessageDto>> GetAllInBoxMessageAsync(string? id)
    {
        return mapper.Map<ICollection<ResultInBoxMessageDto>>(await context.Set<UserMessage>().AsNoTracking()
            .Where(x => x.ReceiverId == id).ToListAsync());
    }

    public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
    {
        return mapper.Map<GetByIdMessageDto>(
            await context.Set<UserMessage>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) ??
            throw new InvalidOperationException("UserMessage not found!"));
    }

    public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
    {
        mapper.Map(updateMessageDto,
            await context.Set<UserMessage>().FindAsync(updateMessageDto.Id) ??
            throw new InvalidOperationException("UserMessage not found!"));
        await context.SaveChangesAsync();
    }

    public async Task DeleteMessageAsync(int id)
    {
        context.Set<UserMessage>().Remove(await context.Set<UserMessage>().FindAsync(id) ??
                                          throw new InvalidOperationException("UserMessage not found!"));
        await context.SaveChangesAsync();
    }

    public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
    {
        await context.Set<UserMessage>().AddAsync(mapper.Map<UserMessage>(createMessageDto));
        await context.SaveChangesAsync();
    }

    public async Task<int> GetCount()
    {
        return await context.Set<UserMessage>().CountAsync();
    }
}