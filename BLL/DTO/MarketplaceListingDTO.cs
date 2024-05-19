namespace Collections
{
    public partial class MarketplaceListingDTO
    {
        public int ListingId { get; set; }

        public int UserId { get; set; }

        public int? ImageId { get; set; }

        public string ItemName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public DateTime DatePosted { get; set; }

        public int? AreaId { get; set; }

        public string ListingType { get; set; } = null!;

        public virtual CollectionAreaDTO? Area { get; set; }

        public virtual GalleryImageDTO? Image { get; set; }

        public virtual UserDTO User { get; set; } = null!;
    }
}
