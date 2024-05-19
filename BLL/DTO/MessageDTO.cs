namespace Collections
{
    public partial class MessageDTO
    {
        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        public string MessageText { get; set; } = null!;

        public DateTime Timestamp { get; set; }

        public string? Status { get; set; }

        public virtual UserDTO Recipient { get; set; } = null!;

        public virtual UserDTO Sender { get; set; } = null!;
    }
}
