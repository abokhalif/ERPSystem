namespace Demo.Models
{
    public class EmployeeWithExtraInfoViewModel
    {
        // Extra Info
        public string Message { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
        public List<string> Branches { get; set; }

        // needed properties from Model (dont define an Model property it cause problems)
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
