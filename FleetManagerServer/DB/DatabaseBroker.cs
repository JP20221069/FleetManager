﻿using FleetManagerCommon.Domain;
using FleetManagerCommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerServer.DB
{
    public class DatabaseBroker
    {
        private DatabaseConnection connection;
        public DatabaseBroker()
        {
            connection = new DatabaseConnection();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Add(IEntity obj)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {obj.TableName} VALUES({obj.Values} )";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }
        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = $"SELECT * FROM {entity.TableName}";
            SqlDataReader reader = comm.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            comm.Dispose();
            return list;
        }

        public Korisnik Login(Korisnik user)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK WHERE Username ='"+user.Username+"' AND Password = '"+user.Password+"' AND Ulogovan=0 AND Aktivan=1;";
            SqlDataReader reader = comm.ExecuteReader();
            bool success = false;
            try
            {

                if (reader.Read())
                {
                    user.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    user.Username = reader["Username"].ToString();
                    user.Rola = reader.GetInt32(reader.GetOrdinal("Rola"));
                    success = true;
                }
                else
                {
                    throw new UserAlreadyLoggedInException();
                }
            }
            finally
            {
                reader.Close();
                if(success==true)
                {
                    SetLoggedIn(user, true);
                }
            }
            return user;
        }

        public Korisnik Logout(Korisnik user)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK WHERE Username ='" + user.Username + "' AND Password = '" + user.Password + "' AND Ulogovan=1 AND Aktivan=1;";
            SqlDataReader reader = comm.ExecuteReader();
            bool success = false;
            try
            {

                if (reader.Read())
                {
                    user.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    user.Username = reader["Username"].ToString();
                    user.Rola = reader.GetInt32(reader.GetOrdinal("Rola"));
                    success = true;
                }
            }
            finally
            {
                reader.Close();
                if(success==true)
                {
                    SetLoggedIn(user, false);
                }
            }
            return user;
        }

        public void SetLoggedIn(Korisnik user,bool logged_in)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE KORISNIK SET Ulogovan="+Convert.ToInt32(logged_in)+" WHERE ID="+user.ID+" AND Aktivan=1;";
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Korisnik AddUser(Korisnik user)
        {
            if (ChkUsername(user))
            {
                Add(user);
                return GetUserByUsername(user);
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
        }

        public Korisnik GetUserByUsername(Korisnik user)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK WHERE Username ='" + user.Username + "' AND Password = '" + user.Password + "';";
            SqlDataReader reader = comm.ExecuteReader();
            try
            {

                if (reader.Read())
                {
                    user.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    user.Username = reader["Username"].ToString();
                    user.Rola = reader.GetInt32(reader.GetOrdinal("Rola"));
                    user.LoggedIn = reader.GetBoolean(reader.GetOrdinal("Ulogovan"));
                    user.Aktivan = reader.GetBoolean(reader.GetOrdinal("Aktivan"));
                }
                else
                {
                    throw new UserNotFoundException();
                }
            }
            finally
            {
                reader.Close();
            }
            return user;
        }

        public Korisnik GetUserByID(Korisnik user)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK WHERE ID ="+user.ID+";";
            SqlDataReader reader = comm.ExecuteReader();
            try
            {

                if (reader.Read())
                {
                    user.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    user.Username = reader["Username"].ToString();
                    user.Rola = reader.GetInt32(reader.GetOrdinal("Rola"));
                    user.LoggedIn = reader.GetBoolean(reader.GetOrdinal("Ulogovan"));
                    user.Aktivan = reader.GetBoolean(reader.GetOrdinal("Aktivan"));
                }
                else
                {
                    throw new UserNotFoundException();
                }
            }
            finally
            {
                reader.Close();
            }
            return user;
        }

        public bool ChkUsername(Korisnik user)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT COUNT(*) FROM KORISNIK WHERE ID =" + user.ID + ";";
            int cnt = Convert.ToInt32(comm.ExecuteScalar());
            if (cnt > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool ChkLoggedIn(Korisnik user)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT Ulogovan FROM KORISNIK WHERE ID =" + user.ID + ";";
            bool ulogovan = Convert.ToBoolean(comm.ExecuteScalar());
            return ulogovan;

        }

        public Korisnik UpdateUser(Korisnik user)
        {
            if(ChkLoggedIn(user))
            {
                throw new UpdateDeniedUserLoggedIn();
            }
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE KORISNIK SET Username='" + user.Username + "',Password='" + user.Password + "',Aktivan=" + Convert.ToInt32(user.Aktivan) + ",Ulogovan=" + Convert.ToInt32(user.LoggedIn) + " WHERE ID="+user.ID+";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return GetUserByID(user);
        }

    }
}
