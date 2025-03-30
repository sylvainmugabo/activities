using Application.Activities.Commands;
using Application.Activities.DTOs;
using Application.Activities.Queries;
using Microsoft.AspNetCore.Mvc;
using Activity = Domain.Activity;

namespace Api.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Activity>>> Get()
    {
        return HandleResult(await Mediator.Send(new GetActivityList.Query()));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Activity>> Get(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetActivity.Query { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateActivityDto activityDto)
    {
        return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateActivityDto activity)
    {
       return HandleResult(await Mediator.Send(new UpdateActivity.Command{ UpdateActivityDto = activity}));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id })) ;
    }
}