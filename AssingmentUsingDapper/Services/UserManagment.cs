using AssingmentUsingDapper.Areas.Admin.Models;
using AssingmentUsingDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using static Dapper.SqlMapper;

namespace AssingmentUsingDapper.Services
{
    public class UserManagment : IUserManagment
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }

        public UserManagment(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public List<RegistrationModel> GetUserManagments()
        {
            List<RegistrationModel> models = new List<RegistrationModel>();
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    models = dbConnection.Query<RegistrationModel>("Usp_GetUserManagement", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return models;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return models;
            }
        }

        public string DeleteUserManagment(int id)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var Delete = dbConnection.Query<PatientRegistration>("Usp_DeleteUserManagement", new
                    {
                        Id = id
                    }, commandType: CommandType.StoredProcedure);
                }
                result = "Record Deleted Successful";
                return result;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }
        }


        public string UpdateUserManagment(RegistrationModel model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                     var Update= dbConnection.Query<RegistrationModel>("Usp_UpdateUserProfile", new
                    {
                        Id =model.Id,
                        FirstName=model.FirstName,
                        LastName = model.LastName,
                        EmailId =   model.EmailId,
                        Password = model.Password,
                        UserRole = model.UserRole, 
                        IsActive=model.IsActive
                    }, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    result = "Update Successfully";
                    return result;
                   
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return result;
            }
        }

        public string Login(LoginModel model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var output = conn.Query<LoginModel>("usp_GetLogin",
                        new
                        {
                            EmailId = model.Username,
                            Password = model.Password
                        }, commandType: CommandType.StoredProcedure);
                    if (output != null)
                    {
                        result = "Login Successful";
                    }
                    conn.Close();
                    return result;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }
        }

        public string CreateUser(RegistrationModel model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var output = conn.Query<RegistrationModel>("Usp_InsertUserManagement",
                         new
                         {
                             FirstName = model.FirstName,
                             LastName = model.LastName,
                             EmailId = model.EmailId,
                             Password = model.Password,
                             UserRole = model.UserRole,
                             IsActive = model.IsActive,
                         }, commandType: CommandType.StoredProcedure);
                    if (output != null)
                    {
                        result = "Record Inserted Successful";
                    }
                    conn.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return result;
            }
        }

        public RegistrationModel GetUserManagementById(int id)
        {
           RegistrationModel registration = new RegistrationModel();
           
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                   registration = dbConnection.QuerySingleOrDefault<RegistrationModel>("Usp_GetUserManagementById", new
                    {
                        Id = id
                    }, commandType: CommandType.StoredProcedure);
                }
             
                return registration;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return registration;
            }

        }
    }
}
