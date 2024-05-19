
using System.Xml.Linq;

namespace Collections.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime DateRegistered { get; set; }

        public int? ImageId { get; set; }

        public virtual ICollection<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public virtual ICollection<FriendModel> FriendUser1s { get; set; } = new List<FriendModel>();

        public virtual ICollection<FriendModel> FriendUser2s { get; set; } = new List<FriendModel>();

        public virtual GalleryImageModel? Image { get; set; }

        public virtual ICollection<MarketplaceListingModel> MarketplaceListings { get; set; } = new List<MarketplaceListingModel>();

        public virtual ICollection<MessageModel> MessageRecipients { get; set; } = new List<MessageModel>();

        public virtual ICollection<MessageModel> MessageSenders { get; set; } = new List<MessageModel>();

        public virtual ICollection<UserCollectionModel> UserCollections { get; set; } = new List<UserCollectionModel>();

        public virtual ICollection<CollectionAreaModel> Areas { get; set; } = new List<CollectionAreaModel>();
    }
}
