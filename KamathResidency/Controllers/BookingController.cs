using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using KamathResidency.Repos.Implementations;
using KamathResidency.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KamathResidency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingRepo _bookingRepo;

        public BookingController(IBookingRepo bookingReop)
        {
            _bookingRepo = bookingReop;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingsDto>>> GetAllBooking(DateTime? fromDate, DateTime? toDate)
        {
            var bookimgData = await _bookingRepo.GetAllRoomBookings(fromDate, toDate);
            return Ok(bookimgData);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(CreateBookingsDto details)
        {
            var booking = await _bookingRepo.AddBooking(details);
            return CreatedAtAction(nameof(GetBookingDetailsById), new { id = booking.Id.ToString() }, booking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Booking>> UpdateBooking([FromRoute] Guid id, [FromBody] CreateBookingsDto details)
        {
            await _bookingRepo.UpdateBooking(id, details);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingsDto>> GetBookingDetailsById(Guid id)
        {
            var data = await _bookingRepo.GetBookingDetailsById(id);
            return Ok(data);
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<Booking>> PatchBookingPartial([FromRoute] Guid id, [FromBody] PartialBookingUpdateApi details)
        {
            await _bookingRepo.PartialBookingUpdate(id, details);
            return NoContent();
        }
    }


}
