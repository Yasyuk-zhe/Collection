using Collections;
using BLL.Interfaces;
using DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Collections.BLL.Infrastructure;

namespace BLL.Services
{
    public class MarketplaceListingService : IMarketplaceListingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarketplaceListingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddMarketplaceListing(MarketplaceListingDTO marketplaceListingDto)
        {
            if (string.IsNullOrEmpty(marketplaceListingDto.ItemName))
                throw new ValidationException("Название объявления не может быть пустым", "");

            var marketplaceListing = _mapper.Map<MarketplaceListingDTO, MarketplaceListing>(marketplaceListingDto);
            await _unitOfWork.MarketplaceListings.CreateAsync(marketplaceListing);
            _unitOfWork.Save();
        }

        public async Task UpdateMarketplaceListing(MarketplaceListingDTO marketplaceListingDto)
        {
            MarketplaceListing updatedMarketplaceListing = _mapper.Map<MarketplaceListingDTO, MarketplaceListing>(marketplaceListingDto);
            await _unitOfWork.MarketplaceListings.UpdateAsync(updatedMarketplaceListing);
            _unitOfWork.Save();
        }

        public async Task RemoveMarketplaceListing(int listingId)
        {
            MarketplaceListing marketplaceListing = await _unitOfWork.MarketplaceListings.GetAsync(listingId);
            if (marketplaceListing == null)
                throw new ValidationException("Объявление не найдено", "");

            await _unitOfWork.MarketplaceListings.DeleteAsync(listingId);
            _unitOfWork.Save();
        }

        public async Task<MarketplaceListingDTO> GetMarketplaceListingById(int listingId)
        {
            MarketplaceListing marketplaceListing = await _unitOfWork.MarketplaceListings.GetAsync(listingId);
            if (marketplaceListing == null)
                throw new ValidationException("Объявление не найдено", "");

            MarketplaceListingDTO marketplaceListingDto = _mapper.Map<MarketplaceListing, MarketplaceListingDTO>(marketplaceListing);
            return marketplaceListingDto;
        }

        public async Task<IEnumerable<MarketplaceListingDTO>> GetAllMarketplaceListingsAsync()
        {
            IEnumerable<MarketplaceListing> marketplaceListings = await _unitOfWork.MarketplaceListings.GetAllAsync();
            return _mapper.Map<IEnumerable<MarketplaceListing>, IEnumerable<MarketplaceListingDTO>>(marketplaceListings);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
