using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AssingmentUsingDapper.Areas.Admin.Models
{
    public class PatientRegistration
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string MedicalCondition { get; set; }

        [Required]
        public string Followup { get; set; }

    }
}
