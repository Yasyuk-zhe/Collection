using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INewsService : IDisposable
    {
        Task AddNews(NewsDTO newsDto);
        Task UpdateNews(NewsDTO newsDto);
        Task RemoveNews(int newsId);
        Task<NewsDTO> GetNewsById(int newsId);
        Task<IEnumerable<NewsDTO>> GetAllNewsAsync();
    }
}
