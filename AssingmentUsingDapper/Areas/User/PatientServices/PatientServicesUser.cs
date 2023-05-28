using AssingmentUsingDapper.Areas.User.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AssingmentUsingDapper.Areas.User.PatientServices
{
    public class PatientServicesUser : IPatientServicesUser
    {
        private readonly IConfiguration _configuration;

        public PatientServicesUser(IConfiguration configuration)
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

        public List<PatientRegistrationUser> ListofPatients()
        {
            List<PatientRegistrationUser> patientModels = new List<PatientRegistrationUser>();
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    patientModels = dbConnection.Query<PatientRegistrationUser>("Usp_ListOfPatient", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return patientModels;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return patientModels;
            }
        }

        public string CreatePatient(PatientRegistrationUser model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var output = conn.Query<PatientRegistrationUser>("Usp_InsertPatientRegistration",
                         new
                         {

                             FirstName = model.FirstName,
                             LastName = model.LastName,
                             PhoneNumber = model.PhoneNumber,
                             Email = model.Email,
                             Address = model.Address,
                             MedicalCondition = model.MedicalCondition,
                             Followup = model.Followup
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

        public string UpdatePatient(PatientRegistrationUser model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var Update = dbConnection.Query<PatientRegistrationUser>("Usp_UpdatePatient", new
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        Address = model.Address,
                        MedicalCondition = model.MedicalCondition,
                        Followup = model.Followup
                    }, commandType: CommandType.StoredProcedure);
                    if (Update!=null)
                    {
                        result = "Update Successfully";
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

        public PatientRegistrationUser PatientById(int id)
        {
            PatientRegistrationUser registration = new PatientRegistrationUser();

            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    registration = dbConnection.QueryFirstOrDefault<PatientRegistrationUser>("Usp_PatientById", new
                    {
                        id = id
                    }, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return registration;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return registration;
            }
            return registration;

        }

      
    }
}
