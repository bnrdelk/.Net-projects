namespace appeal_page.Models
{
    public class FormInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public bool IsAttending { get; set; }
    }
}