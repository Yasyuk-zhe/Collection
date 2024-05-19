namespace Collections
{
    public partial class GalleryImage
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<CollectionArea> CollectionAreas { get; set; } = new List<CollectionArea>();

        public virtual ICollection<CollectionItem> CollectionItems { get; set; } = new List<CollectionItem>();

        public virtual ICollection<MarketplaceListing> MarketplaceListings { get; set; } = new List<MarketplaceListing>();

        public virtual ICollection<News> News { get; set; } = new List<News>();

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
