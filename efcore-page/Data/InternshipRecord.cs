using System.ComponentModel.DataAnnotations;

namespace efcore_page.Data
{
    public class InternshipRecord
    {
        [Key]
        public int RecordId { get; set; }

        public int StudentId { get; set; }

        public int InternshipPlaceId { get; set; }

        public DateTime RecordDate { get; set; }

        // recordid 1 => studentid 5,  placeid 3
    }
}