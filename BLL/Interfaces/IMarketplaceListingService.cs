using Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMarketplaceListingService : IDisposable
    {
        Task AddMarketplaceListing(MarketplaceListingDTO marketplaceListingDto);
        Task UpdateMarketplaceListing(MarketplaceListingDTO marketplaceListingDto);
        Task RemoveMarketplaceListing(int listingId);
        Task<MarketplaceListingDTO> GetMarketplaceListingById(int listingId);
        Task<IEnumerable<MarketplaceListingDTO>> GetAllMarketplaceListingsAsync();
    }
}
