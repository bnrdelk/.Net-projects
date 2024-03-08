using System.ComponentModel.DataAnnotations;

namespace efcore_page.Data
{
    public class InternshipRegister
    {
        [Key]
        public int RecordId { get; set; }

        public int StudentId { get; set; } // foreign key
        public Student Student { get; set; } = null!; // navigation property

        public int InternshipPlaceId { get; set; }
        public InternshipPlace InternshipPlace { get; set; } = null!; // navigation property

        public DateTime RecordDate { get; set; }

        // recordid 1 => studentid 5,  placeid 3
    }
}