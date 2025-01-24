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
        public async Task<ActionResult<List<RoomBookingsDto>>> GetAllBooking(DateTime fromDate, DateTime toDate)
        {
            var bookimgData = await _bookingRepo.GetAllRoomBookings(fromDate, toDate);
            return Ok(bookimgData);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(BookingsDto details)
        {
            var booking = await _bookingRepo.AddBooking(details);
            return Created(booking.Id.ToString(), booking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Booking>> UpdateBooking([FromRoute] Guid id, [FromBody] BookingsDto details)
        {
            var booking = await _bookingRepo.UpdateBooking(id, details);
            return Ok(booking);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingDetailsById([FromRoute] Guid id)
        {
            var data = await _bookingRepo.GetBookingDetailsById(id);
            return Ok(data);
        }
    }


}
