using DapperApp.Library1.Models;
using DapperApp.Library1.Queries;
using System;

namespace DapperApp.ConsoleUI
{
    internal class Program
    {
        static PersonQueries personQueries = new PersonQueries();
        static int PersonId;
        static void Main(string[] args)
        {
            //https://github.com/btkacademy/csharp-basic
            //https://github.com/btkacademy/design-patterns
            //https://www.learndapper.com
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz (1-List,2-Create,3-Update,4-Delete)");
            string request = Console.ReadLine();
            switch (request)
            {
                case "1":
                    WritePersonList();
                    break;
                case "2":
                    CreatePerson();
                    break;
                case "3":
                    UpdatePerson();
                    break;
                case "4":
                    DeletePerson(PersonId);
                    break;
                default: Console.WriteLine("Yanlış seçim yaptınız tekrar seçim yapınız"); break;
            }
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
            WritePersonList();
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
        //Filtreli listeleme yapılabilir (Adı x ile başlayanları listelesin gibi ...)
        static void FindPerson(int id)
        {
            var Person = personQueries.Find(PersonId);
            Console.WriteLine("Id = {0}, Adı = {1}, Soyad = {2}",
                Person.Id,
                Person.Name,
                Person.Surname);
        }
        static void UpdatePerson()
        {
            WritePersonList();
            Console.Write("Güncellenecek Kişinin Id si: ");
            PersonId = Convert.ToInt32(Console.ReadLine());
            FindPerson(PersonId);
            Console.Write("Güncellenen Ad: ");
            string newName = Console.ReadLine();
            Console.Write("Güncellenen Soyad: ");
            string newSurName = Console.ReadLine();
            personQueries.Update(PersonId, newName, newSurName);
            WritePersonList();
        }
        static void DeletePerson(int PersonId)
        {
            WritePersonList();
            Console.Write("Silinecek kişinin Id si: ");
            PersonId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kişiyi silmek istediğinize emin misiniz?: (yes/no)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                personQueries.Delete(PersonId);
                Console.WriteLine("Kişi Silindi");

            }
            else if (answer == "no")
            {
                Console.WriteLine("İşlem iptal edildi");
            }
            else
            {
                Console.WriteLine("Yanlış seçim tekrar deneyiniz.");
            }
            WritePersonList();
        }


    }
}
