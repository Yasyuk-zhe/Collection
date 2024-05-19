namespace Collections
{
    public partial class CollectionArea
    {

        public int AreaId { get; set; }

        public string AreaName { get; set; } = null!;

        public string? Description { get; set; }

        public int? ImageId { get; set; }

        public virtual GalleryImage? Image { get; set; }

        public virtual ICollection<MarketplaceListing> MarketplaceListings { get; set; } = new List<MarketplaceListing>();

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}