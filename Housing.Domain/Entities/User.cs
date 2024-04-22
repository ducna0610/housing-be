using Housing.Domain.Enums;

namespace Housing.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public RoleEnum Role { get; set; }
    public byte[] Password { get; set; }
    public byte[] PasswordKey { get; set; }

    public virtual ICollection<Property> Properties { get; set; }
}
