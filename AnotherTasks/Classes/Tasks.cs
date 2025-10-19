namespace AnotherTasks.Classes
{
    class Tasks
    {
        public Guid Id { get; } // идентификатор задания
        public string Title { get; set; } // название задания
        public string Description { get; set; } // описание задания

        public Tasks(string title, string description = "Отсутствует")
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
        }
    }
}
