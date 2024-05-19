using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGalleryImageService : IDisposable
    {
        Task AddGalleryImage(GalleryImageDTO galleryImageDto);
        Task UpdateGalleryImage(GalleryImageDTO galleryImageDto);
        Task RemoveGalleryImage(int imageId);
        Task<GalleryImageDTO> GetGalleryImageById(int imageId);
        Task<IEnumerable<GalleryImageDTO>> GetAllGalleryImagesAsync();
    }
}
