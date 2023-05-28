namespace AssingmentUsingDapper.Models.PatientDetails
{
    public class PatientDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string MedicalCondition { get; set; }
        public string Followup { get; set; }

    }
}
