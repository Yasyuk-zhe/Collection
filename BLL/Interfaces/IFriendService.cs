using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFriendService : IDisposable
    {
        Task AddFriend(FriendDTO friendDto);
        Task UpdateFriend(FriendDTO friendDto);
        Task RemoveFriend(int friendshipId);
        Task<FriendDTO> GetFriendById(int friendshipId);
        Task<IEnumerable<FriendDTO>> GetAllFriendsAsync();
    }
}
