using System.ComponentModel.DataAnnotations;

namespace appeal_page.Models
{
    public class FormInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Mail is required.")]
        [EmailAddress(ErrorMessage = "Mail is in invalid format.")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Attending info can not be empty.")]
        public bool IsAttending { get; set; }
    }
}