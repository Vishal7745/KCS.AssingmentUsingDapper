using AssingmentUsingDapper.Areas.Admin.Models;
using AssingmentUsingDapper.Areas.Admin.Models.Medicine;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AssingmentUsingDapper.Areas.Admin.MedicineServices
{
    public class MedicineServices : IMedicineServices
    {
        private readonly IConfiguration _configuration;

        public MedicineServices(IConfiguration configuration)
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

        public string Create(Medicine entity)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var output = conn.Query<Medicine>("Usp_CreateMedicine",
                         new
                         {
                             Medicine_Name=entity.Medicine_Name,
                             Price=entity.Price,
                             Total_Stock=entity.Total_Stock
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

        public string Delete(int id)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var Delete = dbConnection.Query<PatientRegistration>("Usp_deleteMedicine", new
                    {
                        Id = id
                    }, commandType: CommandType.StoredProcedure);
                    if (Delete != null)
                    {
                        result = "Record delete Successful";
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

        public Medicine FindById(int id)
        {
            Medicine model = new Medicine();

            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    model = dbConnection.QueryFirst<Medicine>("Usp_MedicineById", new
                    {
                        id = id
                    }, commandType: CommandType.StoredProcedure);

                    dbConnection.Close();
                    return model;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return model;
            }
           // return registration;
        }

        public List<Medicine> GeAllMedicine()
        {
            List<Medicine> medicine = new List<Medicine>();
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    dbConnection.Open();
                    medicine = dbConnection.Query<Medicine>("Usp_ListOfMedicine", commandType: CommandType.StoredProcedure).ToList();
                    dbConnection.Close();
                    return medicine;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return medicine;
            }

        }

        public string Update(Medicine model)
        {
            string result = "";
            try
            {
                using (IDbConnection conn = dbConnection)
                {
                    conn.Open();
                    var Update = dbConnection.Query<Medicine>("Usp_UpdateMedicine", new
                    {
                        Id = model.Id,
                        Medicine_Name=model.Medicine_Name,
                        Price =model.Price,
                        Total_Stock= model.Total_Stock
                    }, commandType: CommandType.StoredProcedure);
                    if (Update != null)
                    {
                        result = "Record upddate Successful";
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


          //  return result;
        }
    }
}
