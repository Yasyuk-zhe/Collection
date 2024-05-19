namespace Collections.Models
{
    public class NewsModel
    {
        public int NewsId { get; set; }

        public int? ImageId { get; set; }

        public string Headline { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime DatePosted { get; set; }

        public virtual GalleryImageModel? Image { get; set; }
    }
}
