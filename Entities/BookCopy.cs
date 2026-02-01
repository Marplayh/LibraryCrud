using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Entities
{
    public class BookCopy : IEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid ShelfId { get; set; }
        public bool IsBorrowed { get; set; }
    }
}