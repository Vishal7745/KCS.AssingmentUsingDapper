using AssingmentUsingDapper.Areas.Admin.Models;
using AssingmentUsingDapper.Areas.User.MedicineServices;
using AssingmentUsingDapper.Areas.User.Models;
using AssingmentUsingDapper.Areas.User.PatientServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace AssingmentUsingDapper.Areas.User.Controllers
{
    public class UserController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IPatientServicesUser _patientServicesuser;

        private readonly IMedicineServicesUser _medicineServicesuser;

        public UserController(IConfiguration configuration, IPatientServicesUser patientServicesuser, IMedicineServicesUser medicineServicesuser)
        {
            _configuration = configuration;
            _patientServicesuser = patientServicesuser;
            _medicineServicesuser = medicineServicesuser;

        }


        public IActionResult PatientList()
        {
            PatientVMUser VM = new PatientVMUser();
            VM.List = _patientServicesuser.ListofPatients().ToList();
            return View(VM);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            PatientRegistrationUser res = _patientServicesuser.PatientById(id);
            return View(res);

        }

        [HttpPost]
        public IActionResult Update(PatientRegistrationUser res)
        {
            
            if (ModelState.IsValid)
            {
                string result = _patientServicesuser.UpdatePatient(res);
                if (result!=null)
                {
                    return RedirectToAction("PatientList");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePatient2(PatientRegistrationUser model)
        {
            string create = _patientServicesuser.CreatePatient(model);
            if (create != null)
            {
                return RedirectToAction("PatientList", "User");
            }
            return View();
        }
    }
    
}
