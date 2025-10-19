namespace AnotherTasks.BaseClasses
{
    abstract class Barn // абстрактный класс для коровника
    {
        public Guid Id { get; protected set; } // идентификатор коровника
        public string Title { get; set; } // наименование коровника
        public Dictionary<Guid, Cattle> AmountOfCurrentAnimals { get; set; } // текущее количество животных
        public Dictionary<Guid, Staff> Employers { get; set; } // персонал коровника 
        public int AmountOfFeeders { get; set; } // количество кормушек
        public double Square { get; set; } // площадь коровника
        public int MaxCapacityOfAnimals { get; set; } // масимальная вместимость в коровник

        public void AddAnimal(Cattle animal) // метод, который добавляет животное в коровник
        {
            if (animal != null)
            {
                if (AmountOfCurrentAnimals.Count < MaxCapacityOfAnimals && !AmountOfCurrentAnimals.ContainsKey(animal.Id))
                {
                    AmountOfCurrentAnimals.Add(animal.Id, animal);
                    Console.WriteLine($"Животное {animal.Name} успешно добавлено в коровник {Title}");
                }
                else if (AmountOfCurrentAnimals.Count == MaxCapacityOfAnimals)
                {
                    throw new ArgumentOutOfRangeException($"Коровник {Title} переполнен! Добавить животное {animal.Name} не удалось!");
                }
                else if (AmountOfCurrentAnimals.ContainsKey(animal.Id))
                {

                    throw new ArgumentException($"Животное {animal.Name} уже существует в коровнике {Title}");
                }
            }
            else
            {
                throw new ArgumentNullException("Животное или текущее количество животных недоступно!");
            }
        }

        public void DeleteAnimal(Guid id) // метод для удаления животных
        {
            if (AmountOfCurrentAnimals.ContainsKey(id))
            {
                AmountOfCurrentAnimals.TryGetValue(id, out Cattle anim);
                Console.WriteLine($"Животное {anim.Name} успешно удалено из коровника {Title}");
                AmountOfCurrentAnimals.Remove(id);
            }
            else
            {
                throw new ArgumentException("Животное с таким ID не найдено!");
            }
        }

        public void PrintAllAnimals() // метод для печати животных
        {
            if (AmountOfCurrentAnimals.Count > 0)
            {
                foreach (var animal in AmountOfCurrentAnimals)
                {
                    Console.WriteLine($"Id: {animal.Value.Id}\nПорода: {animal.Value.Breed}\nПол: {animal.Value.Gender}\n" +
                        $"Возраст: {animal.Value.Age}\nВес: {animal.Value.Weight}\nЦвет: {animal.Value.Color}\n");
                }
            } else
            {
                Console.WriteLine("Животных нет!");
            }
        }
    }
}
