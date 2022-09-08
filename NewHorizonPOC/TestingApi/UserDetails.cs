namespace TestingApi
{
    public class UserDetails
    {
        public int userId { get; set; }

        public string firstName { get; set;}

        public string lastName { get; set;}

        public string address { get; set;}

        public string postCode { get; set;}

        public string email { get; set;}

        public DateTime dateOfBirth { get; set;}

        public string? jobTitle { get; set; }

        public string? profileImage { get; set; }

        public DateTime creationDate { get; set; }
    }
}