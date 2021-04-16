using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.DALs
{
    public class AsyncBookRepository : AsyncDbContextRepository<Book>, IAsyncBookRepository
    {
        public AsyncBookRepository(LibraryContext context) : base(context)
        { }
    }
}