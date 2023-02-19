using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppPhonebook
{
    public class Abonent
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }

    public sealed class Phonebook
    {
        private static Phonebook instance = null;
        private static readonly object padlock = new object();
        private List<Abonent> abonents = new List<Abonent>();
        public List<Abonent> Abonents
        {
            get { return abonents; }
        }

        private Phonebook()
        {
            ReadFromFile();
        }

        public static Phonebook Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Phonebook();
                    }
                    return instance;
                }
            }
        }

        public void AddAbonent(string phoneNumber, string name)
        {
            if (!AbonentExists(phoneNumber))
            {
                abonents.Add(new Abonent { PhoneNumber = phoneNumber, Name = name });
                WriteToFile();
            }
        }

        public void DeleteAbonent(string phoneNumber)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                if (abonents[i].PhoneNumber == phoneNumber)
                {
                    abonents.RemoveAt(i);
                    WriteToFile();
                    break;
                }
            }
        }

        public Abonent GetAbonentByPhoneNumber(string phoneNumber)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                if (abonents[i].PhoneNumber == phoneNumber)
                {
                    return abonents[i];
                }
            }
            return null;
        }

        public string GetPhoneNumberByName(string name)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                if (abonents[i].Name == name)
                {
                    return abonents[i].PhoneNumber;
                }
            }
            return null;
        }

        private void ReadFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader("phonebook.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            abonents.Add(new Abonent { PhoneNumber = parts[0], Name = parts[1] });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: " + ex.Message);
            }
        }

        private void WriteToFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("phonebook.txt"))
                {
                    foreach (Abonent abonent in abonents)
                    {
                        sw.WriteLine(abonent.PhoneNumber + "," + abonent.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }

        private bool AbonentExists(string phoneNumber)
        {
            for (int i = 0; i < abonents.Count; i++)
            {
                if (abonents[i].PhoneNumber == phoneNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
