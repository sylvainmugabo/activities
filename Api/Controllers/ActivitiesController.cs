using Application.Activities.Commands;
using Application.Activities.DTOs;
using Application.Activities.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Activity = Domain.Activity;

namespace Api.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityDto>>> Get()
    {
        return HandleResult(await Mediator.Send(new GetActivityList.Query()));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ActivityDto>> Get(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetActivity.Query { Id = id }));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateActivityDto activityDto)
    {
        return HandleResult(await Mediator.Send(new CreateActivity.Command { ActivityDto = activityDto }));
    }

    [HttpPut]
    [Route("{id:guid}")]
    [Authorize(Policy = "IsActivityHost")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateActivityDto activity)
    {
        activity.Id = id;
        return HandleResult(await Mediator.Send(new UpdateActivity.Command { UpdateActivityDto = activity }));
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "IsActivityHost")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await Mediator.Send(new DeleteActivity.Command { Id = id })) ;
    }

    [HttpPost("{id:guid}/attend")]
    public async Task<ActionResult> Attend(Guid id)
    {
        return HandleResult(await Mediator.Send(new UpdateAttendance.Command { Id = id })) ;
    }
    
}