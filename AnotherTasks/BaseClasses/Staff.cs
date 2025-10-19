using AnotherTasks.Classes;
using AnotherTasks.Enums;

namespace AnotherTasks.BaseClasses
{
    abstract class Staff // абстрактный класс для сотрудника
    {
        public Guid Id { get; protected set; } // идентификатор сотрудника
        public string Name { get; set; } // имя сотрудника
        public string SurName { get; set; } // фамилия сотрудника
        public int Age { get; set; } // возраст сотрудника
        public Dictionary<Guid, Tasks> ListOfTasks { get; set; } // словарь, содержащий список задач работника
        public Role Role { get; set; } // роль персонала

        public void DeleteTask(Guid id) // метод на удаление задач
        {
            if (ListOfTasks.ContainsKey(id)) 
            {
                ListOfTasks.Remove(id);
                Console.WriteLine("Задача удалена!");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Задания с таким идентификатором не найдено!");
            }
        }

        public void AddTask(Tasks task) // метод для добавления задания
        {
            if (task != null)
            {
                if (!ListOfTasks.ContainsValue(task))
                {
                    ListOfTasks.Add(task.Id, task);
                    Console.WriteLine("Задание добавлено!");
                }
                else
                {
                    Console.WriteLine("Задание уже существует!");
                }
            }
            else
            {
                throw new ArgumentNullException("Задание или список задач равны null!");
            }
        }

        public void PrintAllTasks() // метод на печать задач
        {
            if (ListOfTasks.Count > 0)
            {
                foreach (var task in ListOfTasks)
                {
                    Console.WriteLine(task.Value.Title);
                }
            }
            else
            {
                Console.WriteLine("Список задач пуст!");
            }
        }
        
        public void PrintInfo() // метод на печать информации об одной задаче
        {
            Console.WriteLine($"Имя: {Name}\nФамилия: {SurName}\nВозраст: {Age}\nРоль: {Role}\nСписок задач:");
            PrintAllTasks();
        }
    }
}
