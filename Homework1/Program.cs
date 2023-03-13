using System;
using System.Data.SqlClient;


string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Student_Grades;Integrated Security=True;";

//Task2(connString);
//Task3(connString);
Task4(connString);

void Task2(string connString)
{
    using (SqlConnection connection = new SqlConnection(connString))
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            connection?.Open();
            Console.WriteLine($"Connection status: {connection.State}");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally 
        {
            connection.Close();
        }
    }
}

void Task3 (string connString)
{
    using (SqlConnection connection = new SqlConnection(connString))
    {
        try
        {
            //в залежності від потрібного запиту, розкоментувати відповідний запит
            string query = "select * from Students_rating";
            //string query = "select Id, Firstname, Surname from Students_rating";
            //string query = "select Id, Avarage_rating from Students_rating";

            SqlDataReader reader = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            connection?.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                //в залежності від обраного запиту, розкоментувати відповідне повідомлення виводу тексту в консоль
                Console.WriteLine($"{reader["Id"]}\t{reader["Firstname"]}\t{reader["Surname"]}\t" +
                    $"{reader["Avarage_rating"]}\t{reader["Name_subject_min"]}\t{reader["Name_subject_max"]}");

                //Console.WriteLine($"{reader["Id"]}\t{reader["Firstname"]}\t{reader["Surname"]}");

                //Console.WriteLine($"{reader["Id"]}\t{reader["Avarage_rating"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}

void Task4(string connString)
{
    using (SqlConnection connection = new SqlConnection(connString))
    {
        try
        {
            //в залежності від потрібного запиту, розкоментувати відповідний запит

            //1
            //string query = "select MIN(Avarage_rating) from Students_rating";

            //2
            //string query = "select MAX(Avarage_rating) from Students_rating";

            //3
            //string query = "Select Name_subject_min from Students_rating where Name_subject_min='Math'";

            //4
            //string query = "Select Name_subject_max from Students_rating where Name_subject_min='Math'";

            ////5
            //string query = "select [Group], count(*) AS students_count from Students_rating group by [Group]";

            //6
            string group_name = "IPZm-22-2";
            string query = $"select AVG(Avarage_rating) from Students_rating where [Group] = '{group_name}'";


            SqlDataReader reader = null;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            connection?.Open();

            //в залежності від обраного запиту, розкоментувати відповідне повідомлення виводу тексту в консоль

            //1
            //int min_Avarage_rating = (int)cmd.ExecuteScalar();
            //Console.WriteLine($"Min avarage rating = {min_Avarage_rating}");

            //2
            //int max_Avarage_rating = (int)cmd.ExecuteScalar();
            //Console.WriteLine($"Max avarage rating = {max_Avarage_rating}");

            //3
            //reader = cmd.ExecuteReader();
            //int counter = 0;
            //while (reader.Read())
            //{
            //    counter++;
            //}
            //Console.WriteLine($"Quantity of students with min avarage score Math = {counter}");

            //4
            //reader = cmd.ExecuteReader();
            //int counter = 0;
            //while (reader.Read())
            //{
            //    counter++;
            //}
            //Console.WriteLine($"Quantity of students with max avarage score Math = {counter}");

            //5
            //reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine($"{reader["Group"]} = {reader["students_count"]} students");
            //}

            //6
            int avarageRating = (int)cmd.ExecuteScalar();
            Console.WriteLine($"Avarage score of {group_name} = {avarageRating}");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}