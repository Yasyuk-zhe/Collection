namespace Collections.Models
{
    public class GalleryImageModel
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<CollectionAreaModel> CollectionAreas { get; set; } = new List<CollectionAreaModel>();

        public virtual ICollection<CollectionItemModel> CollectionItems { get; set; } = new List<CollectionItemModel>();

        public virtual ICollection<MarketplaceListingModel> MarketplaceListings { get; set; } = new List<MarketplaceListingModel>();

        public virtual ICollection<NewsModel> News { get; set; } = new List<NewsModel>();

        public virtual ICollection<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }
}
