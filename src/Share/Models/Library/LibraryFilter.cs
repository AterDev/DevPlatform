namespace Share.Models
{
    public class LibraryFilter : FilterBase
    {
        public Guid? UserId { get; set; }
        public Guid? CatalogId { get; set; }

    }
}