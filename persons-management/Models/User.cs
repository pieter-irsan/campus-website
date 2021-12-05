namespace persons_management.Models
{
    public class User
    {
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set { this.username = value; }
        }
        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }
    }
}