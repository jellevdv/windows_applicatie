
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsApplicatie_NetteVersie.Models;

namespace WindowsApplicatie_NetteVersie
{
    static class AuthService
    {

        public static User AppUser;

        public static async Task<(User, CustomError)> Login(string email, string password)
        {
            HttpClient client = new HttpClient();
            User u = new User();
            CustomError c = new CustomError();

            try
            {
                var loginInput = new
                {
                    email = email,
                    password = password,
                };

                var stringPayload = JsonConvert.SerializeObject(loginInput);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://na2backend.azurewebsites.net/api/user", httpContent);



                if (result.Content != null)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    try
                    {
                        u = (User)JObject.Parse(responseContent);
                        AppUser = u;
                    }
                    catch
                    {
                        if (responseContent.ToLower().Contains("password"))
                        {
                            c.Scope = "password";
                            c.Message = responseContent;
                        }
                        else if (responseContent.ToLower().Contains("email"))
                        {
                            c.Scope = "email";
                            c.Message = responseContent;
                        }
                        else
                        {
                            c.Scope = "app";
                            c.Message = responseContent;
                        }
                    }
                }
            }
            catch
            {
                c.Scope = "app";
                c.Message = "Something went wrong with the connection to the server. Please contact your admin!";
            }

            return (u, c);

        }
    }


}
