using Microsoft.AspNetCore.Identity;

namespace eCommerce.Infra.Security;
public class ApplicationUser : IdentityUser
{
    public override string? UserName { get => base.Email; set { } }
}