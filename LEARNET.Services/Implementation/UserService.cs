using LEARNET.Common.DTOs;
using LEARNET.Common.Model;
using LEARNET.Services.Abstraction;
using LEARNET.Store.Abstraction;

namespace LEARNET.Services.Implementation
{
    public class UserService : IUserService
    {
        // Dependency Injection for Store layer
        private readonly IUserStore _userStore;



        /// <summary>
        /// Constructor Injection for IUserStore
        /// </summary>
        /// <param name="userStore"></param>
        public UserService(
            IUserStore userStore)
        {
            _userStore = userStore;
        }



        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>
        /// Returns list of users.
        /// </returns>
        public async Task<List<User>> GetAllUsers()
        {
            return await _userStore
                .GetAllUsers();
        }



        /// <summary>
        /// Retrieves user by Guid.
        /// </summary>
        /// <param name="guid">
        /// User Guid.
        /// </param>
        /// <returns>
        /// Returns user.
        /// </returns>
        public async Task<User?> GetUserById(
            string guid)
        {
            return await _userStore
                .GetUserById(guid);
        }



        /// <summary>
        /// Method to add new user.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<List<User>> AddUser(
            User newUser)
        {
            return await _userStore
                .AddUser(newUser);
        }



        /// <summary>
        /// Method to update user details.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        public async Task<User> UpdateUser(
            string guid,
            User updatedUser)
        {
            return await _userStore
                .UpdateUser(
                    guid,
                    updatedUser);
        }



        /// <summary>
        /// Method to delete user by Guid.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<List<User>> DeleteUser(
            string guid)
        {
            return await _userStore
                .DeleteUser(guid);
        }



        /// <summary>
        /// Retrieves paginated users.
        /// </summary>
        /// <param name="pageNumber">
        /// Current page number.
        /// </param>
        /// <param name="pageSize">
        /// Number of records per page.
        /// </param>
        /// <returns>
        /// Returns paginated list of users.
        /// </returns>
        public async Task<List<User>> GetPagedUsers(
            int pageNumber,
            int pageSize)
        {
            return await _userStore
                .GetPagedUsers(
                    pageNumber,
                    pageSize);
        }



        /// <summary>
        /// Inserts multiple users.
        /// </summary>
        /// <param name="requests">
        /// List of users to insert.
        /// </param>
        public async Task BulkInsertUsers(
            List<BulkUserRequest> requests)
        {
            await _userStore
                .BulkInsertUsers(
                    requests);
        }



        /// <summary>
        /// Retrieves user by username.
        /// </summary>
        /// <param name="username">
        /// Username.
        /// </param>
        /// <returns>
        /// Returns user.
        /// </returns>
        public async Task<User?> GetUserByUsername(
            string username)
        {
            return await _userStore
                .GetUserByUsername(
                    username);
        }
    }
}