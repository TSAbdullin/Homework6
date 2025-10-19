using AnotherTasks.BaseClasses;

namespace AnotherTasks.Classes
{
    class Employer : Staff 
    {
        public Employer(string  name, string surname, DateTime birthday, Dictionary<Guid, Tasks> ListOfTasks)
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surname;
            Age = DateTime.Now.Year - birthday.Year;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, string surname, Dictionary<Guid, Tasks> ListOfTasks)
        {
            Id = Guid.NewGuid();
            Name = name;
            SurName = surname;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, Dictionary<Guid, Tasks> ListOfTasks, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = DateTime.Now.Year - birthday.Year;
            this.ListOfTasks = ListOfTasks;
        }

        public Employer(string name, Dictionary<Guid, Tasks> ListOfTasks)
        {
            Id = Guid.NewGuid();
            Name = name;
            this.ListOfTasks = ListOfTasks;
        }
    }
}
