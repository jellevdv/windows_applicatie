using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public Address[] Addresses { get; set; }
        //public Medical[] Medicals { get; set; }
        //public Emergency[] Emergencies { get; set; }
        public List<Holiday> Holidays { get; set; }
        public List<Category> Categories { get; set; }

        public User() { }

        public User(string firstName, string lastName, string token)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Token = token;
        }

        public User(string json)
        {
            JObject j = JObject.Parse(json);
            Token = (string)j["token"];
            Email = (string)j["user"]["email"];

        }

        public static explicit operator User(JObject v)
        {
            User u = new User();

            try
            {
                u.ID = (int)v["id"];
                u.Token = (string)v["token"];
                u.Email = (string)v["email"];
                u.FirstName = (string)v["firstname"];
                u.LastName = (string)v["lastName"];
                u.Phone = (string)v["phone"];
                u.Country = (string)v["country"];
                u.Nationality = (string)v["nationality"];
                u.DateOfBirth = (DateTime)v["dateOfBirth"];

                u.Holidays = new List<Holiday>();

                foreach (var d in v["holidays"].Children())
                {
                    Holiday h = (Holiday)d;
                    u.Holidays.Add(h);
                }

                u.Categories = new List<Category>();

                foreach (var d in v["categories"].Children())
                {
                    Category c = (Category)d;
                    u.Categories.Add(c);
                }

            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong mapping the logged in user...!");
                throw new Exception();
            }

            return u;
        }
    }
}
