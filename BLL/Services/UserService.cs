using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUser(UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Username))
                throw new ValidationException("Имя пользователя не может быть пустым", "");

            var user = _mapper.Map<UserDTO, User>(userDto);
            await _unitOfWork.Users.CreateAsync(user);
            _unitOfWork.Save();
        }

        public async Task UpdateUser(UserDTO userDto)
        {
            User updatedUser = _mapper.Map<UserDTO, User>(userDto);
            await _unitOfWork.Users.UpdateAsync(updatedUser);
            _unitOfWork.Save();
        }

        public async Task RemoveUser(int userId)
        {
            User user = await _unitOfWork.Users.GetAsync(userId);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            await _unitOfWork.Users.DeleteAsync(userId);
            _unitOfWork.Save();
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            User user = await _unitOfWork.Users.GetAsync(userId);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            UserDTO userDto = _mapper.Map<User, UserDTO>(user);
            return userDto;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
