namespace AnotherTasks.Classes
{
    class Tasks
    {
        public long Id { get; } // идентификатор задания
        public string Title { get; set; } // название задания
        public string Description { get; set; } // описание задания
        private static long _idCounter = 1;

        public Tasks(string title, string description = "Отсутствует")
        {
            Id = _idCounter++;
            Title = title;
            Description = description;
        }

        public void PrintTask() // метод на печать информацию
        {
            Console.WriteLine($"ID: {Id}\nНазвание: {Title}\nОписание: {Description}\n");
        }
    }
}