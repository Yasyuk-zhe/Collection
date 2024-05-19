using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService : IDisposable
    {
        Task AddMessage(MessageDTO messageDto);
        Task UpdateMessage(MessageDTO messageDto);
        Task RemoveMessage(int messageId);
        Task<MessageDTO> GetMessageById(int messageId);
        Task<IEnumerable<MessageDTO>> GetAllMessagesAsync();
    }
}
