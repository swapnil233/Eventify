using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Activities;
namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    // Get activities
    [HttpGet("/api/activities/")]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new List.Query());
    }

    // Get activity
    [HttpGet("/api/activities/{id}")]
    public async Task<ActionResult<Activity>> GetActivity(Guid id)
    {
        return await Mediator.Send(new Details.Query { Id = id });
    }

    // Create activity
    [HttpPost("/api/activities/")]
    public async Task<IActionResult> CreateActivity(Activity activity)
    {
        return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
    }

    // Edit activity
    [HttpPut("/api/activities/{id}")]
    public async Task<IActionResult> EditActivity(Guid id, Activity activity)
    {
        activity.Id = id;
        return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
    }

    // Delete activity
    [HttpDelete("/api/activities/{id}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        return Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
}