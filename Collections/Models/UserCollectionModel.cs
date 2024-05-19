namespace Collections.Models
{
    public class UserCollectionModel
    {
        public int CollectionId { get; set; }
        public int UserId { get; set; }
        public string CollectionName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual UserViewModel User { get; set; } = null!;
        public virtual ICollection<CollectionItemModel> CollectionItems { get; set; } = new List<CollectionItemModel>();
    }
}
