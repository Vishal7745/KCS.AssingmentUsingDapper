using AssingmentUsingDapper.Areas.User.Models.Medicine;
using System.Data;
using System.Data.SqlClient;


namespace AssingmentUsingDapper.Areas.User.MedicineServices
{
    public class MedicineServicesUser : IMedicineServicesUser
    {
        private readonly IConfiguration _configuration;

        public MedicineServicesUser(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public string ConnectionString { get; }

        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

       
        public void Create(MedicineUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MedicineUser entity)
        {
            throw new NotImplementedException();
        }

        public MedicineUser FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicineUser> GeAllMedicine()
        {
            throw new NotImplementedException();
        }

        public void Update(MedicineUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
