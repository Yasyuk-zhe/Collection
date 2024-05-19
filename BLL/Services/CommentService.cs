using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddComment(CommentDTO commentDto)
        {
            if (string.IsNullOrEmpty(commentDto.CommentText))
                throw new ValidationException("Текст комментария не может быть пустым", "");

            var comment = _mapper.Map<CommentDTO, Comment>(commentDto);
            await _unitOfWork.Comments.CreateAsync(comment);
            _unitOfWork.Save();
        }

        public async Task UpdateComment(CommentDTO commentDto)
        {
            Comment updatedComment = _mapper.Map<CommentDTO, Comment>(commentDto);
            await _unitOfWork.Comments.UpdateAsync(updatedComment);
            _unitOfWork.Save();
        }

        public async Task RemoveComment(int commentId)
        {
            Comment comment = await _unitOfWork.Comments.GetAsync(commentId);
            if (comment == null)
                throw new ValidationException("Комментарий не найден", "");

            await _unitOfWork.Comments.DeleteAsync(commentId);
            _unitOfWork.Save();
        }

        public async Task<CommentDTO> GetCommentById(int commentId)
        {
            Comment comment = await _unitOfWork.Comments.GetAsync(commentId);
            if (comment == null)
                throw new ValidationException("Комментарий не найден", "");

            CommentDTO commentDto = _mapper.Map<Comment, CommentDTO>(comment);
            return commentDto;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllCommentsAsync()
        {
            IEnumerable<Comment> comments = await _unitOfWork.Comments.GetAllAsync();
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
