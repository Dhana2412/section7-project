using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace section7.Models
{
    [Table("StudentMarks")]
    public class StudentMarks
    {
        [Key]
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
       
        public string? Subject { get; set; }
        public int Marks { get; set; }

    }
}
