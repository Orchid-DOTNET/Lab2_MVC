using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [NotNull, Required]
        public string Name { get; set; }
        [NotNull]
        public string Section { get; set; }
    }
}