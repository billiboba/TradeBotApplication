using Binance.Net.Clients;
using Binance;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.Net;
using Binance.Net.Objects;
using Binance.Spot;
using CryptoExchange.Net.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Timers;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Trade
{
    
    public partial class HomePage : Form
    {
        private Timer timer = new Timer();
        public class CryptoCurrency
        {
            public string Symbol { get; set; }
            public string Price { get; set; }
        }
        public HomePage()
        {
            InitializeComponent();
            timer.Interval = 5000;

            // Устанавливаем обработчик события таймера
            timer.Tick += timer1_Tick;

            // Запускаем таймер
            timer.Start();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                /*var query = "CREATE TABLE Currencies (id INT PRIMARY KEY IDENTITY(1,1),symbol NVARCHAR(50), price NVARCHAR(50));";
                using (var command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }*/
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString("https://api.binance.com/api/v1/ticker/allPrices");
                    var currencies = JsonConvert.DeserializeObject<List<CryptoCurrency>>(json);
                    // Добавляем в таблицу БД
                    using (var connection2 = new SqlConnection(connectionString))
                    {
                        connection2.Open();

                        foreach (var currency in currencies)
                        {
                            var query2 = $"INSERT INTO Currencies (symbol,price) VALUES('{currency.Symbol}','{currency.Price}');";
                            //var query3 = "UPDATE Currencies SET (price) VALUE('{}')";
                            using (var command = new SqlCommand(query2, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }  
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string connectionstring = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionstring);
            
            int rowIndex = e.RowIndex;

            for(int i = e.RowIndex+1; i < dataGridView1.Rows.Count; i++)
            {
                string id = dataGridView1.Rows[rowIndex].Cells["symbol"].Value.ToString(); // id - имя столбца с ID в таблице

                string query = $"SELECT * FROM Currencies WHERE symbol = '{id}'";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, connection);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Currencies");

                dataGridView1.DataSource = dataSet.Tables["Currencies"];
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
        }

        private void DeleteDb_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = @"DELETE FROM Currencies";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                var dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                adapter.SelectCommand.Dispose();
            }

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            connection.Close();
        }
        private void ViewDb_Click(object sender, EventArgs e)
        {
            string query = "SELECT symbol FROM Currencies";
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                var dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                adapter.SelectCommand.Dispose();
            }

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=Tru"))
            {
                // Открываем соединение
                connection.Open();

                // Создаем объект команды SQL для выполнения запроса
                SqlCommand command = new SqlCommand("UPDATE Currencies SET price", connection);

                // Выполняем запрос
                command.ExecuteNonQuery();

                // Закрываем соединение
                connection.Close();
            }
        }
    }
    
}
