using System.Collections.Generic;

namespace back_end.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Book> Books {get; set;}
    }

    public class CategoryResponse : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}