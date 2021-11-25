using System;

namespace VideoGamingModels
{
    //Create class for Register
    public class Register
    {
        public string GameName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string rating { get; set; }
        public string GamePopularity { get; set; }
    }

    //Create class for Login
    public class Login
    {
        public string GameName { get; set; }
        public string Password { get; set; }
    }


    //Create class for DeleteGame
    public class DeleteGame
    {
        public string GameName { get; set; }
    }

    //Create class for Gamerating
    public class Gamerating
    {
        public string GameName { get; set; }
        public string rating { get; set; }
    }

    //Create class for Popularity
    public class Popularity
    {
        public string GameName { get; set; }
        public string GamePopularity { get; set; }
    }

    //Create class for ResetPasswordClass
    public class ResetPasswordClass
    {
        public string GameName { get; set; }
        public string Password { get; set; }
    }

    //Create class for UpdateProfile
    public class UpdateProfile
    {
        public string OldGameName { get; set; }
        public string GameName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string rating { get; set; }
        public string GamePopularity { get; set; }

    }

    //Create class for GameCategory
    public class GameCategory
    {
        public string Indoorgames { get; set; }
        public string Outdoorgames { get; set; }
    }
  
}
