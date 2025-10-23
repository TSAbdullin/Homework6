using AnotherTasks.BaseClasses;
using AnotherTasks.Enums;

namespace AnotherTasks.Classes
{
    class Cow : Cattle
    {
        public Breed Breed { get; set; } // порода
        private static long _idCounter = 1;

        public Cow(string name, Breed breed, Gender gender, int age)
        {
            Id = _idCounter++;
            Name = name;
            Gender = gender;
            Age = age;
            Breed = breed;
        }

        public Cow(string name, Gender gender, int age, double weight)
        {
            Id = _idCounter++;
            Name = name;
            Gender = gender;
            Age = age;
            Weight = weight;
        }

        public override void PrintInfo() // метод для печати
        {
            Console.WriteLine($"ID: {Id}\nИмя: {Name}\nПол: {Gender}\nПорода: {Breed}\nВозраст: {Age}\n");
        }

        public override void MakeSound() // корова издает звук
        {
            Console.WriteLine($"{Name}: Mууу\n");
        }
    }
}