using System.Security.Claims;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Infrastructure.Security;

public class UserAccessor(IHttpContextAccessor httpContextAccessor, ApplicationContext context) : IUserAccessor
{
    public Guid GetUserId()
    {
        var userId = httpContextAccessor
            .HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) throw new Exception("User not found");
        if(!Guid.TryParse(userId, out var newUserId)) throw new Exception("Unable to parse user id");
        return newUserId;
    }

    public async Task<User> GetUserAsync() => await 
        context.Users.FindAsync(GetUserId()) ?? throw new UnauthorizedAccessException("User not logged in");
}