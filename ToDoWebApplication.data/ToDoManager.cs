using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToDoWebApplication.data
{
    public class ToDoManager
    {
        private string _connectionString;
        public ToDoManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetCategories()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Categories";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category
                {
                    Name = (string)reader["Name"],
                    Id = (int)reader["Id"]
                };
                categories.Add(category);
            }
            return categories;
        }
        public IEnumerable<ToDo> GetToDos(int? categoryId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT td.*, c.Name FROM ToDos td JOIN Categories c ON c.Id = td.CategoryId";
            if (categoryId > 0)
            {
                command.CommandText += " WHERE td.CategoryId = @categoryId";
                command.Parameters.AddWithValue("@categoryId", categoryId);
            }
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ToDo> toDos = new List<ToDo>();
            while (reader.Read())
            {
                ToDo toDo = new ToDo
                {
                    Title = (string)reader["Title"],
                    Description = (string)reader["Description"],
                    DueDate = (DateTime)reader["DueDate"],
                    IsCompleted = (bool)reader["Completed"],
                    CategoryId = (int)reader["CategoryId"],
                    Category = (string)reader["Name"]
                };
                toDos.Add(toDo);
            }
            return toDos;
        }
        
    }
}
