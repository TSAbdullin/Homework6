using AnotherTasks.Classes;
using AnotherTasks.Enums;

namespace AnotherTasks.BaseClasses
{
    abstract class Barn // абстрактный класс для коровника
    {
        public Guid Id { get; protected set; } // идентификатор коровника
        public string Title { get; set; } // наименование коровника
        public Dictionary<Guid, Cattle> AmountOfCurrentAnimals { get; set; } // текущее количество животных
        public Dictionary<Guid, Staff> Employers { get; set; } // персонал коровника 
        public int AmountOfFeeders { get; set; } // количество кормушек
        public double Square { get; set; } // площадь коровника
        public int MaxCapacityOfAnimals { get; set; } // масимальная вместимость в коровник

        public void AddAnimal(Cattle animal) // метод, который добавляет животное в коровник
        {
            if (animal != null)
            {
                if (AmountOfCurrentAnimals.Count < MaxCapacityOfAnimals && !AmountOfCurrentAnimals.ContainsKey(animal.Id))
                {
                    AmountOfCurrentAnimals.Add(animal.Id, animal);
                    Console.WriteLine($"Животное {animal.Name} успешно добавлено в коровник {Title}\n");
                }
                else if (AmountOfCurrentAnimals.Count == MaxCapacityOfAnimals)
                {
                    throw new ArgumentOutOfRangeException($"Коровник {Title} переполнен! Добавить животное {animal.Name} не удалось!\n");
                }
                else if (AmountOfCurrentAnimals.ContainsKey(animal.Id))
                {

                    throw new ArgumentException($"Животное {animal.Name} уже существует в коровнике {Title}\n");
                }
            }
            else
            {
                throw new ArgumentNullException("Животное или текущее количество животных недоступно!\n");
            }
        }

        public void DeleteAnimal(Guid id) // метод для удаления животных
        {
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

        public void PrintAllAnimals() // метод для печати животных
        {
            if (AmountOfCurrentAnimals.Count > 0)
            {
                foreach (var animal in AmountOfCurrentAnimals)
                {
                    Console.WriteLine($"Id: {animal.Value.Id}\nПол: {animal.Value.Gender}\n" +
                        $"Возраст: {animal.Value.Age}\nВес: {animal.Value.Weight}\n");
                }
            } else
            {
                Console.WriteLine("Животных нет!\n");
            }
        }

        public void AddStaff()
        {
            //if (!Employers.ContainsKey(staff.Id))
            //{
            //    Employers.Add(staff.Id, staff);
            //    Console.WriteLine($"Работник {staff.Name} устроился в {Title}");
            //}
            //else
            //{
            //    Console.WriteLine($"{staff.Name} уже работает в {Title}");
            //}

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

            var employer = new Employer(name: name, surname: surname, birthday: birthday, ListOfTasks: new Dictionary<Guid, Tasks>(), role: role);

            if (Employers.ContainsKey(employer.Id))
            {
                Console.WriteLine($"{employer.Name} {employer.SurName} уже есть в списке.");
                return;
            }

            Employers.Add(employer.Id, employer);
            Console.WriteLine($"Принят: {employer.Name} {employer.SurName}, роль: {employer.Role}, возраст: {employer.Age}");
        }
      

        public void PrintAllStaff()
        {
            if (Employers.Count > 0)
            {
                foreach (var staff in Employers)
                {
                    Console.WriteLine($"Id: {staff.Value.Id}\nИмя: {staff.Value.Name}\nРоль: {staff.Value.Role}\n");
                }
            }
            else
            {
                Console.WriteLine("Животных нет!\n");
            }
        }
    }
}
