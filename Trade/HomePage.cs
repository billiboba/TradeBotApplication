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

namespace Trade
{
    
    public partial class HomePage : Form
    {
        public class CryptoCurrency
        {
            //public string Name { get; set; }
            public string Symbol { get; set; }
            public int Id { get; set; }
            public string Price { get; set; }
        }
        public HomePage()
        {
            InitializeComponent();
            //SI.SaveInst();
            
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var connectionString = "Data Source=DESKTOP-CR5D09I\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
        }

        private void DeleteDb_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-CR5D09I\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "DELETE FROM Currencies WHERE Id>0";
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
            string query = "SELECT * FROM Currencies";
            string connectionString = "Data Source=DESKTOP-CR5D09I\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True";
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
    }
    
}
