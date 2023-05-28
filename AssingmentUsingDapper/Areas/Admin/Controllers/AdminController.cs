using AssingmentUsingDapper.Areas.Admin.MedicineServices;
using AssingmentUsingDapper.Areas.Admin.Models;
using AssingmentUsingDapper.Areas.Admin.Models.Medicine;
using AssingmentUsingDapper.Areas.Admin.PatientServices;
using AssingmentUsingDapper.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AssingmentUsingDapper.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IPatientServices _patientServices;

        private readonly IMedicineServices _medicineServices;

        public AdminController(IConfiguration configuration, IPatientServices patientServices, IMedicineServices medicineServices)
        {
            _configuration = configuration;
            _patientServices = patientServices;
            _medicineServices=medicineServices;

        }
       

        public IActionResult PatientList()
        {
            PatientVM vm = new PatientVM();
            vm.List =_patientServices.ListofPatients().ToList();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //  PatientRegistration model1 = new PatientRegistration();
            PatientRegistration res = _patientServices.PatientById(id);
            return View(res);

        }

        [HttpPost]
        public IActionResult Edit(PatientRegistration res)
        {
            if (ModelState.IsValid)
            {
               // PatientRegistration model = new PatientRegistration();
                _patientServices.UpdatePatient(res);

                return RedirectToAction("PatientList");

            }

            return View();
        }


        [HttpGet]
        public IActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientRegistration model)
        {
            string create = _patientServices.CreatePatient(model);
            if (create != null)
            {
                return RedirectToAction("PatientList", "Admin");
            }
            return View();
        }
        //[Route("Vishal")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            PatientRegistration model;
            model = _patientServices.PatientById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(PatientRegistration model)
        {
            string Delete = _patientServices.DeletePatient(model.Id);
            if (Delete != null)
            {
                return RedirectToAction("PatientList", "Admin", new { Area = "Admin" });
            }
            return View();
        }
   

        public IActionResult AddMedicine()
        {
            return View();
        }
    }
}
