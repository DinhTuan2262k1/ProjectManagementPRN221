using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;

namespace ProjectManagementPRN221
{
    /// <summary>
    /// Chứa những hàm xử lý database chung cho tất cả
    /// kết nối
    /// executequẻy
    /// </summary>
    public class DataProvider
    {
        //Khai bao cac thanh phan ket noi va xu ly DB
        SqlConnection cnn; //Ket noi DB
        SqlDataAdapter da; //Xu ly cac cau lenh SQL: Select
        SqlCommand cmd; //Thuc thi cau lenh insert,update,delete

        public DataProvider()
        {
            connect();
        }
        private string getConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            connectionString = config["ConnectionStrings:MyDB"];
            return connectionString;
        }
        private void connect()
        {
            try
            {
                string strCnn = getConnectionString();
                cnn = new SqlConnection(strCnn);
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cnn.Open();
                Console.WriteLine("Connect success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi ket noi:" + ex.Message);
            }
        }

        //Hàm execute 1 câu lệnh select
        public DataTable executeQuery(string strSelect)
        {
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(strSelect, cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Execute fail:" + ex.Message);
            }
            return dt;
        }

        //Hàm execute câu lệnh insert,update,delete
        public bool executeNonQuery(string strSQL)
        {
            try
            {
                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();   
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert/Update/Delete error:"+ex.Message);
                return false;
            }
            return true;
        }

        public IDataReader executeQuery2(string commandText, params SqlParameter[] parameters)
        {
            IDataReader reader = null;
            try
            {
                cmd = new SqlCommand(commandText, cnn);
                if(parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                reader = cmd.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reader;
        }

        public bool ExecuteNonQuery2 (string commandText, params SqlParameter[] parameters)
        {
            try
            {
                var command = new SqlCommand(commandText, cnn);
                command.CommandType = CommandType.Text;
                if(parameters != null)
                {
                    foreach(var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                    return true;
                }
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;

        }
    }
}
