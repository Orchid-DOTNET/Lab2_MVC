using MessagePack;
using System.Diagnostics.CodeAnalysis;

namespace MVCCRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Section { get; set; }
        public string Description { get; set; }
    }
}
