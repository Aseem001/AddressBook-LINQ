// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBookDataTable.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBook_LINQ
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public class AddressBookDataTable
    {
        /// <summary>
        /// UC 1 : Created new address book table
        /// </summary>
        public static DataTable addressBookTable = new DataTable();

        /// <summary>
        /// UC 2,3 : Adds the data into table.
        /// </summary>
        public static void AddDataIntoTable()
        {
            //Adding columns into datatable
            addressBookTable.Columns.Add("FirstName", typeof(string));
            addressBookTable.Columns.Add("LastName", typeof(string));
            addressBookTable.Columns.Add("Address", typeof(string));
            addressBookTable.Columns.Add("City", typeof(string));
            addressBookTable.Columns.Add("State", typeof(string));
            addressBookTable.Columns.Add("Zip", typeof(int));
            addressBookTable.Columns.Add("PhoneNumber", typeof(double));
            addressBookTable.Columns.Add("Email", typeof(string));

            //Adding First Name and Last name as composite primary key
            DataColumn[] primaryKeys = new DataColumn[2];
            primaryKeys[0] = addressBookTable.Columns["FirstName"];
            primaryKeys[1] = addressBookTable.Columns["LastName"];
            addressBookTable.PrimaryKey = primaryKeys;

            //Creating rows and adding data into rows
            addressBookTable.Rows.Add("Virat", "Kohli", "Chinnaswamy", "Bengaluru", "Karnataka", 444556, 6785674567, "vk@gmail.com");
            addressBookTable.Rows.Add("Rohit", "Sharma", "Wankhede", "Mumbai", "Maharashtra", 345267, 2345678987, "rs@gmail.com");
            addressBookTable.Rows.Add("Saurabh", "Ganguly", "Eden Gardens", "Kolkata", "West Bengal", 987654, 3456787654, "sg@gmail.com");
            addressBookTable.Rows.Add("Virendra", "Sehwag", "Firoz Shah Kotla", "New Delhi", "New Delhi", 234566, 6543456789, "vs@gmail.com");
            addressBookTable.Rows.Add("AB", "DeVilliers", "Chinnaswamy", "Bengaluru", "Karnataka", 444556, 3456787654, "abd@gmail.com");
            addressBookTable.Rows.Add("Yuzvendra", "Chahal", "Chinnaswamy", "Bengaluru", "Karnataka", 444556, 3456787654, "yc@gmail.com");
        }

        /// <summary>
        /// Displays the table contents.
        /// </summary>
        public static void DisplayTableContents()
        {
            foreach (var v in addressBookTable.AsEnumerable())
            {
                Console.WriteLine($"FirstName:{v.Field<string>("FirstName")}\nLastName:{v.Field<string>("LastName")}\nAddress:{v.Field<string>("Address")}\nCity:{v.Field<string>("City")}\nState:{v.Field<string>("State")}\nZip:{v.Field<int>("Zip")}\nPhoneNumber:{v.Field<double>("PhoneNumber")}\nEmail:{v.Field<string>("Email")}\n");
            }
        }

        /// <summary>
        /// UC 4 : Edits the existing contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="zip">The zip.</param>
        public static void EditExistingContact(string firstName,string lastName,int zip)
        {                                 
            (from p in addressBookTable.AsEnumerable()
             where p.Field<string>("FirstName") == firstName && p.Field<string>("LastName") == lastName
             select p).ToList().ForEach(x => x[5] = zip);            
        }

        /// <summary>
        /// UC 5 : Deletes the contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public static void DeleteContact(string firstName, string lastName)
        {
            //Retrieve the datarow containing given name
            var retrievedData = (from p in addressBookTable.AsEnumerable()
                     where p.Field<string>("FirstName") == firstName && p.Field<string>("LastName") == lastName
                     select p).FirstOrDefault();
            //Delete the row
            retrievedData.Delete();            
        }

        /// <summary>
        /// UC 6 : Retrieves the person from a city or state.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        public static void RetrievePersonFromACityOrState(string city,string state)
        {
            var retrievedData = (from p in addressBookTable.AsEnumerable()
                                 where p.Field<string>("City") == city || p.Field<string>("State") == state
                                 select p);
            foreach(var v in retrievedData)
            {
                Console.WriteLine($"FirstName:{v.Field<string>("FirstName")}\nLastName:{v.Field<string>("LastName")}\nAddress:{v.Field<string>("Address")}\nCity:{v.Field<string>("City")}\nState:{v.Field<string>("State")}\nZip:{v.Field<int>("Zip")}\nPhoneNumber:{v.Field<double>("PhoneNumber")}\nEmail:{v.Field<string>("Email")}\n");
            }
        }

        /// <summary>
        /// UC 7 : Gets the state/city and number of people in that city/state.
        /// </summary>
        public static void GetCountOfContactInCityOrState()
        {
            Console.WriteLine("Enter:\n1.For city\n2.For state");
            int option = Convert.ToInt32(Console.ReadLine());         
            switch (option)
            {
                case 1:
                    var retrievedCityData = (from p in addressBookTable.AsEnumerable()
                                         group p by p.Field<string>("City") into g
                                         select new { City = g.Key, Count = g.Count() });
                    foreach (var v in retrievedCityData)
                    {
                        Console.WriteLine($"City:{v.City},Count:{v.Count}");
                    }
                    break;
                case 2:
                    var retrievedStateData = (from p in addressBookTable.AsEnumerable()
                                         group p by p.Field<string>("State") into g
                                         select new { State = g.Key, Count = g.Count() });
                    foreach (var v in retrievedStateData)
                    {
                        Console.WriteLine($"State:{v.State},Count:{v.Count}");
                    }
                    break;
            }            
        }
    }
}
