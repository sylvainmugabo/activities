using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Persistence;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Security;

public class HostRequirement : IAuthorizationRequirement
{
}

public class HostRequirementHandler(ApplicationContext applicationContext, IHttpContextAccessor httpContextAccessor) 
    : AuthorizationHandler<HostRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HostRequirement requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return;

        var httpContext = httpContextAccessor.HttpContext;
        
        if (httpContext?.GetRouteValue("id") is not string activityId) return;

        if (!Guid.TryParse(userId, out var newUserId) || !Guid.TryParse(activityId, out var newActivityId)) return;
        
        var attendee = await applicationContext.ActivityAttendees
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.UserId == newUserId && x.ActivityId == newActivityId);
        
        if (attendee == null) return;
        
        if(attendee.IsHost) context.Succeed(requirement);

    }
}


