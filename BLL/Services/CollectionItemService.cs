using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class CollectionItemService : ICollectionItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CollectionItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCollectionItem(CollectionItemDTO collectionItemDto)
        {
            if (string.IsNullOrEmpty(collectionItemDto.ItemName))
                throw new ValidationException("Название элемента коллекции не может быть пустым", "");

            var collectionItem = _mapper.Map<CollectionItemDTO, CollectionItem>(collectionItemDto);
            await _unitOfWork.CollectionItems.CreateAsync(collectionItem);
            _unitOfWork.Save();
        }

        public async Task UpdateCollectionItem(CollectionItemDTO collectionItemDto)
        {
            CollectionItem updatedCollectionItem = _mapper.Map<CollectionItemDTO, CollectionItem>(collectionItemDto);
            await _unitOfWork.CollectionItems.UpdateAsync(updatedCollectionItem);
            _unitOfWork.Save();
        }

        public async Task RemoveCollectionItem(int itemId)
        {
            CollectionItem collectionItem = await _unitOfWork.CollectionItems.GetAsync(itemId);
            if (collectionItem == null)
                throw new ValidationException("Элемент коллекции не найден", "");

            await _unitOfWork.CollectionItems.DeleteAsync(itemId);
            _unitOfWork.Save();
        }

        public async Task<CollectionItemDTO> GetCollectionItemById(int itemId)
        {
            CollectionItem collectionItem = await _unitOfWork.CollectionItems.GetAsync(itemId);
            if (collectionItem == null)
                throw new ValidationException("Элемент коллекции не найден", "");

            CollectionItemDTO collectionItemDto = _mapper.Map<CollectionItem, CollectionItemDTO>(collectionItem);
            return collectionItemDto;
        }

        public async Task<IEnumerable<CollectionItemDTO>> GetAllCollectionItemsAsync()
        {
            IEnumerable<CollectionItem> collectionItems = await _unitOfWork.CollectionItems.GetAllAsync();
            return _mapper.Map<IEnumerable<CollectionItem>, IEnumerable<CollectionItemDTO>>(collectionItems);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
