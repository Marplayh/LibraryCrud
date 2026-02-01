using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Entities
{
    public class Shelf : IEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid LibraryId { get; set; }
        public List<BookCopy> Copies { get; set; }
    }
}