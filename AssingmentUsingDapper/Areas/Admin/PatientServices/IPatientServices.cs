using AssingmentUsingDapper.Areas.Admin.Models;

namespace AssingmentUsingDapper.Areas.Admin.PatientServices
{
    public interface IPatientServices
    {
        public List<PatientRegistration> ListofPatients();

        public PatientRegistration PatientById(int id);

        public string CreatePatient(PatientRegistration model);

        public string UpdatePatient(PatientRegistration model);

        public string DeletePatient(int id);
    }
}
