using Application.Activities.DTOs;
using Application.Core;
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

    public class Handler(ApplicationContext context, IMapper mapper) : IRequestHandler<Command, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = mapper.Map<Activity>(request.ActivityDto);
            context.Activities.Add(activity);
            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            return result 
                ? Result<Guid>.Success(activity.Id) 
                : Result<Guid>.Failure("Save changes failed", 404);
        }
    }
}