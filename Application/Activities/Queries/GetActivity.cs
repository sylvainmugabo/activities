using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries;

public static class GetActivity
{
    public class Query() : IRequest<Result<Activity>>
    {
        public Guid Id { get; init; }
    }

    public class Handler(ApplicationContext context) : IRequestHandler<Query, Result<Activity>>
    {
        public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            var activity =await context.Activities
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return activity == null 
                ? Result<Activity>.Failure("Activity not found", 404) 
                : Result<Activity>.Success(activity);
        }
    }
}