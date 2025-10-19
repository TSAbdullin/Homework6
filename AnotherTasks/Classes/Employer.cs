using AnotherTasks.BaseClasses;
using AnotherTasks.Enums;
using System.Data;

namespace AnotherTasks.Classes
{
    class Employer : Staff 
    {
        public Employer(string  name, string surname, DateTime birthday, Dictionary<Guid, Tasks> ListOfTasks, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surname;
            Age = DateTime.Now.Year - birthday.Year;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, string surname, Dictionary<Guid, Tasks> ListOfTasks, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surname;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, DateTime birthday, Dictionary<Guid, Tasks> ListOfTasks, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = DateTime.Now.Year - birthday.Year;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, Dictionary<Guid, Tasks> ListOfTasks, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
            this.ListOfTasks = ListOfTasks;
        }
    }
}
