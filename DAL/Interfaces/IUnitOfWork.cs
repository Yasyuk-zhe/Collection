using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Admin> Admins { get; }

        IRepository<CollectionArea> CollectionAreas { get; }

        IRepository<CollectionItem> CollectionItems { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Friend> Friends { get; }

        IRepository<GalleryImage> GalleryImages { get; }

        IRepository<MarketplaceListing> MarketplaceListings { get; }

        IRepository<Message> Messages { get; }

        IUserRepository Users { get; }

        IRepository<News> Newss { get; }

        IRepository<UserCollection> UserCollections { get; }


        void Save();
    }
}
