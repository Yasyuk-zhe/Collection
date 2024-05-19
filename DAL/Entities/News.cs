namespace Collections
{
    public partial class News
    {
        public int NewsId { get; set; }

        public int? ImageId { get; set; }

        public string Headline { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime DatePosted { get; set; }

        public virtual GalleryImage? Image { get; set; }
    }
}
