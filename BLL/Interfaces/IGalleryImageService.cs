using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class GalleryImageService : IGalleryImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GalleryImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddGalleryImage(GalleryImageDTO galleryImageDto)
        {
            if (string.IsNullOrEmpty(galleryImageDto.ImageUrl))
                throw new ValidationException("URL изображения не может быть пустым", "");

            var galleryImage = _mapper.Map<GalleryImageDTO, GalleryImage>(galleryImageDto);
            await _unitOfWork.GalleryImages.CreateAsync(galleryImage);
            _unitOfWork.Save();
        }

        public async Task UpdateGalleryImage(GalleryImageDTO galleryImageDto)
        {
            GalleryImage updatedGalleryImage = _mapper.Map<GalleryImageDTO, GalleryImage>(galleryImageDto);
            await _unitOfWork.GalleryImages.UpdateAsync(updatedGalleryImage);
            _unitOfWork.Save();
        }

        public async Task RemoveGalleryImage(int imageId)
        {
            GalleryImage galleryImage = await _unitOfWork.GalleryImages.GetAsync(imageId);
            if (galleryImage == null)
                throw new ValidationException("Изображение не найдено", "");

            await _unitOfWork.GalleryImages.DeleteAsync(imageId);
            _unitOfWork.Save();
        }

        public async Task<GalleryImageDTO> GetGalleryImageById(int imageId)
        {
            GalleryImage galleryImage = await _unitOfWork.GalleryImages.GetAsync(imageId);
            if (galleryImage == null)
                throw new ValidationException("Изображение не найдено", "");

            GalleryImageDTO galleryImageDto = _mapper.Map<GalleryImage, GalleryImageDTO>(galleryImage);
            return galleryImageDto;
        }

        public async Task<IEnumerable<GalleryImageDTO>> GetAllGalleryImagesAsync()
        {
            IEnumerable<GalleryImage> galleryImages = await _unitOfWork.GalleryImages.GetAllAsync();
            return _mapper.Map<IEnumerable<GalleryImage>, IEnumerable<GalleryImageDTO>>(galleryImages);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
