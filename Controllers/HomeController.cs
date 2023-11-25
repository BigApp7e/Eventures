using Eventures.Data;
using Eventures.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Eventures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly DatabaseContext ctx;

        public HomeController(ILogger<HomeController> _logger, DatabaseContext _ctx)
        {
            logger = _logger;
            ctx = _ctx;

            logger.Log(LogLevel.Information, "Some Message");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLoginPage()
        {
            return View();
        }

        public async Task<IActionResult> GetEventsPage()
        {
            var events = await ctx.events.ToListAsync();
            if (events == null) { return NotFound(); }
            return View(events);
        }
        public IActionResult LogOut()
        {
            AppModel.isLogin = false;
            AppModel.UserName = "";
            AppModel.type = "";
            return new RedirectResult("/Home/GetLoginPage", false);
        }
        public IActionResult GetCreateEventPage()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

       [HttpGet("details")]
        public IActionResult TryToLogin(UserLogin user)
        {
            if (!ModelState.IsValid)
            {          
                TempData["msg"] = "Fill all form fields correctly!!!";
                return new RedirectResult("/Home/GetLoginPage", false);
            }
            TempData["msg"] = null;

            var result = ctx.users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();

            if (result == null)
            {
                TempData["msg"] = "Wrong user name or/and password !";
                return new RedirectResult("/Home/GetLoginPage", false);
            }

            AppModel.isLogin = true;
            AppModel.UserName = result.UserName;
            AppModel.type = result.type;


            return new RedirectResult("/Home/Index", false);
        }
       


        [HttpPost]
        public IActionResult CreatenewEvent(EventModel eventData)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Fill all form fields correctly!!!";
                return new RedirectResult("/Home/GetCreateEventPage", false);
            }
            TempData["msg"] = null;

            try
            {
                ctx.Add(new EventModel(eventData.Id, eventData.Name, eventData.Place, eventData.StartDate, eventData.EndDate, eventData.TotalTickets, eventData.PricePerTicket));
                ctx.SaveChanges();

                string message = DateTime.Now.ToString() + " Administrator create event " + eventData.Name;

                logger.Log(LogLevel.Information, message);

            }
            catch (Exception)
            {
                throw;
            }
            return new RedirectResult("/Home/GetEventsPage", false);
        }

        [HttpPost]
        public IActionResult RegisterNewUser(UserModelDto userData)
        {
            if (!ModelState.IsValid || !userData.Password.Equals(userData.ConfirmPassword))
            {
                TempData["msg"] = "Fill all form fields correctly!!!";
                return new RedirectResult("/Home/GetRegisterPage", false);
            }
            TempData["msg"] = null;

            try
            {
                ctx.Add(new UserModel(userData.UserName, userData.Password, userData.Email, userData.FirstName, userData.LastName, userData.UniqueCitizenNumber, "Guest"));
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return new RedirectResult("/Home/GetLoginPage", false);


        }
        public IActionResult GetRegisterPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}