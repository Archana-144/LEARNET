using LEARNET.Common.Model;
using LEARNET.Store.Abstraction;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using LEARNET.Common.Constants;
using System.Data;
using Microsoft.Data.SqlClient;
using LEARNET.Common.DTOs;
namespace LEARNET.Store.Implementation
{
    public class UserStore : IUserStore
    {
        // Connection string variable
        private readonly string _connectionString;


        /// <summary>
        /// Constructor Injection for IConfiguration
        /// </summary>
        /// <param name="configuration"></param>
        public UserStore(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Method to fetch all users from database
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(_connectionString))
                {
                    SqlCommand command =
      new SqlCommand(
          SqlConstants.GetAllUsers,
          connection);

                    command.CommandType =
                        System.Data.CommandType.StoredProcedure;

                    await connection.OpenAsync();

                    SqlDataReader reader =
                        await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        User user = new User();

                        user.Id =
                            Convert.ToInt32(reader["member_id"]);

                        user.MemberGuid =
                            reader["member_guid"].ToString();

                        user.Name =
                            reader["member_name"].ToString();

                        user.Email =
                            reader["email"].ToString();

                        user.Phone =
                            reader["phone"].ToString();

                        user.MembershipType =
                            reader["membership_type"].ToString();

                        

                            if (reader["created_on"] != DBNull.Value)
                        {
                            user.CreatedOn =
                                Convert.ToDateTime(reader["created_on"]);
                        }

                        
                           if (reader["created_by"] != DBNull.Value)
                        {
                            user.CreatedBy =
                                reader["created_by"].ToString();
                        }

                        
                           if (reader["updated_on"] != DBNull.Value)
                        {
                            user.UpdatedOn =
                                Convert.ToDateTime(reader["updated_on"]);
                        }
                        if (reader["updated_by"] != DBNull.Value)
                        {
                            user.UpdatedBy =
                                reader["updated_by"].ToString();
                        }

                        if (reader["is_active"] != DBNull.Value)
                        {
                            user.IsActive =
                                Convert.ToBoolean(reader["is_active"]);
                        }

                        users.Add(user);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return users;
        }



        public async Task<User> GetUserById(string guid)
        {
            User user = null;

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(_connectionString))
                {
                    SqlCommand command =
                            new SqlCommand(
                              SqlConstants.GetUserById, connection);


                    command.CommandType =
                        CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                        "@Guid",
                        guid);

                    await connection.OpenAsync();

                    SqlDataReader reader =
                        await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        user = new User();

                        user.Id =
                            Convert.ToInt32(reader["member_id"]);

                        user.MemberGuid =
                            reader["member_guid"].ToString();

                        user.Name =
                            reader["member_name"].ToString();

                        user.Email =
                            reader["email"].ToString();

                        user.Phone =
                            reader["phone"].ToString();

                        user.MembershipType =
                            reader["membership_type"].ToString();

                        user.CreatedOn =
                            Convert.ToDateTime(reader["created_on"]);

                        user.CreatedBy =
                            reader["created_by"].ToString();

                        user.UpdatedOn =
                            Convert.ToDateTime(reader["updated_on"]);

                        user.UpdatedBy =
                            reader["updated_by"].ToString();

