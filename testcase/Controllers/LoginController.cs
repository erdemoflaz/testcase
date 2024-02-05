using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

    public class LoginController : Controller
    {
        private readonly AppDbContext _dbContext;

        public LoginController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLogin(User formData)
        {
            try
            {
                var username = formData.username;
                var password = formData.password;

                var exists = _dbContext.Users.FirstOrDefault(y => y.username == username && y.password == password);

                if (exists != null)
                {
                    SetAdminCookie(exists);
                    SetUserData(exists);
                    return Redirect("/Home/Index");
                }
                else
                {
                    SaveNewUser(username, password);
                    TempData["ErrorMessage"] = "User not found but created now.";
                    return Redirect("/Login/Index");
                }
                    
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Login"); // Login/Index action'ýna yönlendir
            }
            
        }

    private void SetAdminCookie(User user)
    {
		if (user.is_admin.ToString() != null)
		{
			Response.Cookies.Append("isAdmin", user.is_admin.ToString());
		}
		else
		{
			Response.Cookies.Append("isAdmin", "false");
		}

		Response.Cookies.Append("isAdmin", user.is_admin.ToString() == "True" ? user.is_admin.ToString() : "403");
	}

    private void SetUserData(User user)
    {
        Response.Cookies.Append("userId", user.id.ToString());
    }

    private void SaveNewUser(string username, string password)
    {
		User newUser = new User
		{
			username = username,
			password = password
		};

        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();
	}

}