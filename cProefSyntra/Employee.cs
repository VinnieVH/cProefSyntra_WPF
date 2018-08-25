using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cProefSyntra
{
    public class Employee
    {
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }


        public Employee(string first_Name, 
                        string last_Name, 
                        string job_Title, 
                        string email, 
                        string password, 
                        bool isAdmin)
        {
            FirstName = first_Name;
            LastName = last_Name;
            JobTitle = job_Title;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }

        public void Login()
        {
            var credential = MongoCredential.CreateMongoCRCredential("test", "user1", "password1");

            var settings = new MongoClientSettings
            {
                Credentials = new[] { credential }
            };

            var mongoClient = new MongoClient(settings);
        }
    }
}


