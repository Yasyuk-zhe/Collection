namespace Collections.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string MessageText { get; set; } = null!;

        public DateTime Timestamp { get; set; }

        public string? Status { get; set; }

        public virtual UserViewModel Recipient { get; set; } = null!;

        public virtual UserViewModel Sender { get; set; } = null!;
    }
}
