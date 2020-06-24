using ConvertNumberToWords.Domain.Models;
using ConvertNumberToWords.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data.SqlClient;


namespace ConvertNumberToWords.Database
{
    public class DB : ICommunicateWithDB
    {

        IConfiguration Configuration;

        public DB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string GetInsertQuery(string inputNumber, string convertedText)
        {
            return $@"
                        INSERT INTO ConvertedNumbers(InputNumber, OutputText) VALUES({inputNumber}, '{convertedText}')";
        }

        public ResultValue<string> InsertToDB(string inputNumber, string convertedText)
        {
            try
            {
                string connectionString = Configuration.GetSection("NumberToWordsSettings").GetSection("ConnectionString").Value;
                var con = new SqlConnection(connectionString);
                var cmd = new SqlCommand(GetInsertQuery(inputNumber, convertedText), con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Result.Ok<string>();
            }catch(Exception ex)
            {
                return Result.Failed<string>(Error.CreateFrom("DatabaseError", ErrorType.DatabaseError, ex.Message));
            }
        }
    }
}
