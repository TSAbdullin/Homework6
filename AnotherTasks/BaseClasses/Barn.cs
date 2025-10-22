using AnotherTasks.Classes;
using AnotherTasks.Enums;
using System.Net.Http.Headers;

namespace AnotherTasks.BaseClasses
{
    abstract class Barn // абстрактный класс для коровника
    {
        public long Id { get; protected set; } // идентификатор коровника
        public string Title { get; set; } // наименование коровника
        public Dictionary<long, Cattle> AmountOfCurrentAnimals { get; set; } // текущее количество животных
        public Dictionary<long, Staff> Employers { get; set; } // персонал коровника 
        public int AmountOfFeeders { get; set; } // количество кормушек
        public double Square { get; set; } // площадь коровника
        public int MaxCapacityOfAnimals { get; set; } // масимальная вместимость в коровник

        public void AddAnimal() // метод, который добавляет животное в коровник
        {
            if (AmountOfCurrentAnimals.Count < MaxCapacityOfAnimals)
            {
                Console.Write("Введите имя животного: ");
                var cowName = Console.ReadLine();

                Console.WriteLine("\nСписок пород: ");
                for (int i = 0; i <= 9; i++)
                {
                    Console.WriteLine((Breed)i);
                }

                Console.WriteLine();

                Console.Write("Введите породу: ");

                if (!Enum.TryParse(Console.ReadLine(), out Breed cowBreed))
                {
                    throw new FormatException("Такой породы нет!");
                }

                Console.Write("Введите пол животного(самка, самец): ");

                if (!Enum.TryParse(Console.ReadLine(), out Gender cowGender))
                {
                    throw new FormatException("Такого пола не существует!");
                }

                Console.Write("Введите возраст(число): ");

                if (!int.TryParse(Console.ReadLine(), out int cowAge))
                {
                    throw new FormatException("Неверный формат возраста");
                }

                var animal = new Cow(cowName, cowBreed, cowGender, cowAge);

                AmountOfCurrentAnimals.Add(animal.Id, animal);
                Console.WriteLine($"Животное {animal.Name} успешно добавлено в коровник {Title}\n");
            }
            else if (AmountOfCurrentAnimals.Count == MaxCapacityOfAnimals)
            {
                throw new ArgumentOutOfRangeException($"Коровник {Title} переполнен! Добавить животное не удалось!\n");
            }
        }

        public void AddAnimal(Cattle animal)
        {
            if (animal != null)
            {
                if (AmountOfCurrentAnimals.Count < MaxCapacityOfAnimals)
                {
                    AmountOfCurrentAnimals.Add(animal.Id, animal);
                    Console.WriteLine($"Животное {animal.Name} успешно добавлено в коровник {Title}\n");
                }
                else if (AmountOfCurrentAnimals.Count == MaxCapacityOfAnimals)
                {
                    throw new ArgumentOutOfRangeException($"Коровник {Title} переполнен! Добавить животное не удалось!\n");
                }
            }
        }

        public void DeleteAnimal() // метод для удаления животных
        {
            if (IsContainAnimalsAndPrintAllAnimals())
            {
                Console.Write("Введите ID животного: ");

                if (!long.TryParse(Console.ReadLine(), out long id))
                {
                    throw new FormatException("Неверный формат");
                }

                if (AmountOfCurrentAnimals.ContainsKey(id))
                {
                    AmountOfCurrentAnimals.TryGetValue(id, out Cattle anim);
                    Console.WriteLine($"Животное {anim.Name} успешно удалено из коровника {Title}\n");
                    AmountOfCurrentAnimals.Remove(id);
                }
                else
                {
                    throw new ArgumentException("Животное с таким ID не найдено!\n");
                }
            }
        }

        public bool IsContainAnimalsAndPrintAllAnimals() // метод для печати животных
        {
            if (AmountOfCurrentAnimals.Count > 0)
            {
                foreach (var animal in AmountOfCurrentAnimals)
                {
                    Console.WriteLine($"Id: {animal.Value.Id}\nПол: {animal.Value.Gender}\n" +
                        $"Возраст: {animal.Value.Age}\n\n");
                }
                return true;
            } else
            {
                Console.WriteLine("Животных нет!\n");
                return false;
            }
        }

