using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;

namespace KamathResidency.Repos.Interfaces;

public interface IRoomRepo
{
    public Task<List<RoomDto>> GetAllRooms();
    public Task<RoomDto> GetRoomById(long id);
    public Task<Room> CreateRoom(RoomDto roomDto);
    public Task UpdateRoom(long id, RoomDto roomDto);
    public Task DeleteRoom(long id);
}
