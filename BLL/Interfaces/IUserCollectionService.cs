using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserCollectionService : IDisposable
    {
        Task AddUserCollection(UserCollectionDTO userCollectionDto);
        Task UpdateUserCollection(UserCollectionDTO userCollectionDto);
        Task RemoveUserCollection(int collectionId);
        Task<UserCollectionDTO> GetUserCollectionById(int collectionId);
        Task<IEnumerable<UserCollectionDTO>> GetAllUserCollectionsAsync();
    }
}
