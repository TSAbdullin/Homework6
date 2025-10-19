namespace AnotherTasks.BaseClasses
{
    abstract class Cattle // абстрактный класс рогатого скота
    {
        public Guid Id { get; } // идентификатор
        public string Name { get; set; } // имя 
        public string Breed { get; set; } // порода
        public string Gender { get; set; } // пол
        public int Age { get; set; } // возраст
        public double Weight { get; set; } // вес
        public string Color { get; set; } // цвет

        public abstract void MakeSound(); // метод на издавание звука
        public abstract void Feed(); // метод на покушать
    }
}
