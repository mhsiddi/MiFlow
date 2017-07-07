using MiTrainer.Data.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiTrainer.Data.Account
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int PersonTypeId { get; set; }

       
        public Person(int _id, string _firstName, string _lastName, string _phone, string _email)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            Phone = _phone;
            Email = _email;
        }

        public Person()
        {
            
        }

        public static Person GetPerson(long id)
        {
            string query = "SELECT * FROM Person Where PersonID = " + id.ToString();
            List<Person> persons = new List<Person>();

            DataTable returnedData = DBHelper.GetTableData(query);

            if (returnedData != null)
            {
                for (int i = 0; i <= returnedData.Rows.Count - 1; i++)
                {
                    Person p = new Person();

                    p.Id = (int)returnedData.Rows[i]["PersonId"];
                    p.FirstName = (string)returnedData.Rows[i]["FirstName"];
                    p.LastName = (string)returnedData.Rows[i]["LastName"];
                    p.Phone = (string)returnedData.Rows[i]["Phone"];
                    p.Email = (string)returnedData.Rows[i]["Email"];
                    p.PersonTypeId = (int)returnedData.Rows[i]["PersonTypeId"];

                    persons.Add(p);
                }

            }

            return persons[0];
        }

        public static List<Person> GetPersons()
        {
            string query = "SELECT * FROM Person";
            List<Person> persons = new List<Person>();

            DataTable returnedData = DBHelper.GetTableData(query);

            if (returnedData != null)
            {
                for (int i = 0; i <= returnedData.Rows.Count - 1; i++)
                {
                    Person p = new Person();

                    p.Id = (int)returnedData.Rows[i]["PersonId"];
                    p.FirstName = (string)returnedData.Rows[i]["FirstName"];
                    p.LastName = (string)returnedData.Rows[i]["LastName"];
                    p.Phone = (string)returnedData.Rows[i]["Phone"];
                    p.Email = (string)returnedData.Rows[i]["Email"];

                    persons.Add(p);
                }

            }

            return persons;
        }

        public static bool CreatePerson(Person p)
        {
            int rowsInserted = DBHelper.InsertData("spCreatePerson", p);

            return rowsInserted > 0;
        }

        //public static List<object> GetPersonPropertiesParams(Person p)
        //{
        //    List<object> parameters = new List<object>();

        //    //parameters.Add(p.Id.ToString());
        //    parameters.Add(p.FirstName);
        //    parameters.Add(p.LastName);
        //    parameters.Add(p.Email);
        //    parameters.Add(p.Phone);
        //    parameters.Add(p.PersonTypeId.ToString());
            
        //    return parameters;
        //}
    }
}
