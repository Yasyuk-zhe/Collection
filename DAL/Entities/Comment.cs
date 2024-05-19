namespace Collections
{
    public partial class Comment
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int ItemId { get; set; }

        public string ItemType { get; set; } = null!;

        public string CommentText { get; set; } = null!;

        public DateTime DatePosted { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
