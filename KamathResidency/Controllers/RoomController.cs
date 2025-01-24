using KamathResidency.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly KamahResidencyContext _context;

        public RoomController(KamahResidencyContext context)
        {
            _context = context;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Room/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // POST: api/Room
        [HttpPost]
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            // Return the created room with a 201 response
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
        }

        // PUT: api/Room/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room updatedRoom)
        {
            if (id != updatedRoom.Id)
            {
                return BadRequest("Room ID in the request does not match the provided room.");
            }

            var existingRoom = await _context.Rooms.FindAsync(id);

            if (existingRoom == null)
            {
                return NotFound();
            }

            // Update the fields of the existing room
            existingRoom.Floor = updatedRoom.Floor;
            existingRoom.RoomType = updatedRoom.RoomType;
            existingRoom.IsAc = updatedRoom.IsAc;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Rooms.Any(r => r.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Room/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
