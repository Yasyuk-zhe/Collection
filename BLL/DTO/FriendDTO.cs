namespace Collections
{
    public partial class FriendDTO
    {
        public int FriendshipId { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual UserDTO User1 { get; set; } = null!;

        public virtual UserDTO User2 { get; set; } = null!;
    }
}
