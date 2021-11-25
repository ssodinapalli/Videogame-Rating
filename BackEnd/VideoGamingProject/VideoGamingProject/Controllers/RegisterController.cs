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

    //Create Register Controller for ControllerBase
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _IregisterService;
        public RegisterController(IRegisterService reg)
        {
            _IregisterService = reg;
        }

        //Provides Functionality to RegisterGames
        [HttpPost, Route("api/Register/RegisterGames")]

        public bool RegisterGames(Register student)
        {
            if (_IregisterService.GameRegister(student))
            {
                return true;
            }
            return false;
        }

        //Provides Functionality to GamesLogin
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

        //Provides Functionality to ForgotPassword
        [HttpGet, Route("api/Register/ForgotPassword")]
        public string ForgotPassword(string GameName)
        {
            return _IregisterService.ForgotPassword(GameName);
        }

        //Provides Functionality to Registeredallgames
        [HttpGet, Route("api/Register/GetRegisteredallGames")]
        public List<string> GetRegisteredGames()
        {
            return _IregisterService.GetRegisteredallGames();
        }

        //Provides Functionality to DeleteGame
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

        //Provides Functionality to Resetpassword
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
        //Provides Functionality to UpdateProfile
        [HttpPut, Route("api/Register/UpdateProfile")]
        public bool UpdateProfile(UpdateProfile _UpdateProfile)
        {
            if (_IregisterService.UpdateProfile(_UpdateProfile))

      
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Provides Functionality to Gamerating
        [HttpGet, Route("api/Register/Gamerating")]
        public IEnumerable<Gamerating> Gamerating()
        {
            return _IregisterService.Gamerating();
        }

        //Provides Functionality to Popularity
        [HttpGet, Route("api/Register/Popularity")]
        public IEnumerable<Popularity> Popularity()
        {
            return _IregisterService.Popularity();
        }

        //Provides Functionality to GameCategory
        [HttpGet, Route("api/Register/GameCategory")]
        public IEnumerable<GameCategory> GamingCategory()
        {
            return _IregisterService.GameCategory();
          

        }
    }
}
