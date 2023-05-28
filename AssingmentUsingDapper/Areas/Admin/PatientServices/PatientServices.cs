using AssingmentUsingDapper.Areas.Admin.Models;
using AssingmentUsingDapper.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AssingmentUsingDapper.Areas.Admin.PatientServices
{
    public class PatientServices : IPatientServices
    {
        private readonly IConfiguration _configuration;

        public PatientServices(IConfiguration configuration)
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

        public List<PatientRegistration> ListofPatients()
        {
            List<PatientRegistration> patientModels = new List<PatientRegistration>();
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    patientModels = dbConnection.Query<PatientRegistration>("Usp_ListOfPatient", commandType: CommandType.StoredProcedure).ToList();
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

        public string CreatePatient(PatientRegistration model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var output = conn.Query<PatientRegistration>("Usp_InsertPatientRegistration",
                         new
                         {
                          
                             FirstName = model.FirstName,
                             LastName = model.LastName,
                             PhoneNumber = model.PhoneNumber,
                             Email = model.Email,
                             Address = model.Address,
                             MedicalCondition = model.MedicalCondition,
                             Followup=model.Followup
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

        public string DeletePatient(int id)
        {
            string result = "";
            try
            {
                using( IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var Delete = dbConnection.Query<PatientRegistration>("Usp_DeletePatientRegistration", new
                    {
                        Id = id
                    },commandType:CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }


            return result;
        }

        public string UpdatePatient(PatientRegistration model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var Update = dbConnection.Query<PatientRegistration>("Usp_UpdatePatient", new
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
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return msg;
            }


            return result;

        }

        public PatientRegistration PatientById(int id)
        {
            PatientRegistration registration= new PatientRegistration();

            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    registration = dbConnection.QueryFirstOrDefault<PatientRegistration>("Usp_PatientById", new
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
