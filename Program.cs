using System;
using System.Data.SqlClient;
namespace Sams.Hwork.Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = @"Data source = DESKTOP-SS5TGJO\SQLEXPRESS; initial catalog = Person; Integrated security = true;";
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Succesfully Connected to Person");
                }
                Console.WriteLine(@"Please choose action: 
                                 1. Select all
                                 2. Insert
                                 3. Select By Id
                                 4. Update 
                                 5. Delete ");

                SqlCommand Alif = connection.CreateCommand();
                int siroyat = Convert.ToInt32(Console.ReadLine());
                switch (siroyat)
                {
                    case 1:
                        Alif.CommandText = $"Select * from Person";
                        var reader = Alif.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["ID"]}, LastName: {reader["LastName"]}, " +
                                $"FirstName: {reader["FirstName"]}, MiddleName: {reader["MiddleName"]}, BirthDate: {reader["BirthDate"]}, ");
                        }
                        break;
                    case 2:
                        var LastName = ConsoleReadLineWithText("Enter LastName");
                        var FirstName = ConsoleReadLineWithText("Enter FirstName");
                        var MiddleName = ConsoleReadLineWithText("Enter MiddleName");
                        var BirthDate = ConsoleReadLineWithText("Enter BirthDate");

                        Alif.CommandText = "Insert into Person(" +
                            "LastName," +
                            "FirstName," +
                            "MiddleName," +
                            "BirthDate ) Values(" +
                            $"'{LastName}'," +
                            $"'{FirstName}'," +
                            $"'{MiddleName}'," +
                            $"'{BirthDate}')"
                            ;
                        var Javob = Alif.ExecuteNonQuery();
                        if (Javob > 0)
                        {

                            Console.WriteLine("Person successfully added!");

                        }
                        break;
                    case 3:
                        int amalsozi = Convert.ToInt32(Console.ReadLine());
                        Alif.CommandText = $"select * from person where id = {amalsozi}";
                        var Jursozii2 = Alif.ExecuteReader();

                        while (Jursozii2.Read())
                        {
                            Console.WriteLine($"ID: {Jursozii2["ID"]}, LastName: {Jursozii2["LastName"]}, " +
                                $"FirstName: {Jursozii2["FirstName"]}, MiddleName: {Jursozii2["MiddleName"]}, BirthDate: {Jursozii2["BirthDate"]},");
                        }
                        break;
                    case 4:
                        var updateLastName = ConsoleReadLineWithText("Enter LastName");
                        var updateFirstName = ConsoleReadLineWithText("Enter FirstName");
                        var updateMiddleName = ConsoleReadLineWithText("Enter MiddleName");
                        var updateBirthDate = ConsoleReadLineWithText("Enter BirthDate");
                        var updateID = ConsoleReadLineWithText("Enter ID");

                        Alif.CommandText = "update Person set " +
                            "LastName = " + $"'{updateLastName}'," +
                            "FirstName =  " + $"'{updateFirstName}'," +
                            "MiddleName = " + $"'{updateMiddleName}'," +
                            "BirthDate = " + $"'{updateBirthDate}'" +
"where id = " + $"'{updateID}'"
                            ;
                        var result1 = Alif.ExecuteNonQuery();
                        if (result1 > 0)
                        {
                            Console.WriteLine("Person successfully updated!");
                        }
                        break;
                    case 5:
                        var delete = ConsoleReadLineWithText("Delete ID");
                        Alif.CommandText = $"delete from Person where id = {delete}";
                        var reader4 = Alif.ExecuteNonQuery();
                        if (reader4 > 0)
                        {
                            Console.WriteLine("Person deleted Succesfully");
                        }
                        break;
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Disconnected");
            }
            Console.ReadKey();
        }
        public static string ConsoleReadLineWithText(string text)
        {
            Console.Write($"{text}:");
            return Console.ReadLine();
        }
    }

}
    