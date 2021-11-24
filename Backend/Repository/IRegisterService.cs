using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamingModels;

namespace Repository
{
  public interface IRegisterService
    {
        public bool GameRegister(Register register);
        public bool GameLogin(Login _login);
        string ForgotPassword(string _GameName);
        List<string> GetRegisteredallGames();
        bool DeleteGame(string GameName);
        bool ResetPassword(ResetPasswordClass _resetPassword);

        bool UpdateProfile(UpdateProfile _UpdateProfileClass);
      //  List<string> Gamerating();
    }
}
