using Application.Activities.DTOs;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;


namespace Application.Activities.Commands;

public static class CreateActivity
{
    public class Command : IRequest<Result<Guid> >
    {
        public required CreateActivityDto ActivityDto { get; set; }
    }

    public class Handler(ApplicationContext context, IMapper mapper, IUserAccessor userAccessor) : IRequestHandler<Command, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await userAccessor.GetUserAsync();
            var activity = mapper.Map<Activity>(request.ActivityDto);
            context.Activities.Add(activity);

            var attendee = new ActivityAttendee()
            {
                ActivityId = activity.Id,
                IsHost = true,
                UserId = user.Id

            };
            activity.Attendees.Add(attendee);
            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            return result 
                ? Result<Guid>.Success(activity.Id) 
                : Result<Guid>.Failure("Save changes failed", 404);
        }
    }
}