using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;
using KamathResidency.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KamathResidency.Repos.Implementations;

public class UserRepo : IUserRepo
{
    private readonly HotelDbContext _context;
    public UserRepo(HotelDbContext context)
    {
        _context = context;
    }
    public async Task<List<UserDto>> GetAllUsers()
    {
        var users = await _context.Users
            .Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Address = u.Address,
                PhoneNumber = u.PhoneNumber,
                IdProof = u.IdProof
            })
            .ToListAsync();

        return users;
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber,
            IdProof = user.IdProof
        };

        return userDto;
    }

    // 3. Create a new user
    public async Task<User> CreateUser(UserDto userDto)
    {

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
            Address = userDto.Address,
            PhoneNumber = userDto.PhoneNumber,
            IdProof = userDto.IdProof
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }


    public async Task UpdateUser(Guid id, UserDto userDto)
    {

        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.Address = userDto.Address;
        user.PhoneNumber = userDto.PhoneNumber;
        user.IdProof = userDto.IdProof;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
