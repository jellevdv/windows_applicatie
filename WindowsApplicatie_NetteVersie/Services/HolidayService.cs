
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsApplicatie_NetteVersie.Models;

namespace WindowsApplicatie_NetteVersie
{
    static class HolidayService
    {
        public static Holiday SelectedHoliday;

        public static async Task<(Holiday, CustomError)> AddHoliday(Holiday h)
        {
            HttpClient client = new HttpClient();
            CustomError c = new CustomError();
            Holiday holiday = new Holiday();

            try
            {
                var addHolidayInput = new
                {
                    appUserID = AuthService.AppUser.ID,
                    name = h.Name,
                    description = h.Description,
                    destination = h.Destination,
                    departureDate = h.DepartureDate
                };

                var stringPayload = JsonConvert.SerializeObject(addHolidayInput);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://na2backend.azurewebsites.net/api/holiday/holiday", httpContent);

                if (result.Content != null)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    try
                    {
                        holiday = (Holiday)JObject.Parse(responseContent);
                        AuthService.AppUser.Holidays.Add(holiday);
                        System.Diagnostics.Debug.WriteLine(AuthService.AppUser.Holidays.Count);
                    }
                    catch
                    {
                        if (responseContent.ToLower().Contains("[error]"))
                        {
                            c.Scope = "Error";
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

            return (holiday, c);
        }

        public static async Task<(Category, CustomError)> AddCategory(Category h)
        {
            HttpClient client = new HttpClient();
            CustomError c = new CustomError();
            Category category = new Category();

            try
            {
                var addCategoryInput = new
                {
                    appUserID = AuthService.AppUser.ID,
                    name = h.Name,
                    description = h.Description,        
                };

                var stringPayload = JsonConvert.SerializeObject(addCategoryInput);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://na2backend.azurewebsites.net/api/category/category", httpContent);

                if (result.Content != null)
                {
                    var responseContent = await result.Content.ReadAsStringAsync();
                    try
                    {
                        category = (Category)JObject.Parse(responseContent);
                        AuthService.AppUser.Categories.Add(category);
                        System.Diagnostics.Debug.WriteLine(AuthService.AppUser.Holidays.Count);
                    }
                    catch
                    {
                        if (responseContent.ToLower().Contains("[error]"))
                        {
                            c.Scope = "Error";
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

            return (category, c);
        }
    }
}
