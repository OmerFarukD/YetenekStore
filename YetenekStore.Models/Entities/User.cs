using Microsoft.AspNetCore.Identity;

namespace YetenekStore.Models.Entities;

public sealed class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public List<Order> Orders { get; set; }
}