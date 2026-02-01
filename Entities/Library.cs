using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Entities
{
    public class Library : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shelf> Shelves { get; set; }
    }
}