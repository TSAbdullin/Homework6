using AnotherTasks.BaseClasses;
using AnotherTasks.Classes;
using AnotherTasks.Enums;

class StartProgram
{
    private static long idCounterBarn = 1;

    public static void Main(string[] args)
    {

        Dictionary<long, Barn> barns = new Dictionary<long, Barn>();

        var cowshed1 = new Cowshed("Коровник 1", new Dictionary<long, Cattle>(), new Dictionary<long, Staff>(), 50, 200, 100);
        var cowshed2 = new Cowshed("Коровник 2", new Dictionary<long, Cattle>(), new Dictionary<long, Staff>(), 100, 400, 200);
        var cowshed3 = new Cowshed("Коровник 3", new Dictionary<long, Cattle>(), new Dictionary<long, Staff>(), 150, 600, 400);
        var cowshed4 = new Cowshed("Коровник 4", new Dictionary<long, Cattle>(), new Dictionary<long, Staff>(), 200, 800, 600);
        barns.Add(idCounterBarn++, cowshed1);
        barns.Add(idCounterBarn++, cowshed2);
        barns.Add(idCounterBarn++, cowshed3);
        barns.Add(idCounterBarn++, cowshed4);


        var Oleg = new Employer("Олег", "Рихтен", new DateTime(1989, 12, 14), new Dictionary<long, Tasks>(), Role.Охранники);
        var Alena = new Employer("Алена", "Миронова", new Dictionary<long, Tasks>(), Role.Доярки);
        var Kirill = new Employer("Кирилл", new DateTime(1999, 6, 23), new Dictionary<long, Tasks>(), Role.Слесари);
        var Dmitriy = new Employer("Дмитрий", "Дмитриев", new Dictionary<long, Tasks>(), Role.Бригадиры);
        var Nikita = new Employer("Никита", new Dictionary<long, Tasks>(), Role.Скотники);

        var cow1 = new Cow("Корова1", Breed.Черно_пестрая, Gender.Самка, 15);
        var cow2 = new Cow("Корова2", Breed.Айрширская, Gender.Самец, 10);
        var cow3 = new Cow("Корова3", Gender.Самец, 15, 230);

        cowshed1.AddAnimal(cow1);
        cowshed1.AddAnimal(cow2);
        cowshed1.AddStaff(Oleg);
        cowshed1.AddStaff(Alena);


        var task = new Tasks("Подоить корову1");
        var task2 = new Tasks("Убрать в коровнике 1", "Зайти в коровник 1, взять и убраться");


        

        bool isContinue = true;

        while (isContinue)
        {
            Console.WriteLine("Список действий:\n" +
            "1. Выбрать коровник\n" +
            "2. Удалить коровник\n" +
            "3. Добавить коровник\n" +
            "4. Выход\n");

            Console.Write("Введите номер действия: ");
            if (!byte.TryParse(Console.ReadLine(), out var action))
            {
                throw new FormatException("Введенные параметр не число!");
            }

            if (action > 4 || action < 1)
            {
                throw new ArgumentOutOfRangeException("Такого действия нет!");
            }

            switch (action)
            {
                case 1:
                    ChooseBarn();
                    break;

                case 2:
                    DeleteBarn();
                    break;

                case 3:
                    AddCowshed();
                    break;

                case 4:
                    isContinue = false;
                    break;

                default:
                    Console.WriteLine("Такой команды нет!");
                    break;
            }
        }

        void PrintAllBarns()
        {
            foreach (var cowshed in barns)
            {
                Console.WriteLine($"{cowshed.Key}: {cowshed.Value.Title}");
            }
        }

        void ChooseBarn()
        {
            PrintAllBarns();

            Console.Write("Введите номер коровника: ");
            if (!long.TryParse(Console.ReadLine(), out var keyOfBarn))
            {
                throw new FormatException("Не число!");
            }

            if (barns.ContainsKey(keyOfBarn))
            {

                Console.WriteLine("\n1. Добавить сотрудника");
                Console.WriteLine("2. Убрать сотрудника");
                Console.WriteLine("3. Выбрать сотрудника");
                Console.WriteLine("4. Вывести всех сотрудников");
                Console.WriteLine("5. Добавить животное");
                Console.WriteLine("6. Удалить животное");
                Console.WriteLine("7. Вывести список всех животных\n");
                Console.Write("Введите номер действия: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine();
                    barns.TryGetValue(keyOfBarn, out var bar);
                    switch (num)
                    {
                        case 1:
                            bar.AddStaff();
                            break;

                        case 2:
                            bar.DeleteStaff();
                            break;

                        case 3:
                            bar.SelectStaff();
                            break;

                        case 4:
                            bar.IsContainStaffAndPrintAllStaff();
                            break;

                        case 5:
                            bar.AddAnimal();
                            break;

                        case 6:
                            bar.DeleteAnimal();
                            break;

                        case 7:
                            bar.IsContainAnimalsAndPrintAllAnimals();
                            break;

                        default:
                            Console.WriteLine("Такой команды нет!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого коровника не сущесвует!");
            }
        }

        void DeleteBarn()
        {
            Console.WriteLine("Список всех коровников в формате(ID: Коровник)");

            PrintAllBarns();

            Console.Write("Введите номер коровника: ");
            if (!long.TryParse(Console.ReadLine(), out var keyOfBarn))
            {
                throw new FormatException("Не число!");
            }

            if (barns.ContainsKey(keyOfBarn))
            {
                Console.WriteLine($"Коровник снесен!");
                barns.Remove(keyOfBarn);
            }
            else
            {
                Console.WriteLine($"{keyOfBarn} не найден!");
            }
        }

        void AddCowshed()
        {
            Console.Write("Введите название коровника: ");
            string titleOfCowshed = Console.ReadLine();

            Console.Write("Введите число кормушек: ");

            if (!int.TryParse(Console.ReadLine(), out int amountOfFeeders))
            {
                throw new FormatException("Неверный формат!");
            }


            Console.Write("Введите площадь(число): ");

            if (!int.TryParse(Console.ReadLine(), out int square))
            {
                throw new FormatException("Неверный формат!");
            }

            Console.Write("Введите максимальную вместимость животных: ");

            if (!int.TryParse(Console.ReadLine(), out int maxCapacity))
            {
                throw new FormatException("Неверный формат!");
            }

            var cowshed = new Cowshed(titleOfCowshed, new Dictionary<long, Cattle>(), new Dictionary<long, Staff>(), amountOfFeeders, square, maxCapacity );
        
            barns.Add(cowshed.Id, cowshed);
            return;
        }
    }
}