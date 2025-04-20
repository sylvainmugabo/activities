using System.Security.Claims;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Infrastructure;

public class UserAccessor(IHttpContextAccessor httpContextAccessor, ApplicationContext context) : IUserAccessor
{
    public string GetUserId() => httpContextAccessor
        .HttpContext.User
        .FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("User not found");

    public async Task<User> GetUserAsync() => await 
        context.Users.FindAsync(GetUserId()) ?? throw new UnauthorizedAccessException("User not logged in");
}