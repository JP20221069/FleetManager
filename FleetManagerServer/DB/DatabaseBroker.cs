using Common.Domain;
using FleetManagerCommon.Domain;
using FleetManagerCommon.Exceptions;
using FleetManagerServer.SysOps;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            cmd.CommandText = $"INSERT INTO {obj.TableName}({obj.ColumnNames}) VALUES({obj.Values} )";
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

        public void AddUser(Korisnik user)
        {
            if (ChkUsername(user))
            {
                Add(user);
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
        }

        public Korisnik GetUserByUsername(string username)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK WHERE Username ='" + username + "';";
            SqlDataReader reader = comm.ExecuteReader();
            Korisnik user = new Korisnik();
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
                    throw new RecordNotFoundException();
                }
            }
            finally
            {
                reader.Close();
            }
            return user;
        }

        public Korisnik GetUserByID(int id)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK WHERE ID ="+id+";";
            SqlDataReader reader = comm.ExecuteReader();
            Korisnik user = new Korisnik();
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
                    throw new RecordNotFoundException();
                }
            }
            finally
            {
                reader.Close();
            }
            return user;
        }

        public List<Korisnik> GetAllUsers()
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM KORISNIK;";
            SqlDataReader reader = comm.ExecuteReader();
            List<Korisnik> ret = new List<Korisnik>();
            try
            {

                while (reader.Read())
                {
                    Korisnik user = new Korisnik();
                    user.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    user.Username = reader["Username"].ToString();
                    user.Rola = reader.GetInt32(reader.GetOrdinal("Rola"));
                    user.LoggedIn = reader.GetBoolean(reader.GetOrdinal("Ulogovan"));
                    user.Aktivan = reader.GetBoolean(reader.GetOrdinal("Aktivan"));
                    ret.Add(user);
                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
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
            return GetUserByID(user.ID);
        }

        public void DeleteKorisnik(Korisnik user)
        {
            if (ChkLoggedIn(user))
            {
                throw new UpdateDeniedUserLoggedIn();
            }
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM KORISNIK WHERE ID=" + user.ID + ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void AddVehicle(Vozilo vehicle)
        {
            Add(vehicle);
        }

        public Vozilo GetVehicleByID(int id)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM VOZILO WHERE ID =" + id + ";";
            SqlDataReader reader = comm.ExecuteReader();
            Vozilo vehicle = new Vozilo();
            try
            {

                if (reader.Read())
                {

                    vehicle.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    vehicle.Naziv = reader["Naziv"].ToString();
                    vehicle.Marka = reader["Marka"].ToString();
                    vehicle.Nosivost = (float)reader.GetSqlDouble(reader.GetOrdinal("Nosivost")).Value;
                    vehicle.Status = (StatusVozila)reader.GetInt32(reader.GetOrdinal("Status"));
                    vehicle.RegBroj = reader["RegBroj"].ToString();
                    vehicle.Tip = reader["Tip"].ToString();

                }
                else
                {
                    throw new RecordNotFoundException();
                }
            }
            finally
            {
                reader.Close();
            }
            return vehicle;
        }
        public Vozilo GetVehicleByLP(string lp)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM VOZILO WHERE RegBroj='"+lp+"';";
            SqlDataReader reader = comm.ExecuteReader();
            Vozilo vehicle = new Vozilo();
            try
            {

                if (reader.Read())
                {

                    vehicle.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    vehicle.Naziv = reader["Naziv"].ToString();
                    vehicle.Marka = reader["Marka"].ToString();
                    vehicle.Nosivost = (float)reader.GetSqlDouble(reader.GetOrdinal("Nosivost")).Value;
                    vehicle.Status = (StatusVozila)reader.GetInt32(reader.GetOrdinal("Status"));
                    vehicle.RegBroj = reader["RegBroj"].ToString();
                    vehicle.Tip = reader["Tip"].ToString();

                }
                else
                {
                    throw new RecordNotFoundException();
                }
            }
            finally
            {
                reader.Close();
            }
            return vehicle;
        }

        public List<Vozilo> SearchVehicleBy(Vozilo v)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM VOZILO";
            List<string> search_options = new List<string>();
            if(!string.IsNullOrEmpty(v.Naziv))
            {
                search_options.Add("Naziv LIKE '%" + v.Naziv + "%'");
            }
            if(!string.IsNullOrEmpty(v.Tip))
            {
                search_options.Add("Tip = '" + v.Tip + "'");
            }
            if(!string.IsNullOrEmpty(v.Marka))
            {
                search_options.Add("Marka = '"+v.Marka+"'");
            }
            if(v.Status!=StatusVozila.Default)
            {
                search_options.Add("Status = " + v.Status);
            }
            if(v.Nosivost>0)
            {
                search_options.Add("Nosivost = " + v.Nosivost);
            }
            if (!string.IsNullOrEmpty(v.RegBroj))
            {
                search_options.Add("RegBroj='" + v.RegBroj + "'");
            }

            if(search_options.Count>0)
            {
                comm.CommandText += " WHERE ";
                foreach(string name in search_options)
                {
                    comm.CommandText += name;
                    if(name!=search_options.Last())
                    {
                        comm.CommandText += " AND ";
                    }
                    else
                    {
                        comm.CommandText += ";";
                    }
                }
            }
            SqlDataReader reader = comm.ExecuteReader();
            List<Vozilo> ret = new List<Vozilo>();
            int count = 0;
            try
            {

                while (reader.Read())
                {
                    Vozilo vehicle = new Vozilo();
                    vehicle.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    vehicle.Naziv = reader["Naziv"].ToString();
                    vehicle.Marka = reader["Marka"].ToString();
                    vehicle.Nosivost = (float)reader.GetSqlDouble(reader.GetOrdinal("Nosivost")).Value;
                    vehicle.Status = (StatusVozila)reader.GetInt32(reader.GetOrdinal("Status"));
                    vehicle.RegBroj = reader["RegBroj"].ToString();
                    vehicle.Tip = reader["Tip"].ToString();
                    vehicle.Zaduzenja = GetAllCheckinsByVehicle(vehicle);
                    vehicle.Servisiranja = GetAllServicings(vehicle);
                    ret.Add(vehicle);
                    count++;

                }
                if(count==0)
                {
                    throw new RecordNotFoundException();
                }

            }
            finally
            {
                reader.Close();
            }
            return ret;
        }

        public int GetVehicleStatus(Vozilo vehicle)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT STATUS FROM VOZILO WHERE ID =" + vehicle.ID + ";";
            int status = Convert.ToInt32(comm.ExecuteScalar());
            return status;
        }

        public List<Vozilo> GetAllVehicles()
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM VOZILO;";
            SqlDataReader reader = comm.ExecuteReader();
            List<Vozilo> ret = new List<Vozilo>();
            try
            {

                while (reader.Read())
                {
                    Vozilo vehicle = new Vozilo();
                    vehicle.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    vehicle.Naziv = reader["Naziv"].ToString();
                    vehicle.Marka = reader["Marka"].ToString();
                    vehicle.Nosivost = (float)reader.GetSqlDouble(reader.GetOrdinal("Nosivost")).Value;
                    vehicle.Status = (StatusVozila)reader.GetInt32(reader.GetOrdinal("Status"));
                    vehicle.RegBroj = reader["RegBroj"].ToString();
                    vehicle.Tip = reader["Tip"].ToString();
                    vehicle.Zaduzenja = GetAllCheckinsByVehicle(vehicle);
                    vehicle.Servisiranja = GetAllServicings(vehicle);
                    ret.Add(vehicle);

                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }

        public List<Vozilo> GetAllFreeVehicles()
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM VOZILO WHERE Status=0;";
            SqlDataReader reader = comm.ExecuteReader();
            List<Vozilo> ret = new List<Vozilo>();
            try
            {

                while (reader.Read())
                {
                    Vozilo vehicle = new Vozilo();
                    vehicle.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    vehicle.Naziv = reader["Naziv"].ToString();
                    vehicle.Marka = reader["Marka"].ToString();
                    vehicle.Nosivost = (float)reader.GetSqlDouble(reader.GetOrdinal("Nosivost")).Value;
                    vehicle.Status = (StatusVozila)reader.GetInt32(reader.GetOrdinal("Status"));
                    vehicle.RegBroj = reader["RegBroj"].ToString();
                    vehicle.Tip = reader["Tip"].ToString();
                    vehicle.Zaduzenja = GetAllCheckinsByVehicle(vehicle);
                    vehicle.Servisiranja = GetAllServicings(vehicle);
                    ret.Add(vehicle);

                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }
        public void AddServisiranje(Servisiranje servisiranje)
        {
            Add(servisiranje);
        }

        public void AddStavkaServisiranja(StavkaServisiranja stavka_servisiranja)
        {
            Add(stavka_servisiranja);
        }

        public List<StavkaServisiranja> GetAllServiceItems(Servisiranje s)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM STAVKA_SERVISIRANJA WHERE ServisiranjeID="+s.ID+";";
            SqlDataReader reader = comm.ExecuteReader();
            List<StavkaServisiranja> ret = new List<StavkaServisiranja>();
            try
            {

                while (reader.Read())
                {
                    StavkaServisiranja ss = new StavkaServisiranja();
                    ss.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    ss.Naziv = reader["Naziv"].ToString();
                    ss.Opis = reader["Opis"].ToString();
                    ss.Servisiranje = s;
                    ret.Add(ss);

                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }

        public List<Servisiranje> GetAllServicings(Vozilo v)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM SERVISIRANJE WHERE VoziloID=" + v.ID + ";";
            SqlDataReader reader = comm.ExecuteReader();
            List<Servisiranje> ret = new List<Servisiranje>();
            try
            {

                while (reader.Read())
                {
                    Servisiranje s = new Servisiranje();
                    s.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    s.Napomena = reader["Napomena"].ToString();
                    s.Datum = reader.GetDateTime(reader.GetOrdinal("Datum"));
                    s.Stavke = GetAllServiceItems(s);
                    ret.Add(s);

                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }

        public List<Zaduzenje> GetAllCheckinsByVehicle(Vozilo v)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM ZADUZENJE WHERE VoziloID=" + v.ID + ";";
            SqlDataReader reader = comm.ExecuteReader();
            List<Zaduzenje> ret = new List<Zaduzenje>();
            try
            {

                while (reader.Read())
                {
                    Zaduzenje z = new Zaduzenje();

                    z.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    z.Vozilo = v;
                    z.Korisnik = GetUserByID(reader.GetInt32(reader.GetOrdinal("KorisnikID")));
                    z.Napomena = reader.IsDBNull(reader.GetOrdinal("Napomena"))? " " : reader["Napomena"].ToString();
                    z.Aktivno = reader.GetBoolean(reader.GetOrdinal("Aktivno"));
                    z.VremeZaduzenja = reader.GetDateTime(reader.GetOrdinal("VremeZaduzenja"));
                    z.VremeRazduzenja = reader.IsDBNull(reader.GetOrdinal("VremeRazduzenja")) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("VremeRazduzenja"));
                    z.RelacijaOd = reader["RelacijaOd"].ToString();
                    z.RelacijaDo = reader["RelacijaDo"].ToString();

                    ret.Add(z);
                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }

        public List<Zaduzenje> GetCheckinsByUser(Korisnik k,bool activeOnly=false)
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM ZADUZENJE WHERE KorisnikID=" + k.ID;
            if(activeOnly)
            {
                comm.CommandText += " AND Aktivno=1";
            }
            comm.CommandText += ";";
            SqlDataReader reader = comm.ExecuteReader();
            List<Zaduzenje> ret = new List<Zaduzenje>();
            try
            {

                while (reader.Read())
                {
                    Zaduzenje z = new Zaduzenje();

                    z.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    z.Vozilo = GetVehicleByID(reader.GetInt32(reader.GetOrdinal("VoziloID")));
                    z.Korisnik = k;
                    z.Napomena = reader.IsDBNull(reader.GetOrdinal("Napomena"))? "" : reader["Napomena"].ToString();
                    z.Aktivno = reader.GetBoolean(reader.GetOrdinal("Aktivno"));
                    z.VremeZaduzenja = reader.GetDateTime(reader.GetOrdinal("VremeZaduzenja"));
                    z.VremeRazduzenja = reader.IsDBNull(reader.GetOrdinal("VremeRazduzenja")) ? DateTime.Now : reader.GetDateTime(reader.GetOrdinal("VremeRazduzenja"));
                    z.RelacijaOd = reader["RelacijaOd"].ToString();
                    z.RelacijaDo = reader["RelacijaDo"].ToString();

                    ret.Add(z);
                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }

        public void CheckinVehicle(Zaduzenje z)
        {
            int s = GetVehicleStatus(z.Vozilo);
            if(s==(int)StatusVozila.Zaduzeno)
            {
                throw new UnableToCheckInException();
            }
            else
            {
                Add(z);
                z.Vozilo.Status = StatusVozila.Zaduzeno;
                UpdateVehicle(z.Vozilo);
            }
        }

        public void UpdateVehicle(Vozilo veh)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE VOZILO SET Naziv='"+veh.Naziv+"',Marka='"+veh.Marka+"',Tip='"+veh.Tip+"',Status="+(int)veh.Status+",Nosivost="+veh.Nosivost+",RegBroj='"+veh.RegBroj+"' WHERE ID="+veh.ID+";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void DeleteVehicle(int id)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM VOZILO WHERE ID=" + id + ";";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void CheckoutVehicle(Zaduzenje z)
        {
            int s = GetVehicleStatus(z.Vozilo);
            if(s!=(int)StatusVozila.Zaduzeno)
            {
                throw new UnableToCheckInException();
            }
            else
            {
                z.Vozilo.Status = (int)StatusVozila.Aktivno;
                UpdateVehicle(z.Vozilo);
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE ZADUZENJE SET VremeRazduzenja='"+z.VremeRazduzenja.ToString("yyyy-MM-dd")+"', Aktivno=0 WHERE ID="+z.ID;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

       /* public void TestConnection()
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_CATALOG='FleetManager';";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }*/

        public List<Servis> GetAllServices()
        {
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "SELECT * FROM SERVIS;";
            SqlDataReader reader = comm.ExecuteReader();
            List<Servis> ret = new List<Servis>();
            try
            {

                while (reader.Read())
                {
                    Servis s = new Servis();
                    s.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    s.Naziv = reader["Naziv"].ToString();
                    s.Adresa = reader["Adresa"].ToString();
                    ret.Add(s);

                }
            }
            finally
            {
                reader.Close();
            }
            return ret;
        }



    }
}
