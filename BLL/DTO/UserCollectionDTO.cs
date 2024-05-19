namespace Collections
{
    public partial class UserCollectionDTO
    {
        public int CollectionId { get; set; }
        public int UserId { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual UserDTO User { get; set; }
        public virtual ICollection<CollectionItemDTO> CollectionItems { get; set; }
    }
}
