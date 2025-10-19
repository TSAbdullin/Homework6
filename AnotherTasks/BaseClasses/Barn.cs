using AnotherTasks.Structs;

namespace AnotherTasks.BaseClasses
{
    abstract class Barn // абстрактный класс для коровника
    {
        public string Name { get; set; } // наименование коровника
        public Coordinates Coordinates { get; set; } // координаты коровника
        public Dictionary<Guid, Cattle> AmountOfCurrentAnimals { get; set; } // текущее количество животных
        public Dictionary<Guid, Staff> Employers { get; set; } // персонал коровника 
        public int AmountOfFeeders { get; set; } // количество кормушек
        public double Square { get; set; } // площадь коровника
    }
}
