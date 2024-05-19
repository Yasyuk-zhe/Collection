using DAL.Interfaces;
using Collections;
using Microsoft.Extensions.Configuration;
using System;
namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CollectionsDbContext db;
        private AdminRepository adminRepository;
        private CollectionAreaRepository collectionAreaRepository;
        private CollectionItemRepository collectionItemRepository;
        private CommentRepository commentRepository;
        private FriendRepository friendRepository;
        private GalleryImageRepository galleryImageRepository;
        private MarketplaceListingRepository marketplaceListingRepository;
        private MessageRepository messageRepository;
        private UserRepository userRepository;
        private NewsRepository newsRepository;
        private UserCollectionRepository userCollectionRepository;

        public EFUnitOfWork(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            db = new CollectionsDbContext(connectionString);
        }

        public IRepository<Admin> Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }

        public IRepository<CollectionArea> CollectionAreas
        {
            get
            {
                if (collectionAreaRepository == null)
                    collectionAreaRepository = new CollectionAreaRepository(db);
                return collectionAreaRepository;
            }
        }

        public IRepository<CollectionItem> CollectionItems
        {
            get
            {
                if (collectionItemRepository == null)
                    collectionItemRepository = new CollectionItemRepository(db);
                return collectionItemRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Friend> Friends
        {
            get
            {
                if (friendRepository == null)
                    friendRepository = new FriendRepository(db);
                return friendRepository;
            }
        }

        public IRepository<GalleryImage> GalleryImages
        {
            get
            {
                if (galleryImageRepository == null)
                    galleryImageRepository = new GalleryImageRepository(db);
                return galleryImageRepository;
            }
        }

        public IRepository<MarketplaceListing> MarketplaceListings
        {
            get
            {
                if (marketplaceListingRepository == null)
                    marketplaceListingRepository = new MarketplaceListingRepository(db);
                return marketplaceListingRepository;
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<News> Newss
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);
                return newsRepository;
            }
        }

        public IRepository<UserCollection> UserCollections
        {
            get
            {
                if (userCollectionRepository == null)
                    userCollectionRepository = new UserCollectionRepository(db);
                return userCollectionRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
