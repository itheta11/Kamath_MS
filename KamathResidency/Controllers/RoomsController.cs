using KamathResidency.DTO;
using KamathResidency.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KamathResidency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepo _roomRepo;
        public RoomsController(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoomDto>>> GetAllRooms()
        {
            var rooms = await _roomRepo.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoomById(long id)
        {
            var room = await _roomRepo.GetRoomById(id);
            if (room == null)
            {
                return NotFound("Room not found");
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDto roomDto)
        {
            var newRoom = await _roomRepo.CreateRoom(roomDto);
            return CreatedAtAction(nameof(GetRoomById), new { id = newRoom.Id }, newRoom);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(long id, [FromBody] RoomDto roomDto)
        {
            await _roomRepo.UpdateRoom(id, roomDto);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            await _roomRepo.DeleteRoom(id);
            return NoContent();
        }
    }
}
