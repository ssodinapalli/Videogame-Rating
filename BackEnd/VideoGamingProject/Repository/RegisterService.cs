using System;
using System.Collections.Generic;
using VideoGamingModels;
using DbContext;
using DbContext.Exceptions;
using System.Data.SqlClient;


namespace Repository
{
    public class RegisterService : IRegisterService
    {

        private SqlConnection _connection;

        private SqlCommand _command;

        public RegisterService()
        {
            _connection = new SqlConnection(ApplicationContext._ConnectionString);
        }

        //Create Database for GameRegister to insert into values
        public bool GameRegister(Register register)
        {
            bool isSuccess = false;
            try
            {

                using (_command = new SqlCommand($"INSERT INTO Register1 VALUES ('" + register.GameName + "','" +
                  register.Password + "','" + register.ConfirmPassword + "','" + register.rating + "','" + register.GamePopularity + "')", _connection))
                {
                    _connection.Open();

                    _command.ExecuteNonQuery();
                    isSuccess = true;
                }

            }



            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }


        //Create Database for GameLogin to  select from table
        public bool GameLogin(Login _login)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("SELECT * FROM Register1 where GameName='" + _login.GameName + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();
                    SqlDataReader Reader = _command.ExecuteReader();
                    while (Reader.Read())
                    {
                        if (_login.Password.Equals(Reader[3]))
                        {
                            isSuccess = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        //Create Database for ForgotPassword to  select from table
        public string ForgotPassword(string GameName)
        {
            string Password = " ";
            try
            {
                using (_command = new SqlCommand("select Password from Register1 where GameName= '" + GameName + "' ", _connection))
                using (_command = new SqlCommand("select ConfirmPassword from Register1 where GameName = '" + GameName + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();
                    Password = Convert.ToString(_command.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }
            return Password;
        }

        //Create Database for Registeredgames to  display the gamename
        public List<string> GetRegisteredallGames()
        {
            List<string> _customers = new List<string>();

            try
            {
                using (_command = new SqlCommand("SELECT GameName FROM Register1 where GameID>0 ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader.Read())
                    {
                        //  _customers.Add(new Register() {GameName = reader.GetString(1) });
                        _customers.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _customers;
        }

        //Create Database for Deletegame from to delete gamename from table
        public bool DeleteGame(string GameName)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("DELETE from Register1 where GameName = '" + GameName + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;

        }

        //Create Database for ResetPassword from to reset the password from table

        public bool ResetPassword(ResetPasswordClass _resetPassword)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("Update Register1 set CreatePassword = '" + _resetPassword.Password + "' , ConfirmPassword='" + _resetPassword.Password + "'  where GameName='" + _resetPassword.GameName + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }


        //Create Database for UpdateProfile from the table
        public bool UpdateProfile(UpdateProfile _UpdateProfileClass)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"Update Register1 set GameName='" + _UpdateProfileClass.GameName + "',Password='" + _UpdateProfileClass.Password + "',ConfirmPassword='" +
                     _UpdateProfileClass.ConfirmPassword + "',Gamerating='" + _UpdateProfileClass.rating + "', Gamepopularity='" +
                    _UpdateProfileClass.GamePopularity + "' where GameName = '" + _UpdateProfileClass.OldGameName + "'  ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        //Create Database for Gamerating to  display the rating
        public IEnumerable<Gamerating> Gamerating()
        {
            List<Gamerating> _customers = new List<Gamerating>();

            try
            {
                using (_command = new SqlCommand("SELECT GameName,Gamerating FROM Register1 where GameID>0 ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader.Read())
                    {
                        //  _customers.Add(new Register() {Gamerating = reader.GetString(1) });
                        _customers.Add(new Gamerating() { GameName = reader.GetString(0), rating = reader.GetString(1) });

                    }
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();

            }
            return _customers;

        }

        //Create Database for Popularity to  display the popularity of the game
        public IEnumerable<Popularity> Popularity()
        {

            List<Popularity> _customers = new List<Popularity>();

            try
            {
                using (_command = new SqlCommand("SELECT GameName,GamePopularity FROM Register1 where GameID>0 ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader.Read())
                    {
                        //  _customers.Add(new Register() {Gamerating = reader.GetString(1) });
                        _customers.Add(new Popularity() { GameName = reader.GetString(0), GamePopularity = reader.GetString(1) });

                    }
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();

            }
            return _customers;

        }

        //Create Database for GameCategory to  display the Category of the game
        public IEnumerable<GameCategory> GameCategory()
        {

            List<GameCategory> _customers = new List<GameCategory>();

            try
            {
                using (_command = new SqlCommand("SELECT Indoorgames,Outdoorgames FROM Register2 where GameID>0 ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader.Read())
                    {
                        //  _customers.Add(new Register() {Gamerating = reader.GetString(1) });
                        _customers.Add(new GameCategory() { Indoorgames = reader.GetString(0), Outdoorgames = reader.GetString(1) });

                    }
                }
            }
            catch (Exception ex)
            {
                throw new GamingExceptions(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();

            }
            return _customers;
        }
    }
}