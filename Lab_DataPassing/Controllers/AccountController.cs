using Lab_DataPassing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab_DataPassing.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(LoginViewModel model)
        {
            if(model.Email=="admin@gmail.com" && model.Password == "admin@123")
            {
                TempData["Message"] = "Welcome Back!";
                string strUser = JsonSerializer.Serialize(model);
                HttpContext.Session.SetString("User", strUser);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Username or Password doesnt exists!";
            }
            

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
    
}
