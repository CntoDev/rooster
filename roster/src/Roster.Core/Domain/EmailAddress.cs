using System.Net.Mail;

namespace Roster.Core.Domain
{
    public class EmailAddress
    {
        public string Email { get; private set;}

        public EmailAddress(string email)
        {
            EmailAddress.Validate(email);

            Email = email;
        }

        // Validate email address format.
        public static bool Validate(string email)
        {
            if (!string.IsNullOrEmpty(email))
                new MailAddress(email);
                
            return true;
        }

        public override string ToString() => Email;
    }
}