using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace Spring_Hero_Bank_t1908m.Helper
{
    public class ConnectionHelper
    {
        private const string DatabaseServer = "127.0.0.1";
            private const string DatabaseName = "spring-hero-bank";
            private const string DatabasePassword = "";
            private const string DatabaseUsername = "root";

            private static MySqlConnection _connection;

            public static MySqlConnection GetConnection()
            {
                if (_connection != null && _connection.State != ConnectionState.Broken)
                {
                    return _connection;
                }

                Console.WriteLine("Connect to database... ");
                _connection = new MySqlConnection(
                    $"SERVER={DatabaseServer};DATABASE={DatabaseName};UID={DatabaseUsername};PASSWORD={DatabasePassword}");
                Console.WriteLine("...success!!!!");
                return _connection;
            }
        }
    }