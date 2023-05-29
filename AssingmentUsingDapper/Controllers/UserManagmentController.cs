using AssingmentUsingDapper.Models;
using AssingmentUsingDapper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace AssingmentUsingDapper.Controllers
{
    public class UserManagmentController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly IUserManagment _userManagment;

        public UserManagmentController(IConfiguration configuration, IUserManagment userManagment)
        {
            _configuration = configuration;
            _userManagment = userManagment;
        }

       /* [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model, IFormCollection form)
        {
            string Name = form["Login".ToString()];
            RegistrationVM vm = new RegistrationVM();
            string result = "";
            if (model.Username != null)
            {
                result = _userManagment.Login(model);
                if (Name == "User")
                {
                    return RedirectToAction("PatientList", "User", new { area = "User" });
                }
                else if (Name == "Admin")
                {
                    {
                        return RedirectToAction("PatientList", "Admin", new { area = "Admin" });
                    }
                }
            }

            return View();
        }*/



        public IActionResult Index()
        {
            RegistrationVM vm = new RegistrationVM();
            vm.List = _userManagment.GetUserManagments().ToList();

            return View(vm);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(RegistrationModel model)
        {
            string result = _userManagment.CreateUser(model);
            if (result != null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           // RegistrationVM vm = new RegistrationVM();
            RegistrationModel model = _userManagment.GetUserManagementById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(RegistrationModel res)
        {
            if (ModelState.IsValid)
            {
                // PatientRegistration model = new PatientRegistration();
                _userManagment.UpdateUserManagment(res);

                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            string Delete = _userManagment.DeleteUserManagment(id);
            if (Delete != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }






    }
}
