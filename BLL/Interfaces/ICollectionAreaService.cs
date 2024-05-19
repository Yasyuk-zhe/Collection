using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICollectionAreaService : IDisposable
    {
        Task AddCollectionArea(CollectionAreaDTO collectionAreaDto);
        Task UpdateCollectionArea(CollectionAreaDTO collectionAreaDto);
        Task RemoveCollectionArea(int areaId);
        Task<CollectionAreaDTO> GetCollectionAreaById(int areaId);
        Task<IEnumerable<CollectionAreaDTO>> GetAllCollectionAreasAsync();
    }
}
