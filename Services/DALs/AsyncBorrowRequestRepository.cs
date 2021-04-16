using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.DALs
{
    public class AsyncBorrowRequestRepository : AsyncDbContextRepository<BorrowRequest>, IAsyncBorrowRequestRepository
    {
        public AsyncBorrowRequestRepository(LibraryContext context) : base(context)
        { }
    }
}