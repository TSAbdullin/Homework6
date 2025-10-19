using AnotherTasks.BaseClasses;

namespace AnotherTasks.Classes
{
    class Employer : Staff 
    {
        public Employer(string  name, string surname, DateTime birthday)
        {
            Name = name;
            SurName = surname;
            Age = DateTime.Now.Year - birthday.Year;
        }

        public Employer(string name, string surname)
        {
            Name = name;
            SurName = surname;
        }
    }
}
