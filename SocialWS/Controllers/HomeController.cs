using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using AutoMapper;
using SocialWS.EF.DataLayer.Repositorys;
using SocialWS.EF.DataLayer.Services;
using SocialWS.EF.DomainEntities;
using SocialWS.EF.UserData;
using SocialWS.Models;
using SocialWS.ViewModel;
using UserRegistration = SocialWS.EF.UserData.UserRegistration;

namespace SocialWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {                     
            return View();
        }

        public ActionResult NewUserRegistration()
        {
            var viewModel = new UserRegistrationViewModel(); 

            return View(viewModel);
        }

        public ActionResult UserLogin()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        public ObjectCache Cache = MemoryCache.Default;

        public ActionResult UserLoginRequest(LoginViewModel viewModel)
        {
            var user = userService.UserLoginRequest(viewModel.Username, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("IncorrectUserPassword", "Username or password incorrect");
                return View("UserLogin");
            }
            
            Cache.Add("UserAccount", user, new CacheItemPolicy());

            return RedirectToAction("HomePage");
        }

        public ActionResult HomePage()
        {
            var user = (User)Cache.Get("UserAccount");

            if (user == null)
            {
                return RedirectToAction("UserLogin");
            }

            var viewModel = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.UserId,
                    Username = user.UserName
                };

            return View(viewModel);
        }

        public ActionResult RegisterNewUser(UserRegistrationViewModel viewModel)
        {
            if (userService.CheckUsernameExists(viewModel.UserName))
            {
                ModelState.AddModelError("UsernameExists", "Username exists");
            }

            if (!ModelState.IsValid )
            {
                return View("NewUserRegistration");
            }
            

            if (userService.VerifyNewUser(Guid.Parse(viewModel.RegistrationKey)))
            {
                var user = new UserRegistration
                {
                    EmailAddress = viewModel.EmailAddress,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Password = viewModel.Password,
                    UserName = viewModel.UserName
                };
                userService.RegisterNewUser(user);
                   
                return View("UserLogin");
            }                    
            return new EmptyResult();
        }

        public ActionResult LogoutUser()
        {
            Cache.Remove("UserAccount");
            return RedirectToAction("HomePage");
        }
    }
}
