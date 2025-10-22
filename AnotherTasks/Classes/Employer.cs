using AnotherTasks.BaseClasses;
using AnotherTasks.Enums;
using System.Data;

namespace AnotherTasks.Classes
{
    class Employer : Staff 
    {
        private static long _idCounter = 1;

        public Employer(string  name, string surname, DateTime birthday, Dictionary<long, Tasks> ListOfTasks, Role role)
        {
            Id = _idCounter++;
            Name = name;
            SurName = surname;
            Age = DateTime.Now.Year - birthday.Year;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, string surname, Dictionary<long, Tasks> ListOfTasks, Role role)
        {
            Id = _idCounter++;
            Name = name;
            SurName = surname;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, DateTime birthday, Dictionary<long, Tasks> ListOfTasks, Role role)
        {
            Id = _idCounter++;
            Name = name;
            Age = DateTime.Now.Year - birthday.Year;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, Dictionary<long, Tasks> ListOfTasks, Role role)
        {
            Id = _idCounter++;
            Name = name;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }
    }
}
