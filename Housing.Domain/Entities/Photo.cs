namespace Housing.Domain.Entities;

public class Photo : BaseEntity
{
    public string PublicId { get; set; }
    public string ImageUrl { get; set; }
    public bool IsPrimary { get; set; }
    public int PropertyId { get; set; }

    public virtual Property Property { get; set; }
}
