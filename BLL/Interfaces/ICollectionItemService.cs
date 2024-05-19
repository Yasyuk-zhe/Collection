using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICollectionItemService : IDisposable
    {
        Task AddCollectionItem(CollectionItemDTO collectionItemDto);
        Task UpdateCollectionItem(CollectionItemDTO collectionItemDto);
        Task RemoveCollectionItem(int itemId);
        Task<CollectionItemDTO> GetCollectionItemById(int itemId);
        Task<IEnumerable<CollectionItemDTO>> GetAllCollectionItemsAsync();
    }
}