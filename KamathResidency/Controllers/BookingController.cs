using KamathResidency.DTO;
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
    }
}
