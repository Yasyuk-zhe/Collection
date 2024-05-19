namespace Collections.Models
{
    public class FriendModel
    {
        public int FriendshipId { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual UserViewModel User1 { get; set; } = null!;

        public virtual UserViewModel User2 { get; set; } = null!;
    }
}
