using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppPhonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Phonebook phonebook = Phonebook.Instance;

            //Phonebook p = new Phonebook(); //not working -- everything is okay

            // добавление абонента
            phonebook.AddAbonent("1234567", "Иванов");
            phonebook.AddAbonent("7654321", "Петров");
            phonebook.AddAbonent("8748586", "Emily");

            // получение абонента по номеру телефона
            Abonent abonent = phonebook.GetAbonentByPhoneNumber("1234567");
            if (abonent != null)
            {
                Console.WriteLine(abonent.Name + ": " + abonent.PhoneNumber);
            }
            else
            {
                Console.WriteLine("Абонент с таким номером телефона не найден.");
            }

            // получение номера телефона по имени абонента
            string phoneNumber = phonebook.GetPhoneNumberByName("Петров");
            if (phoneNumber != null)
            {
                Console.WriteLine("Петров: " + phoneNumber);
            }
            else
            {
                Console.WriteLine("Абонент с таким именем не найден.");
            }

            // удаление абонента
            phonebook.DeleteAbonent("1234567");

            // получение всех абонентов
            Console.WriteLine("Телефонная книга:");
            if (phonebook.Abonents != null)
            {
                if (phonebook.Abonents.Count != 0)
                {
                    foreach (Abonent a in phonebook.Abonents)
                    {
                        Console.WriteLine(a.Name + ": " + a.PhoneNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("Empty");
            }
            
            Console.ReadLine();
        }
    }
}