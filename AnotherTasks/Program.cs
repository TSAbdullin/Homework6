using AnotherTasks.BaseClasses;
using AnotherTasks.Classes;
using AnotherTasks.Enums;

class StartProgram
{
    public static void Main(string[] args)
    {
        Dictionary<string, Barn> barns = new Dictionary<string, Barn>();

        var cowshed = new Cowshed("Коровник 1", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 50, 200, 100);
        var cowshed2 = new Cowshed("Коровник 2", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 100, 400, 200);
        var cowshed3 = new Cowshed("Коровник 3", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 150, 600, 400);
        var cowshed4 = new Cowshed("Коровник 4", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 200, 800, 600);
        barns.Add(cowshed.Title, cowshed);
        barns.Add(cowshed2.Title, cowshed2);
        barns.Add(cowshed3.Title, cowshed3);
        barns.Add(cowshed4.Title, cowshed4);



        var Oleg = new Employer("Олег", "Рихтен", new DateTime(1989, 12, 14), new Dictionary<Guid, Tasks>(), Role.Охранники);
        var Alena = new Employer("Алена", "Миронова", new Dictionary<Guid, Tasks>(), Role.Доярки);
        var Kirill = new Employer("Кирилл", new DateTime(1999, 6, 23), new Dictionary<Guid, Tasks>(), Role.Слесари);
        var Dmitriy = new Employer("Дмитрий", "Дмитриев", new Dictionary<Guid, Tasks>(), Role.Бригадиры);
        var Nikita = new Employer("Никита", new Dictionary<Guid, Tasks>(), Role.Скотники);

        var cow1 = new Cow("Корова1", Breed.Черно_пестрая, Gender.Самка, 15, 200);
        var cow2 = new Cow("Корова2", Breed.Айрширская, Gender.Самец, 10, 100);
        var cow3 = new Cow("Корова3", Gender.Самец, 15, 230);

        var task = new Tasks("Подоить корову1");
        var task2 = new Tasks("Убрать в коровнике 1", "Зайти в коровник 1, взять и убраться");



        Console.Write("Введите действие: ");
        string text = Console.ReadLine().ToLower();
        bool isContinue = true;

        while (isContinue)
        {
            switch(text)
            {
                case "выбрать коровник":
                    ChooseBarn();
                    break;

                default:
                    break;
        }
            }

        void ChooseBarn()
        {
            foreach(var cowshed in barns)
            {
                Console.WriteLine($"{cowshed.Key}: {cowshed.Value.Title}");
            }

            Console.WriteLine("Введите название коровника: ");
            string title = Console.ReadLine();

            if (barns.ContainsKey(title))
            {
                
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Убрать сотрудника");
                Console.WriteLine("3. Добавить животное");
                Console.WriteLine("4. Удалить животное");
                Console.WriteLine("5. Вывести список всех животных");
                Console.Write("Введите номер действия: ");

                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    switch(num)
                    {
                        case 1:
                            barns.TryGetValue(title, out var bar);
                            bar.AddStaff();
                            break;
                    }
                }


            }
            else
            {
                Console.WriteLine("Такого коровника не сущесвует!");
            }
        }
    }
}