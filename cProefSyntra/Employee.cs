using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cProefSyntra
{
    class Employee
    {
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public Employee(string first_Name, string last_Name)
        {
            FirstName = first_Name;
            LastName = last_Name;
        }

    }
}
