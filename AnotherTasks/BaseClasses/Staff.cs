using AnotherTasks.Classes;

namespace AnotherTasks.BaseClasses
{
    abstract class Staff // абстрактный класс для сотрудника
    {
        public Guid Id { get; } // идентификатор сотрудника
        public string Name { get; set; } // имя сотрудника
        public string SurName { get; set; } // фамилия сотрудника
        public int Age { get; set; } // возраст сотрудника
        public Dictionary<Guid, Tasks> ListOfTasks { get; set; } // словарь, содержащий список задач работника

        public void DeleteTask(Guid id) // метод на удаление задач
        {
            if (id != null && ListOfTasks != null && ListOfTasks.ContainsKey(id)) 
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
            if (task != null && ListOfTasks != null)
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
                throw new ArgumentException("Задание или список задач равны null!");
            }
        }

    }
}
