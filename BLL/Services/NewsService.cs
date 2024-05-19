using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddNews(NewsDTO newsDto)
        {
            if (string.IsNullOrEmpty(newsDto.Headline))
                throw new ValidationException("Заголовок новости не может быть пустым", "");

            var news = _mapper.Map<NewsDTO, News>(newsDto);
            await _unitOfWork.Newss.CreateAsync(news);
            _unitOfWork.Save();
        }

        public async Task UpdateNews(NewsDTO newsDto)
        {
            News updatedNews = _mapper.Map<NewsDTO, News>(newsDto);
            await _unitOfWork.Newss.UpdateAsync(updatedNews);
            _unitOfWork.Save();
        }

        public async Task RemoveNews(int newsId)
        {
            News news = await _unitOfWork.Newss.GetAsync(newsId);
            if (news == null)
                throw new ValidationException("Новость не найдена", "");

            await _unitOfWork.Newss.DeleteAsync(newsId);
            _unitOfWork.Save();
        }

        public async Task<NewsDTO> GetNewsById(int newsId)
        {
            News news = await _unitOfWork.Newss.GetAsync(newsId);
            if (news == null)
                throw new ValidationException("Новость не найдена", "");

            NewsDTO newsDto = _mapper.Map<News, NewsDTO>(news);
            return newsDto;
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            IEnumerable<News> allNews = await _unitOfWork.Newss.GetAllAsync();
            return _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(allNews);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
