using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    /// <summary>
    /// Custom Attribute =>server side only
    /// </summary>
    public class UniqueNameAttribute:ValidationAttribute
    {
        public UniqueNameAttribute()
        {

        }
        public string? Message { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)//(validated value,model of the value)
        {
            //Employee? EmpFromClient = validationContext.ObjectInstance as Employee;//the employee that the client send it if u want to compare with any thing or do any thing
            if (value != null)
            {
                DataContext context = new DataContext();
                Employee? emp = context.Employees.FirstOrDefault(e => e.Name == value.ToString());
                if (emp == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(Message);
            }
            return new ValidationResult("Name is Requiored");

        }
    }
}
