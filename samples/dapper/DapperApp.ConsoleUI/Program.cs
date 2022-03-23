using DapperApp.Library1.Models;
using DapperApp.Library1.Queries;
using System;

namespace DapperApp.ConsoleUI
{
    internal class Program
    {
        static PersonQueries personQueries = new PersonQueries();

        static void Main(string[] args)
        {
            //https://www.learndapper.com
            CreatePerson();
            WritePersonList();
        }

        static void CreatePerson()
        {
            Person person = new Person();

            Console.Write("Adı = ");
            person.Name = Console.ReadLine();
            Console.Write("Soyadı = ");
            person.Surname = Console.ReadLine();

            personQueries.CreatePerson(person);
            Console.WriteLine("Kayıt eklendi id = {0}", person.Id);
        }
        static void WritePersonList()
        {
            var persons = personQueries.GetPersons();

            foreach (var person in persons)
            {
                Console.WriteLine("Id = {0}, Adı = {1}, Soyad = {2}",
                    person.Id,
                    person.Name,
                    person.Surname);
            }
        }

        //Update, Delete methodları yazılacak
    }
}
