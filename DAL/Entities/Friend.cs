namespace Collections
{
    public partial class Friend
    {
        public int FriendshipId { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual User User1 { get; set; } = null!;

        public virtual User User2 { get; set; } = null!;
    }
}
