namespace Collections.Models
{
    public class CollectionItemModel
    {
        public int ItemId { get; set; }

        public int CollectionId { get; set; }

        public string ItemName { get; set; } = null!;

        public string? Description { get; set; }

        public int? ImageId { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual UserCollectionModel Collection { get; set; } = null!;

        public virtual GalleryImageModel? Image { get; set; }
    }
}
