using System;

namespace VideoGamingModels
{
    public class Register
    {
        public string GameName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
       // public string GameId { get; set; }
        public string rating { get; set; }
        public string GamePopularity { get; set; }

    }
    

    public class Login
    {

        public string GameName { get; set; }
        public string Password { get; set; }
    }
    public class DeleteGame
    {
        public string GameName { get; set; }
    }
    //public class Gamerating
    //{
    //    public string rating { get; set; }
    //    public string GameName { get; set; }
    //}

    public class ResetPasswordClass
    {
        public string GameName { get; set; }

        // public string OldPassword { get; set; }

        public string Password { get; set; }
    }

    public class UpdateProfile
    {
        public string OldGameName { get; set; }
        public string GameName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        // public string GameId { get; set; }
        public string rating { get; set; }
        public string GamePopularity { get; set; }

    }
    

}
