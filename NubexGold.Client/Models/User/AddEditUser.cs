namespace NubexGold.Client.Models.User
{
    public class AddEditUser
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
    }
}
