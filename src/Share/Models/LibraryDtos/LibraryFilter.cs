namespace Share.Models.LibraryDtos;

public class LibraryFilter : FilterBase
{
    public Guid? UserId { get; set; }
    public Guid? CatalogId { get; set; }

}
