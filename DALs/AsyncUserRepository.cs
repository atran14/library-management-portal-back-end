using System.Collections.Generic;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;

namespace back_end.DALs
{

    public class AsyncUserRepository : AsyncDbContextRepository<User>, IAsyncUserRepository
    {
        public AsyncUserRepository(LibraryContext context) : base(context)
        { }
    }
}