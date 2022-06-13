using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace TestCMS.Pages.Users
{
    public class CreateModel : PageModel
    {
        public UserInfo userInfo = new UserInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public Guid freshGuiId;
        public void OnGet()
        {
            freshGuiId = Guid.NewGuid();
            userInfo.userAccountId = freshGuiId.ToString();
        }

        public void OnPost()
        {
            userInfo.userAccountId = Request.Form["userAccountId"];
            userInfo.username = Request.Form["username"];
            
            if (userInfo.userAccountId.Length == 0 || userInfo.username.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save the new client into the database
            try
            {
                String connectionString = Globals.CONNECTION_STRING;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Users" +
                                 "(userAccountId, username) VALUES " +
                                 "(@userAccountId, @username);";
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

            userInfo.username = string.Empty;
            userInfo.userAccountId = string.Empty;
            successMessage = "New User Added Successfully";

            Response.Redirect("/Users/Index");
        }
    }
}
