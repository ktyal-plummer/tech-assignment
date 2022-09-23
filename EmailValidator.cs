using System.Globalization;
using System.Text.RegularExpressions;

namespace TechAssignment
{
    /// <summary>
    /// Allows for emails to be validated and holds the necessary valid & invalid emails list
    /// </summary>
    class EmailValidator
    {
        List<string> validEmails = new List<string>();
        List<string> invalidEmails = new List<string>();

        public EmailValidator() {}

        /// <summary>
        /// Sorts a given email address as valid or invalid
        /// </summary>
        /// <param name="email">The email to be validated</param>
        public void validate(string email)
        {
            if (isValidEmail(email))
            {
                validEmails.Add(email);
            } else
            {
                invalidEmails.Add(email);
            }
        }

        /// <summary>
        /// Makes sure a given email has the correct format. Source: https://learn.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// </summary>
        /// <param name="email">The string containing an email</param>
        /// <returns>Whether or not the given email was valid</returns>
        private bool isValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
               
            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
   
        /// <returns>The list of valid email addresses</returns>
        public List<string> getValidEmails()
        {
            return validEmails;
        }

        /// <returns>The list of invalid email addresses</returns>
        public List<string> getInvalidEmails()
        {
            return invalidEmails;
        }
    }
}