using AnotherTasks.BaseClasses;
using AnotherTasks.Enums;

namespace AnotherTasks.Classes
{
    class Cow : Cattle
    {
        public Cow(string name, string breed, string gender, int age, double weight, Color color)
        {
            Id = Guid.NewGuid();
            Name = name;
            Gender = gender;
            Age = age;
            Weight = weight;
            Color = color;
            Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name}: Mууу");
        }

        public override void Feed()
        {
            Console.WriteLine($"Корова {Name} покушала сено!");
        }
    }
}
