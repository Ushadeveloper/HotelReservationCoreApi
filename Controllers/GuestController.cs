using HotelReservation.Model;
using HotelReservation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
    public class GuestController : Controller
    {
        //Dependency Injection..............................
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;

            //this.guestService = guestService;



        }

        //Display Get All ..............................

        [HttpGet("api/Guest")]
        public async Task<IActionResult> DisplayGuest()
        {
            try
            {
                var guests = await _guestService.GetGuest();
                if (guests.Count == 0)
                {
                    return NotFound("Your Guest Data not Exist....");
                }
                return this.Ok(guests);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Display Get by Id ..............................

        [HttpGet("api/Guest/{id}")]

        public async Task<IActionResult> DisplayGuestId(int id)
        {
            try
            {
                var guest = await _guestService.GetGuest(id);
                if (guest == null)
                {
                    return NotFound($"Your Guest Id:{id} not Exist....");
                }
                return this.Ok(guest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Post by Id ..............................


        [HttpPost("api/Guest")]
        public async Task<IActionResult> InsertGuest([FromBody] Guest guest)
        {
            try
            {
                var result = await _guestService.PostGuest(guest);

                if (result > 0)
                {
                    return this.Ok("True");
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        //Put

        [HttpPut("api/Guest/{id}")]

        public async Task<IActionResult> ChangeGuest(int id, [FromBody] Guest guest)
        {
            try
            {
                var guestget = await _guestService.GetGuest(id);
                if (guestget == null)
                {
                    return this.NotFound($"Guest {id} not found..");
                }
                guest.Id = id;
                var result = await _guestService.UpdateGuest(guest);
                if (result > 0)
                {
                    return this.Ok("True");

                }
                else
                {
                    return this.BadRequest("False");
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        //Delete

        [HttpDelete("api/Guest/{id}")]

        public async Task<IActionResult> TerminateGuest(int id)
        {
            try
            {
                var guestget = await _guestService.GetGuest(id);
                if (guestget == null)
                {
                    return this.NotFound($"Guest {id} not found..");
                }
                var result = await _guestService.DeleteGuest(id);
                if (result > 0)
                {
                    return this.Ok("True");

                }
                else
                {
                    return this.BadRequest("False");
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

    }
}