                        user.IsActive =
                            Convert.ToBoolean(reader["is_active"]);
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
        /// <summary>
        /// Method to add new user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<List<User>> AddUser(
    User newUser)
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection connection =
                    new SqlConnection(_connectionString))
                {
                    SqlCommand command =
                                 new SqlCommand(SqlConstants.InsertUser, connection);
                    command.CommandType =
                        CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                        "@Name",
                        newUser.Name);

                    command.Parameters.AddWithValue(
                        "@Email",
                        newUser.Email);

                    command.Parameters.AddWithValue(
                        "@Phone",
                        newUser.Phone);

                    command.Parameters.AddWithValue(
                        "@MembershipType",
                        newUser.MembershipType);

                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();
                }

                return await GetAllUsers();
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        public async Task<User> UpdateUser(
     string guid,
     User updatedUser)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(_connectionString))
                {
                    SqlCommand command =
                              new SqlCommand(SqlConstants.UpdateUser, connection);




                    command.CommandType =
                        CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                             "@Guid",
                                   guid);

                    command.Parameters.AddWithValue(
                        "@Name",
                        updatedUser.Name);

                    command.Parameters.AddWithValue(
                        "@Email",
                        updatedUser.Email);

                    command.Parameters.AddWithValue(
                        "@Phone",
                        updatedUser.Phone);

                    command.Parameters.AddWithValue(
                        "@MembershipType",
                        updatedUser.MembershipType);

                    command.Parameters.AddWithValue(
                        "@IsActive",
                        updatedUser.IsActive);

                    command.Parameters.AddWithValue(
                        "@Username",
                        updatedUser.Username);

                    command.Parameters.AddWithValue(
                        "@PasswordHash",
                        updatedUser.PasswordHash);

                    command.Parameters.AddWithValue(
                        "@RoleName",
                        updatedUser.RoleName);
                    command.Parameters.AddWithValue(
                          "@IsActive",
                      updatedUser.IsActive);
                    await connection.OpenAsync();

                    int rowsAffected =
                        await command.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return await GetUserById(guid);
                    }

                    return null;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Method to delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<List<User>> DeleteUser(
     string guid)
        {
            try
            {
                using (SqlConnection connection =
                    new SqlConnection(_connectionString))
                {
                    SqlCommand command =
                       new SqlCommand(SqlConstants.DeleteUser, connection);



                    command.CommandType =
                        CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                        "@Guid",
                        guid);

                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();
                }

                return await GetAllUsers();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves paginated active users from the database.
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
            List<User> users = new();

            using SqlConnection connection =
                new SqlConnection(_connectionString);

            using SqlCommand command =
     new SqlCommand(
         "usp_GetPagedUsers",
         connection);

            command.CommandType =
                CommandType.StoredProcedure;
            command.Parameters.AddWithValue(
    "@PageNumber",
    pageNumber);

            command.Parameters.AddWithValue(
                "@PageSize",
                pageSize);

           

            await connection.OpenAsync();

            SqlDataReader reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                users.Add(new User
                {
                    Guid =
                        reader["member_guid"].ToString(),

                    Name =
                        reader["member_name"].ToString(),

                    Email =
                        reader["email"].ToString(),

                    Phone =
                        reader["phone"].ToString(),

                    MembershipType =
                        reader["membership_type"].ToString(),


                    IsActive =
                        Convert.ToBoolean(
                            reader["is_active"]),



                });
            }

            return users;
        }
        /// <summary>
        /// Inserts multiple users using UDT and stored procedure.
        /// </summary>
        /// <param name="requests">
        /// List of users to insert.
        /// </param>
        public async Task BulkInsertUsers(
            List<BulkUserRequest> requests)
        {
            DataTable table = new();

            table.Columns.Add("member_name");
            table.Columns.Add("email");
            table.Columns.Add("phone");
            table.Columns.Add("membership_type");
            table.Columns.Add("created_by");



            foreach (var request in requests)
            {
                table.Rows.Add(
                    request.Name,
                    request.Email,
                    request.Phone,
                    request.MembershipType,
                    "admin");
            }



            using SqlConnection connection =
                new SqlConnection(_connectionString);

            using SqlCommand command =
                new SqlCommand(
                    "usp_BulkInsertMembers",
                    connection);

            command.CommandType =
                CommandType.StoredProcedure;



            SqlParameter parameter =
                command.Parameters.AddWithValue(
                    "@Members",
                    table);

            parameter.SqlDbType =
                SqlDbType.Structured;

            parameter.TypeName =
                "MemberTableType";



            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
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
            using SqlConnection connection =
                new SqlConnection(
                    _connectionString);



            using SqlCommand command =
                new SqlCommand(
                    "usp_GetUserByUsername",
                    connection);



            command.CommandType =
                CommandType.StoredProcedure;



            command.Parameters.AddWithValue(
                "@Username",
                username);



            await connection.OpenAsync();



            using SqlDataReader reader =
                await command.ExecuteReaderAsync();



            if (await reader.ReadAsync())
            {
                return new User
                {
                    Guid =
                        reader["member_guid"].ToString(),

                    Name =
                        reader["member_name"].ToString(),

                    Email =
                        reader["email"].ToString(),

                    Phone =
                        reader["phone"].ToString(),

                    MembershipType =
                        reader["membership_type"].ToString(),

                    Username =
                        reader["username"].ToString(),

                    PasswordHash =
                        reader["password_hash"].ToString(),

                    RoleName =
                        reader["role_name"].ToString(),

                    IsActive =
                        Convert.ToBoolean(
                            reader["is_active"])
                };
            }




            return null;
        }
    }
}