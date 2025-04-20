using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Commands;

public static class UpdateAttendance
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Guid Id { get; set; }
    }

    public class Handler(ApplicationContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var  activity =  await context
                .Activities
                .Include(x => x.Attendees)
                .ThenInclude(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == request.Id,  cancellationToken);

            if (activity == null) return Result<Unit>.Failure("Could not find activity",404);
            
            var attendance = 
                activity.Attendees.FirstOrDefault(x => x.UserId == request.Id);
            var isHost = activity.Attendees.Any(x => x.UserId == request.Id && x.IsHost);

            if (attendance != null)
            {
                if(isHost) activity.IsCancelled = !activity.IsCancelled;
                else activity.Attendees.Remove(attendance);
            }
            else
            {
                activity.Attendees.Add(new ActivityAttendee
                {
                    UserId = request.Id,
                    IsHost = isHost,
                    ActivityId = activity.Id
                });
            }
            
            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Could not update activity",404);
        }
    }

}