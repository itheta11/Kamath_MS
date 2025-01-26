using System;
using KamathResidency.DTO;
using KamathResidency.Infrastructure;

namespace KamathResidency.Repos.Interfaces;

public interface IUserRepo
{
    public Task<List<UserDto>> GetAllUsers();
    public Task<UserDto> GetUserById(Guid id);

    public Task<User> CreateUser(UserDto userDto);
    public Task UpdateUser(Guid id, UserDto userDto);
    public Task DeleteUser(Guid id);


}
