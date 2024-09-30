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

        MySqlConnection connection;
        Car cars = new Car();
        string tablename = "autok";

        public databaseHandler()
        {
            string username = "root";
            string password = "";
            string database = "trabant";
            string host = "localhost";
            string connectionString = $"host={host};username={username};password={password};database={database}";
            connection = new MySqlConnection(connectionString);

        }

        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM autok";

                MySqlCommand command = new MySqlCommand(query, connection);
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
                connection.Close();
                MessageBox.Show("fut");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void addOne(Car oneCar)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tablename}(make,model,color,year,power) VALUES('{oneCar.make}','{oneCar.model}','{oneCar.color}','{oneCar.year}','{oneCar.hp}')";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteOne(Car oneCar)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tablename} WHERE ID = {oneCar.ID}";
                MySqlCommand command = new MySqlCommand(query,connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("törölve");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
