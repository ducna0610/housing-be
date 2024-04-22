using Housing.Domain.Enums;

namespace Housing.Domain.Entities;

public class Property : BaseEntity
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int Area { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public CategoryEnum Category { get; set; }
    public FurnishEnum FurnishingType { get; set; }
    public bool IsActive { get; set; }
    public int CityId { get; set; }
    public int PostedBy { get; set; }

    public virtual City City { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Photo> Photos { get; set; }
}
