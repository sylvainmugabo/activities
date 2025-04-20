using Domain;

namespace Application.Interfaces;

public interface IUserAccessor
{
    Guid GetUserId();
    Task<User> GetUserAsync();
}