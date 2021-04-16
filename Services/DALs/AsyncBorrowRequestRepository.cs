using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services.DALs
{
    public class AsyncBorrowRequestRepository : AsyncDbContextRepository<BorrowRequest>, IAsyncBorrowRequestRepository
    {
        public AsyncBorrowRequestRepository(LibraryContext context) : base(context)
        { }

        public async override Task Create(BorrowRequest entity)
        {
            ValidateBorrowRequestDetailsListState(entity);
            await ValidateValidNumberOfRequestsForCurrentMonth(entity);

            await base.Create(entity);
        }


        public async override Task Update(int id, BorrowRequest entity)
        {
            ValidateBorrowRequestDetailsListState(entity);
            await base.Update(id, entity);
        }

        private async Task ValidateValidNumberOfRequestsForCurrentMonth(BorrowRequest entity)
        {
            var requestedYear = entity.BorrowRequestDate.Year;
            var requestedMonth = entity.BorrowRequestDate.Month;
            var curMonthRequestsCount = await
                _context.BorrowRequest
                .AsNoTracking()
                .AsQueryable()
                .Where(br => br.RequestUserId == entity.RequestUserId)
                .Where(br =>
                    br.BorrowRequestDate.Year == requestedYear
                    && br.BorrowRequestDate.Month == requestedMonth
                )
                .CountAsync();
            if (curMonthRequestsCount >= 3)
            {
                throw new ArgumentException("User has exceeded the alloted max. of 3 requests per month. Cannot create request.");
            }
        }

        private static void ValidateBorrowRequestDetailsListState(BorrowRequest entity)
        {
            if (entity.BorrowRequestDetails.Count == 0)
            {
                throw new ArgumentException("Borrow request must request at least 1 book");
            }

            if (entity.BorrowRequestDetails.Count > 5)
            {
                throw new ArgumentException("Borrow request only allows at most 5 books per request");
            }
        }
    }
}