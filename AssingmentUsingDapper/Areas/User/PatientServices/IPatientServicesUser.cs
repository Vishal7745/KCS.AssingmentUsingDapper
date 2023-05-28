using AssingmentUsingDapper.Areas.User.Models;

namespace AssingmentUsingDapper.Areas.User.PatientServices
{
    public interface IPatientServicesUser
    {
        public List<PatientRegistrationUser> ListofPatients();

        public PatientRegistrationUser PatientById(int id);

        public string CreatePatient(PatientRegistrationUser model);

        public string UpdatePatient(PatientRegistrationUser model);

    }
}
