using LEARNET.Common.DTOs;
using LEARNET.Common.Model;

namespace LEARNET.Services.Abstraction
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(string guid);

        Task<List<User>> AddUser(User newUser);

        Task<User> UpdateUser(string guid, User updatedUser);

        Task<List<User>> DeleteUser(string guid);
        Task<List<User>> GetPagedUsers(
    int pageNumber,
    int pageSize);

        Task BulkInsertUsers(
    List<BulkUserRequest> requests);
        Task<User?> GetUserByUsername(
    string username);
    }
}