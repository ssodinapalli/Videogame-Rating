using System;
using System.Collections.Generic;
using VideoGamingModels;
using DbContext;
using DbContext.Exceptions;
using System.Data.SqlClient;


namespace Repository
{
    public class RegisterService: IRegisterService
    {
        
        private SqlConnection _connection;

        private SqlCommand _command;

        public RegisterService()
        {
            _connection = new SqlConnection(ApplicationContext._ConnectionString);
        }

        public bool GameRegister(Register register)
        {
            bool isSuccess = false;
            try
            {

                using (_command = new SqlCommand($"INSERT INTO Register1 VALUES ('" + register.GameName + "','" +
                  register.Password + "','" + register.ConfirmPassword + "','"+register.rating+ "','" + register.GamePopularity + "')", _connection))
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
        public string ForgotPassword(string GameName)
        {
            string _password = "";
            try
            {
                using (_command = new SqlCommand("select ConfirmPassword from Register1 where GameName = '" + GameName + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();
                    _password = Convert.ToString(_command.ExecuteScalar());
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

            return _password;
        }
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
        public bool ResetPassword(ResetPasswordClass _resetPassword)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("Update Register1 set Password = '" + _resetPassword.Password + "' , ConfirmPassword='" + _resetPassword.Password + "'  where GameName='" + _resetPassword.GameName + "' ", _connection))
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
        //public List<string> Gamerating()
        //{
        //    List<string> _customers = new List<string>();

        //    try
        //    {
        //        using (_command = new SqlCommand("SELECT GameName,Gamerating FROM Register1 where GameID>0 ", _connection))
        //        {
        //            if (_connection.State == System.Data.ConnectionState.Closed)
        //                _connection.Open();

        //            SqlDataReader reader = _command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                //  _customers.Add(new Register() {Gamerating = reader.GetString(1) });
        //                //_customers.Add(reader.GetString(0));
        //               _customers.Add(reader.GetString(4));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new GamingExceptions(ex.Message, ex);
        //    }
        //    finally
        //    {
        //        if (_connection.State == System.Data.ConnectionState.Open)
        //            _connection.Close();
        //    }

        //    return _customers;
        //}



    }


}
