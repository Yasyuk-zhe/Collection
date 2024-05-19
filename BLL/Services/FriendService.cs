using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FriendService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddFriend(FriendDTO friendDto)
        {
            var friend = _mapper.Map<FriendDTO, Friend>(friendDto);
            await _unitOfWork.Friends.CreateAsync(friend);
            _unitOfWork.Save();
        }

        public async Task UpdateFriend(FriendDTO friendDto)
        {
            Friend updatedFriend = _mapper.Map<FriendDTO, Friend>(friendDto);
            await _unitOfWork.Friends.UpdateAsync(updatedFriend);
            _unitOfWork.Save();
        }

        public async Task RemoveFriend(int friendshipId)
        {
            Friend friend = await _unitOfWork.Friends.GetAsync(friendshipId);
            if (friend == null)
                throw new ValidationException("Друг не найден", "");

            await _unitOfWork.Friends.DeleteAsync(friendshipId);
            _unitOfWork.Save();
        }

        public async Task<FriendDTO> GetFriendById(int friendshipId)
        {
            Friend friend = await _unitOfWork.Friends.GetAsync(friendshipId);
            if (friend == null)
                throw new ValidationException("Друг не найден", "");

            FriendDTO friendDto = _mapper.Map<Friend, FriendDTO>(friend);
            return friendDto;
        }

        public async Task<IEnumerable<FriendDTO>> GetAllFriendsAsync()
        {
            IEnumerable<Friend> friends = await _unitOfWork.Friends.GetAllAsync();
            return _mapper.Map<IEnumerable<Friend>, IEnumerable<FriendDTO>>(friends);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
