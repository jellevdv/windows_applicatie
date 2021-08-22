
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
                        if (responseContent.ToLower().Contains("[error]"))
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
            }
            catch
            {
                c.Scope = "app";
                c.Message = "Something went wrong with the connection to the server. Please contact your admin!";
            }

            return (u, c);

        }

        public static async Task<(User, CustomError)> Register(string email, string firstn, string lastn, string phone, string password, string passwordC, DateTimeOffset date)
        {
            HttpClient client = new HttpClient();
            User u = new User();
            CustomError c = new CustomError();

            try
            {
                var registerInput = new
                {
                    email = email,
                    password = password,
                    firstName = firstn,
                    lastName = lastn,
                    phone = phone,
                    passwordConfirmation = passwordC,
                    dateOfBirth = date
                };

                var stringPayload = JsonConvert.SerializeObject(registerInput);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://na2backend.azurewebsites.net/api/user/register", httpContent);



                if (result.Content != null)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    try
                    {
                        u = (User)JObject.Parse(responseContent);

                        //JsonConvert.DeserializeObject<User>(json);
                        AppUser = u;
                    }
                    catch
                    {
                        if (responseContent.ToLower().Contains("[error]"))
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
            }
            catch
            {
                c.Scope = "app";
                c.Message = "Something went wrong with the connection to the server. Please contact your admin!";
            }

            return (u, c);

        }

        public static async Task<(User, CustomError)> AddHoliday(string email, string firstn, string lastn, string phone, string password, string passwordC, DateTimeOffset date)
        {
            HttpClient client = new HttpClient();
            User u = new User();
            CustomError c = new CustomError();

            try
            {
                var registerInput = new
                {
                    email = email,
                    password = password,
                    firstName = firstn,
                    lastName = lastn,
                    phone = phone,
                    passwordConfirmation = passwordC,
                    dateOfBirth = date
                };

                var stringPayload = JsonConvert.SerializeObject(registerInput);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://na2backend.azurewebsites.net/api/user/register", httpContent);



                if (result.Content != null)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    try
                    {
                        u = (User)JObject.Parse(responseContent);

                        //JsonConvert.DeserializeObject<User>(json);
                        AppUser = u;
                    }
                    catch
                    {
                        if (responseContent.ToLower().Contains("[error]"))
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
