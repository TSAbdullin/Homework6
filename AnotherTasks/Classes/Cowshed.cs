using AnotherTasks.BaseClasses;

namespace AnotherTasks.Classes
{
    class Cowshed : Barn
    {
        private static long _idCounter = 1;
        public Cowshed(string title, Dictionary<long, Cattle> amountOfCurrentAnimals, Dictionary<long, Staff> employers, int amountOfFeeders, double square, int maxCapacityOfAnimals)
        {
            Id = _idCounter++;
            Title = title;
            AmountOfCurrentAnimals = amountOfCurrentAnimals;
            Employers = employers;
            AmountOfFeeders = amountOfFeeders;
            Square = square;
            MaxCapacityOfAnimals = maxCapacityOfAnimals;
        }
    }
}
