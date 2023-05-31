using System;
using System.Collections.Generic;
using System.Linq;

namespace Anarchy_In_Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Patient
    {
        public Patient()
        {
            int minAge = 18;
            int maxAge = 100;
            FullName = UserUntils.GenerateRandomFullName();
            Age = UserUntils.GenerateRandomNumber(minAge, maxAge);
            Disease = UserUntils.GenerateRandomDisease();
        }

        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Пациент - {FullName} .Возраст - {Age}.Заболевание - {Disease}.");
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            CreatePatients();
        }

        public void Work()
        {
            const string CommandSortByFullName = "1";
            const string CommandSortByAge = "2";
            const string CommandSearchPatientsWithDisease = "3";
            const string CommandExit = "4";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Введите {CommandSortByFullName}, чтобы отсортировать пациентов по фамилии.");
                Console.WriteLine($"Введите {CommandSortByAge}, чтобы отсортировать пациентов по возрасту.");
                Console.WriteLine($"Введите {CommandSearchPatientsWithDisease}, чтобы вывести список пациентов по болезни.");
                Console.WriteLine($"Введите {CommandExit}, чтобы завершить работу.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSortByFullName:
                        SortByFullName();
                        break;

                    case CommandSortByAge:
                        SortByAge();
                        break;

                    case CommandSearchPatientsWithDisease:
                        SearchPatientsWithDisease();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreatePatients()
        {
            int quantityPatients = 10;

            for (int i = 0; i < quantityPatients; i++)
            {
                _patients.Add(new Patient());
            }
        }

        private void SortByFullName()
        {
            foreach (Patient patient in _patients.OrderBy(patient => patient.FullName))
            {
                patient.ShowInfo();
            }
        }

        private void SortByAge()
        {
            foreach (Patient patient in _patients.OrderBy(patient => patient.Age))
            {
                patient.ShowInfo();
            }
        }

        private void SearchPatientsWithDisease()
        {
            Console.WriteLine("Введите название заболевания: ");
            string userInput = Console.ReadLine();

            foreach (Patient patient in _patients.Where(patient => patient.Disease == userInput.ToLower()))
            {
                patient.ShowInfo();
            }
        }
    }

    class UserUntils
    {
        private static Random _random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static string GenerateRandomFullName()
        {
            string[] names = { "Алексей ", "Иван ", "Анатолий ", "Андрей ", "Евгений " };
            string[] surnames = { "Гладков ", "Маркин ", "Акишев ", "Сотсков ", "Заварницын " };
            string[] middleNames = { "Иванович", "Алексеевич", "Николаевич", "Андреевич", "Вячеславович" };
            string fullName = "";
            int quantity = 1;

            for (int i = 0; i < quantity; i++)
            {
                fullName += surnames[_random.Next(surnames.Length)];
                fullName += names[_random.Next(names.Length)];
                fullName += middleNames[_random.Next(middleNames.Length)];
            }

            return fullName;
        }

        public static string GenerateRandomDisease()
        {
            string[] narionalitys = { "простуда", "перелом", "инфаркт", "инсульт" };
            string disease = "";
            int quantity = 1;

            for (int i = 0; i < quantity; i++)
            {
                disease += narionalitys[_random.Next(narionalitys.Length)];
            }

            return disease;
        }
    }
}
