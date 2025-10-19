using AnotherTasks.Enums;

namespace AnotherTasks.BaseClasses
{
    abstract class Cattle // абстрактный класс рогатого скота
    {
        public Guid Id { get; protected set; } // идентификатор
        public string Name { get; set; } // имя 
        public string Breed { get; set; } // порода
        public string Gender { get; set; } // пол
        public int Age { get; set; } // возраст
        public double Weight { get; set; } // вес
        public Color Color { get; set; } // цвет

        public abstract void MakeSound(); // метод на издавание звука
        public abstract void Feed(); // метод на покушать

        public void PrintInfo() // метод на печать информации
        {
            Console.WriteLine($"ID: {Id}\nИмя: {Name}\nПорода: {Breed}\nПол: {Gender}\nВозраст: {Age}\nВес:{Weight}\nЦвет: {Color}\n");
        }
    }
}
