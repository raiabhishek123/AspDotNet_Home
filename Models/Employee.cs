using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String Name { get; set; }
        public int Salary   { get; set; }

        public int Age { get; set; }
    }
}
