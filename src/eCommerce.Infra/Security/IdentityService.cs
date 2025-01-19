using eCommerce.Application.Common.Bases;
using eCommerce.Application.Common.Exceptions;
using eCommerce.Domain.Security;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Infra.Security;
public class IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public async Task<string> AddAsync(string email, string password)
    {
        var user = new ApplicationUser { Email = email };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var errorMessages = result.Errors.Select(x => new BaseError(errorCode: x.Code, errorMessage: x.Description));
            throw new eCommerceException(errorMessages);
        }

        return user.Id;
    }

    public async Task<bool> AuthorizeAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded;
    }
}
