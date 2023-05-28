using AssingmentUsingDapper.Areas.Admin.MedicineServices;
using AssingmentUsingDapper.Areas.Admin.Models;
using AssingmentUsingDapper.Areas.Admin.Models.Medicine;
using AssingmentUsingDapper.Areas.Admin.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace AssingmentUsingDapper.Areas.Admin.Controllers
{
    public class MedicineController : BaseController
    {
        private readonly IConfiguration _configuration;
      //  private readonly IMedicineServices _Services;

        private readonly IMedicineServices _medicineServices;

        public MedicineController(IConfiguration configuration, IMedicineServices medicineServices)
        {
            _configuration = configuration;
           // _patientServices = patientServices;
            _medicineServices = medicineServices;

        }

        public IActionResult Index( IFormCollection form)
        {
            List<Medicine> list = new List<Medicine>();
            list = _medicineServices.GeAllMedicine().ToList();
            return View(list);
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //  PatientRegistration model1 = new PatientRegistration();
            Medicine res = _medicineServices.FindById(id);
            return View(res);

        }

        [HttpPost]
        public IActionResult Edit(Medicine res)
        {
            if (ModelState.IsValid)
            {
                // PatientRegistration model = new PatientRegistration();
                _medicineServices.Update(res);

                return RedirectToAction("Index" );

            }

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medicine model)
        {
            string create = _medicineServices.Create(model);
            if (create != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var Delete = _medicineServices.Delete(id);
            if (Delete != null)
            {
                return View("Index");
            }
            return View();
        }

    }
}
