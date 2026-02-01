using LibraryCrud.Entities.interfaces;

namespace LibraryCrud.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Sumary { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}