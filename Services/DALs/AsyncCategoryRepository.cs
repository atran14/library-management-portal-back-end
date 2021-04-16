using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;

namespace back_end.Services.DALs
{
    public class AsyncCategoryRepository : AsyncDbContextRepository<Category>, IAsyncCategoryRepository
    {
        public AsyncCategoryRepository(LibraryContext context) : base(context)
        { }
    }
}