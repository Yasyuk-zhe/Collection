using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class CollectionAreaService : ICollectionAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CollectionAreaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCollectionArea(CollectionAreaDTO collectionAreaDto)
        {
            if (string.IsNullOrEmpty(collectionAreaDto.AreaName))
                throw new ValidationException("Название области коллекции не может быть пустым", "");

            var collectionArea = _mapper.Map<CollectionAreaDTO, CollectionArea>(collectionAreaDto);
            await _unitOfWork.CollectionAreas.CreateAsync(collectionArea);
            _unitOfWork.Save();
        }

        public async Task UpdateCollectionArea(CollectionAreaDTO collectionAreaDto)
        {
            CollectionArea updatedCollectionArea = _mapper.Map<CollectionAreaDTO, CollectionArea>(collectionAreaDto);
            await _unitOfWork.CollectionAreas.UpdateAsync(updatedCollectionArea);
            _unitOfWork.Save();
        }

        public async Task RemoveCollectionArea(int areaId)
        {
            CollectionArea collectionArea = await _unitOfWork.CollectionAreas.GetAsync(areaId);
            if (collectionArea == null)
                throw new ValidationException("Область коллекции не найдена", "");

            await _unitOfWork.CollectionAreas.DeleteAsync(areaId);
            _unitOfWork.Save();
        }

        public async Task<CollectionAreaDTO> GetCollectionAreaById(int areaId)
        {
            CollectionArea collectionArea = await _unitOfWork.CollectionAreas.GetAsync(areaId);
            if (collectionArea == null)
                throw new ValidationException("Область коллекции не найдена", "");

            CollectionAreaDTO collectionAreaDto = _mapper.Map<CollectionArea, CollectionAreaDTO>(collectionArea);
            return collectionAreaDto;
        }

        public async Task<IEnumerable<CollectionAreaDTO>> GetAllCollectionAreasAsync()
        {
            IEnumerable<CollectionArea> collectionAreas = await _unitOfWork.CollectionAreas.GetAllAsync();
            return _mapper.Map<IEnumerable<CollectionArea>, IEnumerable<CollectionAreaDTO>>(collectionAreas);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
