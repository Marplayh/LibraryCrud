using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Entities
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}