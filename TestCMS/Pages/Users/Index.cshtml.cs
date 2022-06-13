using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace TestCMS.Pages.Users
{
    public class IndexModel : PageModel
    {
        public  List<UserInfo> userInfos = new List<UserInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM users";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserInfo info = new UserInfo();
                                info.userAccountId = reader.GetString(0);
                                info.username = reader.GetString(1);

                                userInfos.Add(info);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class UserInfo
    {
        public string userAccountId = String.Empty;
        public string username = String.Empty;
    }
}
