namespace Housing.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }

    public virtual Property Property { get; set; }
}