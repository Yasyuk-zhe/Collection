using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddMessage(MessageDTO messageDto)
        {

            var message = _mapper.Map<MessageDTO, Message>(messageDto);
            await _unitOfWork.Messages.CreateAsync(message);
            _unitOfWork.Save();
        }

        public async Task UpdateMessage(MessageDTO messageDto)
        {
            Message updatedMessage = _mapper.Map<MessageDTO, Message>(messageDto);
            await _unitOfWork.Messages.UpdateAsync(updatedMessage);
            _unitOfWork.Save();
        }

        public async Task RemoveMessage(int messageId)
        {
            Message message = await _unitOfWork.Messages.GetAsync(messageId);
            if (message == null)
                throw new ValidationException("Сообщение не найдено", "");

            await _unitOfWork.Messages.DeleteAsync(messageId);
            _unitOfWork.Save();
        }

        public async Task<MessageDTO> GetMessageById(int messageId)
        {
            Message message = await _unitOfWork.Messages.GetAsync(messageId);
            if (message == null)
                throw new ValidationException("Сообщение не найдено", "");

            MessageDTO messageDto = _mapper.Map<Message, MessageDTO>(message);
            return messageDto;
        }

        public async Task<IEnumerable<MessageDTO>> GetAllMessagesAsync()
        {
            IEnumerable<Message> messages = await _unitOfWork.Messages.GetAllAsync();
            return _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(messages);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
