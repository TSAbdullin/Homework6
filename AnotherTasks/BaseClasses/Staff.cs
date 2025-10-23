using AnotherTasks.Classes;
using AnotherTasks.Enums;

namespace AnotherTasks.BaseClasses
{
    abstract class Staff // абстрактный класс для сотрудника
    {
        public long Id { get; protected set; } // идентификатор сотрудника
        public string Name { get; set; } // имя сотрудника
        public string SurName { get; set; } // фамилия сотрудника
        public int Age { get; set; } // возраст сотрудника
        public Dictionary<long, Tasks> ListOfTasks { get; set; } // словарь, содержащий список задач работника
        public Role Role { get; set; } // роль персонала
        

        public void DeleteTask(long id) // метод на удаление задач
        {
            if (ListOfTasks.ContainsKey(id)) 
            {
                ListOfTasks.Remove(id);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Задача удалена!\n");
                Console.ResetColor();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Задания с таким идентификатором не найдено!\n");
            }
        }

        public void FeedAll() // покормить 
        {
            if (Role.Equals(Role.Доярки))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} покормил всех животных\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Роль {Role} не позволяет {Name} покормить животных\n");
                Console.ResetColor();
            }
        }

        public void AddTask() // метод для добавления задания
        {
            Console.Write("Введите название задачи: ");
            string titleTask = Console.ReadLine();

            if (titleTask == null || titleTask == String.Empty)
            {
                throw new ArgumentNullException("Название задачи не может быть пустым!\n");
            }

            Console.Write("Введите описание задач: ");
            string descriptionTask = Console.ReadLine();

            var task = new Tasks(titleTask, descriptionTask);
            
            ListOfTasks.Add(task.Id, task);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание успешно добавлено\n");
            Console.ResetColor();
        }

        public void PrintAllTasks() // метод на печать задач
        {
            if (ListOfTasks.Count > 0)
            {
                foreach (var task in ListOfTasks)
                {
                    Console.WriteLine($"{task.Key}: {task.Value.Title}");
                }
            }
            else
            {
                Console.WriteLine("Список задач пуст!\n");
            }
        }
        
        public void PrintInfo() // метод на печать информации об одной задаче
        {
            Console.WriteLine($"Имя: {Name}\nФамилия: {SurName}\nВозраст: {Age}\nРоль: {Role}\nСписок задач:");
            PrintAllTasks();
        }
    }
}