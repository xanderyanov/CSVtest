using MmxCMS;
using System;
using System.Text;
using MongoDB.Driver;
using MongoDBDemo;
using System.Threading.Tasks;



namespace CSVtest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "mongodb://master:159753@localhost/mirchasov?authSource=admin";
            string databaseName = "simple_db";
            string CollectionName = "tovars";

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<TovarItem>(CollectionName);


            string[] lines = System.IO.File.ReadAllLines(@"D:\tovar.csv", System.Text.Encoding.UTF8);
            CSVFile csv = new(lines, ';', '"',
                "Код;Наименование;Артикул;Цена",
                "Code;Name;Article;Price");
            csv.Rewind();


            while (csv.Next())
            {
                var tovar = new TovarItem { Code =  csv["Code"].ToString(), Name = csv["Name"], Article = csv["Article"], Price = csv["Price"] };

                Console.WriteLine($"Код: {csv["Code"]}, Наименование: {csv["Name"]}, Артикул: {csv["Article"]}, Цена: {csv["Price"]}");
                
                await collection.InsertOneAsync(tovar);
            }
        }
    }

}



