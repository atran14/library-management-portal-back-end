using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services.DALs
{
    public class AsyncBorrowRequestDetailsRepository : AsyncDbContextRepository<BorrowRequestDetails>, IAsyncBorrowRequestDetailsRepository
    {
        public AsyncBorrowRequestDetailsRepository(LibraryContext context) : base(context)
        { }

        public async override Task Create(BorrowRequestDetails entity)
        {
            ValidateBorrowRequestDetailsListState(entity);

            await base.Create(entity);
        }

        public async override Task Update(int id, BorrowRequestDetails entity)
        {
            ValidateBorrowRequestDetailsListState(entity);

            await base.Update(id, entity);
        }

        private static void ValidateBorrowRequestDetailsListState(BorrowRequestDetails entity)
        {
            if (entity.BorrowRequest.BorrowRequestDetails.Count + 1 > 5)
            {
                throw new ArgumentException("Associated borrow request has already maxed out 5 book for the request. Cannot update for this borrow request");
            }
        }
    }
}