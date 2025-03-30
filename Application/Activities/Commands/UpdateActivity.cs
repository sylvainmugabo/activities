using Application.Activities.DTOs;
using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public static class UpdateActivity
{
    public class Command : IRequest<Result<Unit>>
    {
        public required UpdateActivityDto UpdateActivityDto { get; set; }
    }

    public class Handler(ApplicationContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.UpdateActivityDto.Id], cancellationToken);
            if (activity == null)
            {
                return Result<Unit>.Failure("Activity not found", 404);
            }
            
            mapper.Map(request.UpdateActivityDto, activity);
            var result = await context.SaveChangesAsync(cancellationToken) > 0;
            return result
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure("Save changes failed", 404);
        }
    }
}