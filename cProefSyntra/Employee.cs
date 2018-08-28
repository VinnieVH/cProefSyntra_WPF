using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        [BsonId]
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
            MongoClient client = new MongoClient("mongodb://VincentVH:Vincent159Derp@ds217560.mlab.com:17560/c-proef_syntra");

            /// Testing DB code (needs to be replaced)
            var db = client.GetDatabase("c-proef_syntra");
            var collection = db.GetCollection<Employee>("employees");
        }

        public void Register()
        {
            /// Register logic goes here

        }

        public void ResetPassword()
        {
            /// Reset Password logic goes here
        }
    }
}


