namespace Collections.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int ItemId { get; set; }

        public string ItemType { get; set; } = null!;

        public string CommentText { get; set; } = null!;

        public DateTime DatePosted { get; set; }

        public virtual UserViewModel User { get; set; } = null!;
    }
}
