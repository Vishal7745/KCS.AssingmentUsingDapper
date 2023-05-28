
using AssingmentUsingDapper.Models;
using AssingmentUsingDapper.Models.PatientDetails;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AssingmentUsingDapper.Areas.Admin.PriscriptionServices
{
    public class PatientDetailsService : IPatientDetailsService
    {
        private readonly IConfiguration _configuration;
        public string ConnectionSting { get; }
        public PatientDetailsService(IConfiguration Configuration)
        {
            _configuration = Configuration;
            ConnectionSting = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection dbConnection
        {
            get
            {
                return new SqlConnection(ConnectionSting);
            }   
        }

        public PatientDetails model(int id)
        {
           PatientDetails model = new PatientDetails();
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    model = dbConnection.QueryFirstOrDefault<PatientDetails>("Usp_Details",
                        new { id = id }, commandType: CommandType.StoredProcedure);
                    dbConnection.Close();
                    return model;


                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return model;
            }
         
        }
    }
}
