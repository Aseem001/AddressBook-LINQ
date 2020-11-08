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
    using System.Text;

    public class AddressBookDataTable
    {
        /// <summary>
        /// UC 1 : Created new address book table
        /// </summary>
        public static DataTable addressBookTable = new DataTable();

        /// <summary>
        /// UC 2 : Adds the data into table.
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

            //Adding First Name and Last name as primary key
            DataColumn[] primaryKeys = new DataColumn[2];
            primaryKeys[0] = addressBookTable.Columns["FirstName"];
            primaryKeys[1] = addressBookTable.Columns["LastName"];
            addressBookTable.PrimaryKey = primaryKeys;
        }
    }
}
