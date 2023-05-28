using AssingmentUsingDapper.Areas.Admin.MedicineServices;
using AssingmentUsingDapper.Areas.Admin.Models.Medicine;

using AssingmentUsingDapper.Areas.Admin.PatientServices;
using AssingmentUsingDapper.Areas.Admin.PriscriptionServices;
using AssingmentUsingDapper.Models.PatientDetails;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace AssingmentUsingDapper.Areas.Admin.Controllers
{
    public class PriscriptionController : BaseController
    {
        private readonly IConfiguration _configuration;

        private readonly IPatientDetailsService _patientDetailsServices;

        public PriscriptionController(IConfiguration configuration, IPatientDetailsService patientDetailsServices)
        {
            _configuration = configuration;
            _patientDetailsServices = patientDetailsServices;
        }

        public IActionResult Index(int id)
        {
            PatientDetails patientDetails = new PatientDetails();
            patientDetails = _patientDetailsServices.model(id);
            return View(patientDetails);
        }
       /* public IActionResult GeneratePDFReport()
        {
            *//*var options = new ViewAsPdfOptions
            {
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
             
            };*//*
           
            return new ViewAsPdf("PDFReport")
            {
                FileName = "Report.pdf"
            };
        }*/


    }
}
