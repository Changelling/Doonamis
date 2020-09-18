using Microsoft.AspNetCore.Mvc;
using SilliconPower.Backend.Application.Activities.Commands.CreateActivity;
using SilliconPower.Backend.Application.Activities.Commands.DeleteActivity;
using SilliconPower.Backend.Application.Activities.Commands.UpdateActivity;
using SilliconPower.Backend.Application.Activities.Queries.GetActivities;
using SilliconPower.Backend.Application.Activities.Queries.GetActivity;
using SilliconPower.Backend.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/activity")]
    [ApiController]
    public class ActivityController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ActivitiesVm>> Get()
        {
            return await Mediator.Send(new GetActivitiesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDetailDto>> Get(int id)
        {
            return await Mediator.Send(new GetActivityQuery() { Id = id});
        }

        [HttpGet]
        public async Task<ActionResult<ActivitiesVm>> Get(FilterActivitiesQuery query)
        {
            return await Mediator.Send(query);
        }

        /// <summary>
        /// Insert an activity.
        /// </summary>
        /// <param name="command">The activity attributes</param>
        /// <returns>Created Activity Id</returns>
        [HttpPost]
        public async Task<int> CreateActivity(CreateActivityCommand command)
        {
            return await Mediator.Send(command);
        }


        /// <summary>
        /// Updates an Activity.
        /// </summary>
        /// <param name="id">The activity id</param>
        /// <param name="command">The activity attributes</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateActivityCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete an Activity.
        /// </summary>
        /// <param name="id">The activity id</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteActivityCommand { Id = id });

            return NoContent();
        }
    }
}
