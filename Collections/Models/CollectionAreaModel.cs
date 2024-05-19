namespace Collections.Models
{
    public class CollectionAreaModel
    {
        public int AreaId { get; set; }

        public string AreaName { get; set; } = null!;

        public string? Description { get; set; }

        public int? ImageId { get; set; }

        public virtual GalleryImageModel? Image { get; set; }

        public virtual ICollection<MarketplaceListingModel> MarketplaceListings { get; set; } = new List<MarketplaceListingModel>();

        public virtual ICollection<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }
}
