using Microsoft.Data.SqlClient;


namespace ConsoleApp2
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;";

            string sqlExpression = "SELECT name_of_product, name_of_category FROM product_category INNER JOIN product ON product.ID_of_product = product_category.ID_of_product INNER JOIN category ON category.ID_of_category = product_category.ID_of_category";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);

                    Console.WriteLine($"{columnName1}\t{columnName2}");

                    while (await reader.ReadAsync())
                    {
                        object name_of_product = reader.GetValue(0);
                        object name_of_category = reader.GetValue(1);

                        Console.WriteLine($"{name_of_product} \t{name_of_product}");
                    }
                }

                await reader.CloseAsync();
            }
            Console.Read();
        
        }
    }
}