        public void AddStaff()
        {
            Console.Write("Введите имя сотрудника: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя не может быть пустым.");

            Console.Write("Введите фамилию: ");
            var surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
                throw new ArgumentNullException("Фамилия не может быть пустой.");

            Console.Write("Введите роль сотрудника(Бригадиры, Доярки, Скотники, Слесари, Охранники): ");
            if (!Enum.TryParse<Role>(Console.ReadLine(), true, out var role))
            {
                Console.WriteLine("Некорректная роль. По умолчанию будет Без роли.");
                role = Role.Без_роли;
            }

            Console.Write("Введите дату рождения (формат YYYY.MM.DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var birthday))
                throw new FormatException("Неверный формат даты.");

            var employer = new Employer(name: name, surname: surname, birthday: birthday, ListOfTasks: new Dictionary<long, Tasks>(), role: role);

            if (Employers.ContainsKey(employer.Id))
            {
                Console.WriteLine($"{employer.Name} {employer.SurName} уже есть в списке.");
                return;
            }

            Employers.Add(employer.Id, employer);
            Console.WriteLine($"Принят: {employer.Name} {employer.SurName}, роль: {employer.Role}, возраст: {employer.Age}");
        }

        public void AddStaff(Staff staff)
        {
            if (!Employers.ContainsKey(staff.Id))
            {
                Employers.Add(staff.Id, staff);
                Console.WriteLine($"Работник {staff.Name} устроился в {Title}");
            }
            else
            {
                Console.WriteLine($"{staff.Name} уже работает в {Title}");
            }
        }

        public void DeleteStaff()
        {
            if (IsContainStaffAndPrintAllStaff())
            {
                Console.Write("Введите ID персонала: ");
                bool isChoosen = false;
                while (!isChoosen)
                {
                    if (!long.TryParse(Console.ReadLine(), out long idStaff))
                    {
                        throw new FormatException("Введено не число");
                    }

                    if (Employers.ContainsKey(idStaff))
                    {
                        isChoosen = true;
                        Console.WriteLine($"Персонал с ID {idStaff} уволен!");
                        Employers.Remove(idStaff);
                    }
                    else
                    {
                        Console.WriteLine($"Персонала с ID {idStaff} не найдено!");
                    }
                }
            }
        }

        public bool IsContainStaffAndPrintAllStaff()
        {
            if (Employers.Count > 0)
            {
                foreach (var staff in Employers)
                {
                    Console.WriteLine($"Id: {staff.Value.Id}\nИмя: {staff.Value.Name}\nРоль: {staff.Value.Role}\n");
                }
                return true;
            }
            else
            {
                Console.WriteLine("Персонала нет!\n");
                return false;
            }
        }

        public void SelectStaff()
        {
            IsContainStaffAndPrintAllStaff();

            Console.Write("Введите ID сотрудника: ");

            if (!long.TryParse(Console.ReadLine(), out long idStaff))
            {
                throw new FormatException("Неверный формат");
            }

            if (Employers.ContainsKey(idStaff))
            {
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Удалить задачу");
                Console.WriteLine("3. Вывести список задач");
                Console.WriteLine("4. Покормить животных");


                Console.Write("Введите номер действия:");

                if (!int.TryParse(Console.ReadLine(), out int action))
                {
                    throw new FormatException("Неверный формат!");
                }

                if (action < 1 || action > 4)
                {
                    throw new ArgumentOutOfRangeException("Такого действия не существует!");
                }

                Employers.TryGetValue(idStaff, out Staff employee);

                switch(action)
                {
                    case 1:
                        employee.AddTask();
                        break;

                    case 2:
                        employee.PrintAllTasks();

                        if (!long.TryParse(Console.ReadLine(), out long idOfTask))
                        {
                            throw new FormatException("Введено не число!");
                        }

                        employee.DeleteTask(idOfTask);
                        break;

                    case 3:
                        employee.PrintAllTasks();
                        break;

                    case 4:
                        employee.FeedAll();
                        break;

                    default:
                        Console.WriteLine("Такой команды нет!");
                        break;
                }
            }
        }
    }
}
