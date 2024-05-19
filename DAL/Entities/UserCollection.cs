namespace Collections
{
    public partial class UserCollection
    {
        public int CollectionId { get; set; }
        public int UserId { get; set; }
        public string CollectionName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateCreated { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CollectionItem> CollectionItems { get; set; } = new List<CollectionItem>();
    }
}
