namespace Task5_NEW.Models
{
    public class FixModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Task { get; set; }
        public string Auditory { get; set; }
        public string Job { get; set; }
        public FixModel(string firstName, string secondName, string lastName, string task, string auditory, string job)
        {
            FirstName= firstName;
            SecondName= secondName;
            LastName= lastName;
            Task = task;
            Auditory = auditory;
            Job = job;
        }
    }
}
