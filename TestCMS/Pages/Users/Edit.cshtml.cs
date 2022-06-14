using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TestCMS.Pages.Users
{
    public class EditModel : PageModel
    {
        public UserInfo userInfo = new UserInfo();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
            string userAccountId = Request.Query["userAccountId"];
           
            try
            {
                string connectionString = Globals.DB_CONNECTION_STRING;
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM users WHERE userAccountId=@userAccountId";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userAccountId", userAccountId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userInfo.userAccountId = reader.GetString(0);
                                userInfo.username = reader.GetString(1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            userInfo.userAccountId = Request.Form["userAccountId"];
            userInfo.username = Request.Form["username"];

            if (userInfo.userAccountId.Length == 0 || userInfo.username.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }

            // Make desired changes to the specific username
            try
            {
                String connectionString = Globals.DB_CONNECTION_STRING;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE users " +
                                 "SET username=@username " +
                                 "WHERE userAccountId=@userAccountId";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@userAccountId", userInfo.userAccountId);
                        command.Parameters.AddWithValue("@username", userInfo.username);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Users/Index");
        }
    }
}
