namespace Outlook_Project
{
    internal class UserDetails
    {
        string Email;
        string Password;

        public string email
        {
            get { return Email; }
            set { Email = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password=value; }
        }
    }
}