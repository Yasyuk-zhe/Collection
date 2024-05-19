namespace Collections
{
    public partial class AdminDTO
    {
        public int AdminId { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
