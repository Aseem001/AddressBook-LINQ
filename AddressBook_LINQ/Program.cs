// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Aseem Anand"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBook_LINQ
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book manager!");
            AddressBookDataTable.AddDataIntoTable();
        }
    }
}
