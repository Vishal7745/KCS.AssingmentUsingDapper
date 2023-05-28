using AssingmentUsingDapper.Models;

namespace AssingmentUsingDapper.Services
{
    public interface IUserManagment
    {
       public List<RegistrationModel> GetUserManagments();

        public string UpdateUserManagment(RegistrationModel model);

        public string DeleteUserManagment(int Id);

        public string Login(LoginModel model);

        public string CreateUser(RegistrationModel model);

        RegistrationModel GetUserManagementById(int id);

       // RegistrationModel registration();

    }
}
