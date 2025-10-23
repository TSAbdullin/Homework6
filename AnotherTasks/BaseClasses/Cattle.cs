using AnotherTasks.Enums;

namespace AnotherTasks.BaseClasses
{
    abstract class Cattle // абстрактный класс рогатого скота
    {
        public long Id { get; protected set; } // идентификатор
        public string Name { get; set; } // имя 
        public Gender Gender { get; set; } // пол
        public int Age { get; set; } // возраст
        public double Weight { get; set; } // вес

        public abstract void MakeSound(); // метод на издавание звука

        public abstract void PrintInfo(); // метод на печать информации
    }
}