namespace BlazorUserProfileApp.Shared
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public byte[]? Image { get; set; }  // Store image as a byte array
    }
}

