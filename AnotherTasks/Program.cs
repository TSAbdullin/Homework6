using AnotherTasks.BaseClasses;
using AnotherTasks.Classes;
using AnotherTasks.Enums;

class StartProgram
{
    public static void Main(string[] args)
    {
        Сowshed cowshed = new Сowshed("Коровник 1", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 50, 200, 100);
        Сowshed cowshed2 = new Сowshed("Коровник 2", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 100, 400, 200);
        Barn cowshed3 = new Сowshed("Коровник 3", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 150, 600, 400);
        Barn cowshed4 = new Сowshed("Коровник 4", new Dictionary<Guid, Cattle>(), new Dictionary<Guid, Staff>(), 200, 800, 600);

        Employer Oleg = new Employer("Олег", "Рихтен", new DateTime(1989, 12, 14), new Dictionary<Guid, Tasks>(), Role.Охранники);
        Employer Alena = new Employer("Алена", "Миронова", new Dictionary<Guid, Tasks>(), Role.Доярки);
        Employer Kirill = new Employer("Кирилл", new DateTime(1999, 6, 23), new Dictionary<Guid, Tasks>(), Role.Слесари);
        Employer Dmitriy = new Employer("Дмитрий", "Дмитриев", new Dictionary<Guid, Tasks>(), Role.Бригадиры);
        Employer Nikita = new Employer("Никита", new Dictionary<Guid, Tasks>(), Role.Скотники);

        Cow cow1 = new Cow("Корова1", Breed.Черно_пестрая, Gender.Самка, 15, 200);
        Cattle cow2 = new Cow("Корова2", Breed.Айрширская, Gender.Самец, 10, 100);
        Cow cow3 = new Cow("Корова3", Gender.Самец, 15, 230);

        Tasks task = new Tasks("Подоить корову1");
        Tasks task2 = new Tasks("Убрать в коровнике 1", "Зайти в коровник 1, взять и убраться");


        cowshed.AddAnimal(cow1);
        cowshed.AddAnimal(cow2);
        cowshed.AddAnimal(cow3);


        cowshed.PrintAllAnimals();

    }
}