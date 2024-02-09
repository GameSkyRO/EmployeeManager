using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    internal class AppDAO
    {
        //string conectare baza de date
        string connString = "datasource=localhost;port=3306;username=root;password=root;database=atestat;";
        public List<app> GetApps(int acces)
        {
            List<app> returnThese = new List<app>();

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open(); //stabilire conexiune

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM apps WHERE `Acces` >= " + acces;
            command.Connection = conn;
            Debug.WriteLine(command.CommandText);



            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    app aplicatie = new app
                    {
                        ID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Stare = reader.GetString(2),
                        Pagina = reader.GetString(3),
                        Acces = reader.GetInt32(4)
                    };
                    returnThese.Add(aplicatie);
                }
            }
            conn.Close();

            return returnThese;
        }

        public void addApp(app appToAdd)
        {

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open(); //stabilire conexiune

            MySqlCommand command = new MySqlCommand("INSERT INTO `apps`(`Nume`, `Stare`, `Pagina`, `Acces`) VALUES(@appnume, @appstare, @appdesc, @appacc)",conn);
            
            command.Parameters.AddWithValue("@appnume", appToAdd.Nume);
            command.Parameters.AddWithValue("@appstare", appToAdd.Stare);
            command.Parameters.AddWithValue("@appdesc", appToAdd.Pagina);
            command.Parameters.AddWithValue("@appacc", appToAdd.Acces);
            command.ExecuteNonQuery();
            conn.Close();

        }

        public void addEmployee(angajat employeeToAdd)
        {

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open(); //stabilire conexiune

            MySqlCommand command = new MySqlCommand("INSERT INTO `angajati`(`Nume`, `Email`, `An angajare`, `Departament`, `Echipa`, `Functie`, `Imagine`) VALUES ( @nume, @email, @an, @departament, @echipa, @functie, @imagine)", conn);

            command.Parameters.AddWithValue("@nume", employeeToAdd.Nume);
            command.Parameters.AddWithValue("@email", employeeToAdd.Email);
            command.Parameters.AddWithValue("@an", employeeToAdd.An);
            command.Parameters.AddWithValue("@departament", employeeToAdd.Departament);
            command.Parameters.AddWithValue("@echipa", employeeToAdd.Echipa);
            command.Parameters.AddWithValue("@functie", employeeToAdd.Functie);
            command.Parameters.AddWithValue("@imagine", employeeToAdd.LinkImagine);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public List<echipa> GetEchipe()
        {
            List<echipa> returnThese = new List<echipa>();

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open(); //stabilire conexiune

            MySqlCommand command = new MySqlCommand();
            
            command.CommandText = "SELECT * FROM echipe ORDER BY ID DESC";
            
            command.Connection = conn;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    echipa Echipa = new echipa
                    {
                        ID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        prioritateAcc = reader.GetInt32(2),
                    };
                    returnThese.Add(Echipa);
                }
            }
            conn.Close();

            return returnThese;
        }

        public List<angajat> GetAngajati()
        {
            List<angajat> returnThese = new List<angajat>();

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open(); //stabilire conexiune

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM angajati ORDER BY ID DESC";
            command.Connection = conn;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    angajat Angajat = new angajat
                    {
                        ID = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Email = reader.GetString(2),
                        An = reader.GetInt32(3),
                        Departament = reader.GetString(4),
                        Echipa =reader.GetString(5),
                        Functie = reader.GetString(6),
                        LinkImagine = reader.GetString(7),
                    };
                    returnThese.Add(Angajat);
                }
            }
            conn.Close();

            return returnThese;
        }

        public int Login(string Username, string Password)
        {

            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open(); //stabilire conexiune

            MySqlCommand command = new MySqlCommand(); 

            try
            {
                command.CommandText = "SELECT * FROM `conectare` WHERE `Username` = @username AND `Password` = @password";
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@password", Password);

                command.Connection = conn;

                MySqlDataReader reader = command.ExecuteReader();
                int acces = 0;
                if(reader.Read()) { acces = reader.GetInt32(3); }
                    
                return acces;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
            finally
            {
                conn.Close();
            }
            
            

            
        }


    }
}
