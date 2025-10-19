using AnotherTasks.BaseClasses;

namespace AnotherTasks.Classes
{
    class Сowshed : Barn
    {
        public Сowshed(string title, Dictionary<Guid, Cattle> amountOfCurrentAnimals, Dictionary<Guid, Staff> employers, int amountOfFeeders, double square, int maxCapacityOfAnimals)
        {
            Id = Guid.NewGuid();
            Title = title;
            AmountOfCurrentAnimals = amountOfCurrentAnimals;
            Employers = employers;
            AmountOfFeeders = amountOfFeeders;
            Square = square;
            MaxCapacityOfAnimals = maxCapacityOfAnimals;
        }
    }
}
