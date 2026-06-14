namespace KMCEventManagement.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}