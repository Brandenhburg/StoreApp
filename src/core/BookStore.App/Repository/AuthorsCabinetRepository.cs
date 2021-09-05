using Bookstore.Data.Contexts;

namespace Bookstore.App.Repository
{
    public class AuthorsCabinetRepository
    {
        private readonly BookStoreDbContext context;

        public AuthorsCabinetRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

    }
}
