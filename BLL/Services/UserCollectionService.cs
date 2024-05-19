using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class UserCollectionService : IUserCollectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserCollectionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUserCollection(UserCollectionDTO userCollectionDto)
        {
            if (string.IsNullOrEmpty(userCollectionDto.CollectionName))
                throw new ValidationException("Название коллекции не может быть пустым", "");

            var userCollection = _mapper.Map<UserCollectionDTO, UserCollection>(userCollectionDto);
            await _unitOfWork.UserCollections.CreateAsync(userCollection);
            _unitOfWork.Save();
        }

        public async Task UpdateUserCollection(UserCollectionDTO userCollectionDto)
        {
            UserCollection updatedUserCollection = _mapper.Map<UserCollectionDTO, UserCollection>(userCollectionDto);
            await _unitOfWork.UserCollections.UpdateAsync(updatedUserCollection);
            _unitOfWork.Save();
        }

        public async Task RemoveUserCollection(int collectionId)
        {
            UserCollection userCollection = await _unitOfWork.UserCollections.GetAsync(collectionId);
            if (userCollection == null)
                throw new ValidationException("Коллекция не найдена", "");

            await _unitOfWork.UserCollections.DeleteAsync(collectionId);
            _unitOfWork.Save();
        }

        public async Task<UserCollectionDTO> GetUserCollectionById(int collectionId)
        {
            UserCollection userCollection = await _unitOfWork.UserCollections.GetAsync(collectionId);
            if (userCollection == null)
                throw new ValidationException("Коллекция не найдена", "");

            UserCollectionDTO userCollectionDto = _mapper.Map<UserCollection, UserCollectionDTO>(userCollection);
            return userCollectionDto;
        }

        public async Task<IEnumerable<UserCollectionDTO>> GetAllUserCollectionsAsync()
        {
            IEnumerable<UserCollection> userCollections = await _unitOfWork.UserCollections.GetAllAsync();
            return _mapper.Map<IEnumerable<UserCollection>, IEnumerable<UserCollectionDTO>>(userCollections);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
