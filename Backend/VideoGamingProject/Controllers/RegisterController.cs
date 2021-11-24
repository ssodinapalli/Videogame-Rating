using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGamingModels;
using Repository;

namespace VideoGamingProject.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _IregisterService;
        public RegisterController(IRegisterService reg)
        {
            _IregisterService = reg;
        }

        [HttpPost, Route("api/Register/RegisterGames")]

        public bool RegisterGames(Register student)
        {
            if (_IregisterService.GameRegister(student))
            {
                return true;
            }
            return false;
        }
        [HttpGet, Route("api/Register/Login")]
        public bool Login(Login _login)
        {
            if (_IregisterService.GameLogin(_login))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        [HttpGet, Route("api/Register/ForgotPassword")]
        public string ForgotPassword(string GameName)
        {
            return _IregisterService.ForgotPassword(GameName);
        }
        [HttpGet, Route("api/Register/GetRegisteredallGames")]
        public List<string> GetRegisteredGames()
        {
            return _IregisterService.GetRegisteredallGames();
        }
        [HttpDelete, Route("api/Register/DeleteGame")]
        public bool DeleteGame(string GameName)
        {
            if (_IregisterService.DeleteGame(GameName))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        [HttpPatch, Route("api/Register/ResetPassword")]
        public bool ResettingPassword(ResetPasswordClass resetPassword)
        {
            if (_IregisterService.ResetPassword(resetPassword))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        [HttpPut, Route("api/Register/UpdateProfile")]
        public bool UpdateProfile(UpdateProfile _UpdateProfileClass)
        {
            if (_IregisterService.UpdateProfile(_UpdateProfileClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //[HttpGet, Route("api/Register/GetRegisteredallGames")]
        //public List<string> Gamerating()
        //{
        //    return _IregisterService.Gamerating();
        //}
    }
}
