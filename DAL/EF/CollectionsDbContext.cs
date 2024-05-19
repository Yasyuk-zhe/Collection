using Microsoft.EntityFrameworkCore;


namespace Collections;

public partial class CollectionsDbContext : DbContext
{
    public CollectionsDbContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public CollectionsDbContext(DbContextOptions<CollectionsDbContext> options)
        : base(options)
    {
    }

    public string ConnectionString;
    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<CollectionArea> CollectionAreas { get; set; }

    public virtual DbSet<CollectionItem> CollectionItems { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<GalleryImage> GalleryImages { get; set; }

    public virtual DbSet<MarketplaceListing> MarketplaceListings { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCollection> UserCollections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=CollectionsDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__43AA4141884AED9A");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<CollectionArea>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Collecti__985D6D6BE1684367");

            entity.ToTable("Collection_Areas");

            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("area_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageId).HasColumnName("image_id");

            entity.HasOne(d => d.Image).WithMany(p => p.CollectionAreas)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Collectio__image__3D5E1FD2");
        });

        modelBuilder.Entity<CollectionItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Collecti__52020FDD6933CDD4");

            entity.ToTable("Collection_Items");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.CollectionId).HasColumnName("collection_id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_name");

            entity.HasOne(d => d.Collection).WithMany(p => p.CollectionItems)
                .HasForeignKey(d => d.CollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Collectio__colle__44FF419A");

            entity.HasOne(d => d.Image).WithMany(p => p.CollectionItems)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Collectio__image__45F365D3");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comments__E7957687241108AA");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.CommentText)
                .HasColumnType("text")
                .HasColumnName("comment_text");
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_posted");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.ItemType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("item_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__user_i__4E88ABD4");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasKey(e => e.FriendshipId).HasName("PK__Friends__BC802BCF7F196981");

            entity.Property(e => e.FriendshipId).HasColumnName("friendship_id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.User1Id).HasColumnName("user1_id");
            entity.Property(e => e.User2Id).HasColumnName("user2_id");

            entity.HasOne(d => d.User1).WithMany(p => p.FriendUser1s)
                .HasForeignKey(d => d.User1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friends__user1_i__49C3F6B7");

            entity.HasOne(d => d.User2).WithMany(p => p.FriendUser2s)
                .HasForeignKey(d => d.User2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Friends__user2_i__4AB81AF0");
        });

        modelBuilder.Entity<GalleryImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Gallery___DC9AC95541BAF271");

            entity.ToTable("Gallery_Images");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
        });

        modelBuilder.Entity<MarketplaceListing>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__Marketpl__89D81774043A46F8");

            entity.ToTable("Marketplace_Listings");

            entity.Property(e => e.ListingId).HasColumnName("listing_id");
            entity.Property(e => e.AreaId).HasColumnName("area_id");
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_posted");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.ListingType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("listing_type");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Area).WithMany(p => p.MarketplaceListings)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__Marketpla__area___59063A47");

            entity.HasOne(d => d.Image).WithMany(p => p.MarketplaceListings)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Marketpla__image__5812160E");

            entity.HasOne(d => d.User).WithMany(p => p.MarketplaceListings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marketpla__user___571DF1D5");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__0BBF6EE6F94DB241");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.MessageText)
                .HasColumnType("text")
                .HasColumnName("message_text");
            entity.Property(e => e.RecipientId).HasColumnName("recipient_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Recipient).WithMany(p => p.MessageRecipients)
                .HasForeignKey(d => d.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__recipi__534D60F1");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__sender__52593CB8");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__4C27CCD816181156");

            entity.Property(e => e.NewsId).HasColumnName("news_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_posted");
            entity.Property(e => e.Headline)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("headline");
            entity.Property(e => e.ImageId).HasColumnName("image_id");

            entity.HasOne(d => d.Image).WithMany(p => p.News)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__News__image_id__5CD6CB2B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F297256DE");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.DateRegistered)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_registered");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Image).WithMany(p => p.Users)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK__Users__image_id__3A81B327");

            entity.HasMany(d => d.Areas).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserCollectionArea",
                    r => r.HasOne<CollectionArea>().WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Coll__area___628FA481"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Coll__user___619B8048"),
                    j =>
                    {
                        j.HasKey("UserId", "AreaId").HasName("PK__User_Col__103BE1D9D7BD682F");
                        j.ToTable("User_Collection_Areas");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("AreaId").HasColumnName("area_id");
                    });
        });

        modelBuilder.Entity<UserCollection>(entity =>
        {
            entity.HasKey(e => e.CollectionId).HasName("PK__User_Col__53D3A5CA3AD8488E");

            entity.ToTable("User_Collections");

            entity.Property(e => e.CollectionId).HasColumnName("collection_id");
            entity.Property(e => e.CollectionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("collection_name");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserCollections)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User_Coll__user___412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
