using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}