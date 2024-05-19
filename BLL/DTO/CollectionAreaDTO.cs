namespace Collections
{
    public partial class CollectionAreaDTO
    {
        public int AreaId { get; set; }

        public string AreaName { get; set; } = null!;

        public string? Description { get; set; }

        public int? ImageId { get; set; }

        public virtual GalleryImageDTO? Image { get; set; }

        public virtual ICollection<MarketplaceListingDTO> MarketplaceListings { get; set; } = new List<MarketplaceListingDTO>();

        public virtual ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
