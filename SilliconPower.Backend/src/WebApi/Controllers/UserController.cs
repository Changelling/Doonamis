using Microsoft.AspNetCore.Mvc;
using SilliconPower.Backend.Application.Entities;
using SilliconPower.Backend.Application.Users.Commands.BookingActivity;
using SilliconPower.Backend.Application.Users.Commands.CreateAssessment;
using SilliconPower.Backend.Application.Users.Commands.DeleteAssessment;
using SilliconPower.Backend.Application.Users.Commands.RegisterUser;
using SilliconPower.Backend.Application.Users.Commands.UpdateAssessment;
using SilliconPower.Backend.Application.Users.Queries.GetBookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController: ApiController
    {
        /// <summary>
        /// Register an User.
        /// </summary>
        /// <param name="command">The booking attributes</param>
        [HttpPost]
        public async Task<string> RegisterUser(RegisterUserCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Gets User Bookings.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<BookingsVm>> GetBookings()
        {
            return await Mediator.Send(new GetBookingsQuery());
        }

        /// <summary>
        /// Booking an Activity.
        /// </summary>
        /// <param name="command">The booking attributes</param>
        [HttpPost]
        public async Task<int> BookingActivity(BookingActivityCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Create an Assessment.
        /// </summary>
        /// <param name="command">The assessment attributes</param>
        [HttpPost]
        public async Task<int> CreateAssessment(CreateAssessmentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// Update an Assessment.
        /// </summary>
        /// <param name="id">The assessment id</param>
        /// <param name="command">The assessment attributes</param>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAssessment(int id, UpdateAssessmentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete an Assessment.
        /// </summary>
        /// <param name="id">The assessment id</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssessment(int id)
        {
            await Mediator.Send(new DeleteAssessmentCommand { Id = id });

            return NoContent();
        }
    }
}
