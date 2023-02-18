using SaparAuthorization.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace SaparAuthorization.Api.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-_]).{8,}$")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsValid()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            if(!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (var errors in results)
                {
                    Console.WriteLine("Error {0}", errors);
                }
                return false;
            }

            return true;
        }
    }
}
