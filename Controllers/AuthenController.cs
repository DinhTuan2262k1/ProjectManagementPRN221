using Microsoft.AspNetCore.Mvc;
using ProjectManagementPRN221.Models;
using ProjectManagementPRN221.Repository;
using ProjectManagementPRN221.Extensions;
using System.Security.Principal;

namespace ProjectManagementPRN221.Controllers
{
    public class AuthenController : Controller
    {
        private AccountRepo _accountRepo;
        private StudentRepo _studentRepo;

        public AuthenController(AccountRepo accountRepo, StudentRepo studentRepo)
        {
            _accountRepo = accountRepo;
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Account account = _accountRepo.GetByEmailAndPass(email, password);
            if (account == null)
            {
                ViewBag.Error = "Wrong email or password";
            }
            else
            {
                HttpContext.Session.Set("account", account);
                if(account.RoleId == 2)
                {
                    Student student = _studentRepo.GetStudentByAccountId(account.AccountId);
                    HttpContext.Session.Set("student", student);
                }
                return RedirectToAction("index", "Projects");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authen");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string mssv, string email, string password)
        {
            var student = _studentRepo.Get(mssv);
            if (student!=null)
            {
                var newAccount = _accountRepo.create(new Account
                {
                    Email = email,
                    Password = password,
                    RoleId = 2,
                });

                student.AccountId = newAccount.AccountId;
                _studentRepo.edit(student);
            }
            else
            {
                ViewBag.Error = "Mssv doesn't exist";
            }
            return View();
        }
    }
}
