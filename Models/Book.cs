using System.Collections.Generic;
using Newtonsoft.Json;

namespace back_end.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public virtual List<BorrowRequestDetails> BorrowRequestDetails { get; set; }
    }

    public class BookResponse
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
    }
}