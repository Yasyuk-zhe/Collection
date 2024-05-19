
using System.Xml.Linq;

namespace Collections
{
    public partial class User
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime DateRegistered { get; set; }

        public int? ImageId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Friend> FriendUser1s { get; set; } = new List<Friend>();

        public virtual ICollection<Friend> FriendUser2s { get; set; } = new List<Friend>();

        public virtual GalleryImage? Image { get; set; }

        public virtual ICollection<MarketplaceListing> MarketplaceListings { get; set; } = new List<MarketplaceListing>();

        public virtual ICollection<Message> MessageRecipients { get; set; } = new List<Message>();

        public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

        public virtual ICollection<UserCollection> UserCollections { get; set; } = new List<UserCollection>();

        public virtual ICollection<CollectionArea> Areas { get; set; } = new List<CollectionArea>();
    }
}
