namespace Collections
{
    public partial class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime DateRegistered { get; set; }

        public int? ImageId { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; } = new List<CommentDTO>();

        public virtual ICollection<FriendDTO> FriendUser1s { get; set; } = new List<FriendDTO>();

        public virtual ICollection<FriendDTO> FriendUser2s { get; set; } = new List<FriendDTO>();

        public virtual GalleryImageDTO? Image { get; set; }

        public virtual ICollection<MarketplaceListingDTO> MarketplaceListings { get; set; } = new List<MarketplaceListingDTO>();

        public virtual ICollection<MessageDTO> MessageRecipients { get; set; } = new List<MessageDTO>();

        public virtual ICollection<MessageDTO> MessageSenders { get; set; } = new List<MessageDTO>();

        public virtual ICollection<UserCollectionDTO> UserCollections { get; set; } = new List<UserCollectionDTO>();

        public virtual ICollection<CollectionAreaDTO> Areas { get; set; } = new List<CollectionAreaDTO>();
    }
}
