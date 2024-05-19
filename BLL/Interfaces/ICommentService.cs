using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService : IDisposable
    {
        Task AddComment(CommentDTO commentDto);
        Task UpdateComment(CommentDTO commentDto);
        Task RemoveComment(int commentId);
        Task<CommentDTO> GetCommentById(int commentId);
        Task<IEnumerable<CommentDTO>> GetAllCommentsAsync();
    }
}
