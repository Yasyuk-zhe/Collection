﻿namespace Collections
{
    public partial class NewsDTO
    {
        public int NewsId { get; set; }

        public int? ImageId { get; set; }

        public string Headline { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime DatePosted { get; set; }

        public virtual GalleryImageDTO? Image { get; set; }
    }
}
