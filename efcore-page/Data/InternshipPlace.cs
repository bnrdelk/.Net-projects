using System.ComponentModel.DataAnnotations;

namespace efcore_page.Data
{
    public class InternshipPlace
    {
        public int InternshipPlaceId { get; set; }

        public string? Title { get; set; }
    }
}