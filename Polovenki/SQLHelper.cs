using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using static Utilities.Classes.RelativePath;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace Utilities.Classes
{
    public static class SQLHelper
    {
        private static SQLiteConnection _connection;
        private static string dbName;

        public static void SetNameDB(string DBName) {
            dbName = DBName;
        }

        public static void InitializeConnection()
        {
            if (_connection == null)
            {
                _connection = new SQLiteConnection("Data Source =" + GetFullPath(@"Source\Databases\"+dbName));
                _connection.Open();
                Console.WriteLine(dbName);
            }
        }

        public static int ExecuteScalarQueryWithParameters(string query, Dictionary<string, object> parameters)
        {
            InitializeConnection();

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                object result = command.ExecuteScalar();
                if (result == null)
                {
                    return 0;
                }

                try
                {
                    return Convert.ToInt32(result);
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Ошибка преобразования результата в int: {ex.Message}");
                    return 0;
                }
            }
        }

        public static void ExecuteQueryWithoutParameters(string query) {
            InitializeConnection();

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static void ExecuteQueryWithParameters(string query, Dictionary<string, object> parameters)
        {
            InitializeConnection();

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                command.ExecuteNonQuery();
            }
        }

        public static Dictionary<string, object> GetNext(string query)
        {
            InitializeConnection();
            Dictionary<string, object> manData = new Dictionary<string, object> { };

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                SQLiteDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string name = read["name"].ToString();
                    int age = int.Parse(read["age"].ToString());
                    string hobby = read["hobby"].ToString();
                    string music = read["music"].ToString();
                    string city = read["city"].ToString();
                    string sex = read["sex"].ToString();
                    string Reaction = read["Reaction"].ToString();

                    byte[] photo = (byte[])read["photo"];
                    manData.Add("name", name);
                    manData.Add("photo", photo);
                    manData.Add("age", age);
                    manData.Add("hobby", hobby);
                    manData.Add("music", music);
                    manData.Add("city", city);
                    manData.Add("sex", sex);
                    manData.Add("Reaction", Reaction);

                }
            }

            return manData;
        }

        public static Dictionary<string, object> GetGirl(string query)
        {
            InitializeConnection();
            Dictionary<string, object> manData2 = new Dictionary<string, object> { };

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                SQLiteDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string nameGirl = read["name"].ToString();
                    int ageGirl = int.Parse(read["age"].ToString());

                    manData2.Add("nameGirl", nameGirl);
                    manData2.Add("ageGirl", ageGirl);

                }
            }

            return manData2;
        }

        public static Dictionary<string, object> GetUsersData(string query)
        {
            InitializeConnection();
            Dictionary<string, object> manData = new Dictionary<string, object> { };

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                SQLiteDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string name = read["name"].ToString();
                    string born_date = read["borndate"].ToString();
                    string city = read["city"].ToString();
                    string height = read["height"].ToString();
                    string weight = read["weight"].ToString();
                    string hobby = read["hobby"].ToString();
                    string music = read["music"].ToString();
                    if (read["Image"].ToString() != string.Empty) { byte[] Image = (byte[])read["Image"]; manData.Add("Image", Image); }
                    else {manData.Add("Image", string.Empty); }
                    manData.Add("name", name);
                    manData.Add("born_date", born_date);
                    manData.Add("city", city);
                    manData.Add("height", height);
                    manData.Add("weight", weight);
                    manData.Add("hobby", hobby);
                    manData.Add("music", music);
                }
            }

            return manData;
        }

        public static string getValue(string query, string area) {
            InitializeConnection();
            string value = null;
            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                SQLiteDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    string mail = read[area].ToString();
                    value = mail;
                }
            }
            return value;
        }

        public static List<int> getIds(string query) {
            InitializeConnection();
            List<int> Ids = new List<int>();
            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                SQLiteDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    Ids.Add(read.GetInt32(0));
                }
            }
            return Ids;
        }

        public static void ExecuteUpdateWithParameters(string query, Dictionary<string, object> parameters)
        {
            InitializeConnection();

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                command.ExecuteNonQuery();
            }
        }

        public static List<Dictionary<string, object>> GetMultipleRecords(string query)
        {
            InitializeConnection();
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            using (SQLiteCommand command = new SQLiteCommand(query, _connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            object columnValue = reader.GetValue(i);
                            row.Add(columnName, columnValue);
                        }
                        results.Add(row);
                    }
                }
            }

            return results;
        }

        public static void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}