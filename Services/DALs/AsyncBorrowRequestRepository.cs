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

            if (!ValidateBorrowRequestDetailsHasAtLeastOneBook(entity))
            {
                throw new ArgumentException("Borrow request must request at least 1 book");
            }
            if (!ValidateBorrowRequestDetailsHasAtMostFiveBook(entity))
            {
                throw new ArgumentException("Borrow request only allows at most 5 books per request");
            }
            if (!ValidateValidNumberOfRequestsForCurrentMonth(entity))
            {
                throw new ArgumentException("User has exceeded the allowed 3 number of requests per month");
            }

            await base.Create(entity);
        }


        public async override Task Update(int id, BorrowRequest entity)
        {
            if (!ValidateBorrowRequestDetailsHasAtLeastOneBook(entity))
            {
                throw new ArgumentException("Borrow request must request at least 1 book");
            }
            if (!ValidateBorrowRequestDetailsHasAtMostFiveBook(entity))
            {
                throw new ArgumentException("Borrow request only allows at most 5 books per request");
            }

            await base.Update(id, entity);
        }

        private bool ValidateValidNumberOfRequestsForCurrentMonth(BorrowRequest entity)
        {
            var requestedYear = entity.BorrowRequestDate.Year;
            var requestedMonth = entity.BorrowRequestDate.Month;
            var curMonthRequestsCount = _context.BorrowRequest
                .AsNoTracking()
                .AsQueryable()
                .Where(br => br.RequestUserId == entity.RequestUserId)
                .Where(br =>
                    br.BorrowRequestDate.Year == requestedYear
                    && br.BorrowRequestDate.Month == requestedMonth
                )
                .Count();
            return curMonthRequestsCount <= 3;
        }

        private bool ValidateBorrowRequestDetailsHasAtLeastOneBook(BorrowRequest br)
        {
            return br.BorrowRequestDetails.Count > 0;
        }

        private bool ValidateBorrowRequestDetailsHasAtMostFiveBook(BorrowRequest br)
        {
            return br.BorrowRequestDetails.Count <= 5;
        }
    }
}