using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using NUnit.Framework;
using Npgsql;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Threading.Tasks;
using RestSharp.Authenticators;
using Models;
using Newtonsoft.Json;
using System.Net;

namespace Rest_api_test_1._4
{
    public class BaseMethods
    {
        public static void DisableCheckCertificate()
        {
            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, ssPolicy) => true;
        }

        public static string GetDataFromDb(string queryText) //выполнить sql запрос в файле в папке ..\..\SQL\
        {
            String connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password='';Database=biosmart_maindb;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            var sqlQueryCheck = String.Format("SELECT count(*) FROM (" + queryText + ") as employee");
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sqlQueryCheck, npgSqlConnection);

            string result = "";
            int count = Convert.ToInt32(npgSqlCommand.ExecuteScalar());

            if (count != 0)
            {
                npgSqlCommand = new NpgsqlCommand(queryText, npgSqlConnection);
                result = npgSqlCommand.ExecuteScalar().ToString(); //вернуть результат если result !=0 
            }

            npgSqlConnection.Close();

            return result; //вернуть "" если result = 0 
        }

        public static string GetDataFromDbSimple(string queryText) //выполнить sql запрос в файле в папке ..\..\SQL\
        {
            String connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password='';Database=biosmart_maindb;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            var sqlQueryCheck = String.Format("SELECT count(*) FROM (" + queryText + ") as employee");
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sqlQueryCheck, npgSqlConnection);

            string result = "";
            int count = Convert.ToInt32(npgSqlCommand.ExecuteScalar());

            if (count != 0)
            {
                npgSqlCommand = new NpgsqlCommand(queryText, npgSqlConnection);
                result = npgSqlCommand.ExecuteScalar().ToString(); //вернуть результат если result !=0 
            }

            npgSqlConnection.Close();

            return result; //вернуть "" если result = 0 
        }

        public static void ExecuteSqlQuery(string queryName) //выполнить sql запрос в файле в папке ..\..\SQL\
        {
            String connectionString = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=''; Database=biosmart_maindb;";
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();

            string script = File.ReadAllText(@"..\SQL\" + queryName);

            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(script, npgSqlConnection);
            NpgsqlDataReader result = npgSqlCommand.ExecuteReader();

            npgSqlConnection.Close();
        }

        public static async Task<IRestResponse> GetResponse(RestClient client, RestRequest request)
        {
            var response = client.ExecuteAsync(request);
            Console.WriteLine(response.Result.IsSuccessful);
            Console.WriteLine(response.Result.StatusCode);
            Console.WriteLine(response.Result.ErrorMessage);
            Console.WriteLine(response.Result.ErrorException);
            return await response; 
        }

    }
}
