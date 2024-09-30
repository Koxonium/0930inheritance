using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace _0930inheritance
{
    public class databaseHandler
    {

        MySqlConnection conncection;
        Car cars = new Car();

        public databaseHandler()
        {
            string username = "root";
            string password = "";
            string database = "trabant";
            string host = "localhost";
            string connectionString = $"host={host};username={username};password={password};database={database}";
            conncection = new MySqlConnection(connectionString);
            
        }

        public void readAll()
        {
            try
            {
                conncection.Open();
                string query = $"SELECT * FROM autok";

                MySqlCommand command = new MySqlCommand(query,conncection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Car oneCar = new Car();
                    oneCar.ID = read.GetInt32(read.GetOrdinal("id"));
                    oneCar.make = read.GetString("make");
                    oneCar.model = read.GetString("model");
                    oneCar.color = read.GetString("color");
                    oneCar.year = read.GetInt32(read.GetOrdinal("year"));
                    oneCar.hp = read.GetInt32(read.GetOrdinal("power"));
                    Car.cars.Add(oneCar);
                }
                read.Close();
                command.Dispose();
                conncection.Close();
                MessageBox.Show("fut");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);   
            }
        }
    }
}
