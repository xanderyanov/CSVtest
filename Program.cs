using MmxCMS;
using System;
using System.Text;

namespace CSVtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\tovar.csv", System.Text.Encoding.UTF8);
            CSVFile csv = new(lines, ';', '"',
                "Код;Наименование;Артикул;Цена",
                "Code;Name;Article;Price");
            csv.Rewind();
            while (csv.Next())
            {
                Console.WriteLine($"Код: {csv["Code"]}, Наименование: {csv["Name"]}, Артикул: {csv["Article"]}, Цена: {csv["Price"]}");
            }
        }
    }


}



//Сервер для внешних подключений: (база MySql)
//deltaa.beget.tech
//deltaa_csv1
//N3m17DWh


//В csv название полей на русском(

//распарсить csv по ключам
//Сохранить результат (в базу?)
