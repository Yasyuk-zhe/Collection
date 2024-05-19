namespace Collections
{
    public partial class GalleryImageDTO
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<CollectionAreaDTO> CollectionAreas { get; set; } = new List<CollectionAreaDTO>();

        public virtual ICollection<CollectionItemDTO> CollectionItems { get; set; } = new List<CollectionItemDTO>();

        public virtual ICollection<MarketplaceListingDTO> MarketplaceListings { get; set; } = new List<MarketplaceListingDTO>();

        public virtual ICollection<NewsDTO> News { get; set; } = new List<NewsDTO>();

        public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
