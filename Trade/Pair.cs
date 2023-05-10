using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Binance.Net;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Net;

namespace Trade
{
    /*public class Currency
    {
        public string Name { get; set; }
        public double Price { get; set; }

    }
    public class CryptoContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CR5D09I\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True");
        }

    }
    public class SaveInstruments
    {
        public void SaveInst()
        {
            using (var context = new CryptoContext())
            {
                // Создаем объект криптовалюты
                var currency = new Currency
                {
                    Name = "Bitcoin",
                    Price = 35645.44,
                };

                // Добавляем объект в контекст и сохраняем изменения в базе данных
                context.Currencies.Add(currency);
                context.SaveChanges();
            }
        }
    }

    /*public class BinanceData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal lowPrice { get; set; }
        public decimal lastPrice { get; set; }
        public decimal Volatily { get; set; }
    }

    public class SaveDta
    {
        public void SaveInstruments()
        {
            string apiKey = "ydja7zrnr3i4bsQEQIyjNDMamwS6crmK4KEA69OXR1hew8SL7ip8oqu1kt42WhFG";
            string secretKey = "20Pohima";

            // Создание объекта WebClient для запросов к API Binance
            WebClient client = new WebClient();

            // Настройка заголовков для запроса к API Binance
            client.Headers.Add("X-MBX-APIKEY", apiKey);

            // Запрос на получение данных о криптовалютах в формате JSON
            string json = client.DownloadString("https://api.binance.com/api/v3/ticker/24hr");

            // Разбор JSON и преобразование его в объекты C#
            var binanceData = JsonConvert.DeserializeObject<BinanceData[]>(json);

            // Создание соединения к базе данных SQL
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-CR5D09I\\SQLEXPRESS;Initial Catalog=SaveBinance;TrustServerCertificate=True;Integrated Security=True");

            try
            {
                // Открытие соединения к базе данных SQL
                conn.Open();

                // Исполнение SQL-запроса для вставки данных в таблицу
                foreach (var data in binanceData)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"INSERT INTO TableBin (Name, Volatily) VALUES ('{data.Name}', {data.Volatily})";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Закрытие соединения к базе данных SQL
                conn.Close();
            }

        }
    }*/

}
