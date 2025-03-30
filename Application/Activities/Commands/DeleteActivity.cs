using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Commands;

public static class DeleteActivity
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Guid Id { get; set; }
    }

    public class Handler(ApplicationContext context) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                .FindAsync([request.Id], cancellationToken);
            if (activity == null) return Result<Unit>.Failure("Activity not found", 404);
            context.Remove(activity);
            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            return result
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure("Failed to delete activity", 404);
        }
    }
    
}