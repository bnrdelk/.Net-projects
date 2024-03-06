using System.ComponentModel.DataAnnotations;

namespace efcore_page.Data
{
    // table in database 
    public class Student 
    {
        // id => primary key
        [Key] // if you write [ClassName]Id you dont need to add
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public string? StudentSurname { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}