using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using KamathResidency.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Repos.Implementations;

public class RoomRepo : IRoomRepo
{
    private readonly HotelDbContext _context;
    public RoomRepo(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<RoomDto>> GetAllRooms()
    {
        return await _context.Rooms.Select(x => new RoomDto()
        {
            Id = x.Id,
            Floor = x.Floor,
            RoomType = x.RoomType,
            IsAc = x.IsAc,
            BasePrice = x.BasePrice,
            CreatedAt = x.CreatedAt
        }).ToListAsync();
    }

    public async Task<RoomDto> GetRoomById(long id)
    {
        return await _context.Rooms
        .Select(x => new RoomDto()
        {
            Id = x.Id,
            Floor = x.Floor,
            RoomType = x.RoomType,
            IsAc = x.IsAc,
            BasePrice = x.BasePrice,
            CreatedAt = x.CreatedAt
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Room> CreateRoom(RoomDto roomDto)
    {
        var room = new Room
        {
            Floor = roomDto.Floor,
            RoomType = roomDto.RoomType,
            IsAc = roomDto.IsAc,
            BasePrice = roomDto.BasePrice,
            CreatedAt = DateTime.UtcNow
        };

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task UpdateRoom(long id, RoomDto roomDto)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            throw new Exception("Room not found");
        }

        room.Floor = roomDto.Floor;
        room.RoomType = roomDto.RoomType;
        room.IsAc = roomDto.IsAc;
        room.BasePrice = roomDto.BasePrice;

        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoom(long id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            throw new Exception("Room not found");
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

    }

}
