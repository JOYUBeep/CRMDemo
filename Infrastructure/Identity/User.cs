using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class User : IdentityUser<int>
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public string FirstName { get; internal set; }
    public string LastName { get; internal set; }
}