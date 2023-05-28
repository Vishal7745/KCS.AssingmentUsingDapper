

using AssingmentUsingDapper.Models.PatientDetails;

namespace AssingmentUsingDapper.Areas.Admin.PriscriptionServices
{
    public interface IPatientDetailsService
    {
        PatientDetails model(int id);
    }
}
