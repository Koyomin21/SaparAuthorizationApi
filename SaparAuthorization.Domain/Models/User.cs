using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Models
{
    public class User
    {
        [Column(name: "id")]
        public long Id { get; set; }

        [Column(name: "email")]
        public string Email { get; set; }

        [Column(name: "password")]
        public string Password { get; set; }

        [Column(name: "firstname")]
        public string FirstName { get; set; }

        [Column(name: "lastname")]
        public string LastName { get; set; }

        [Column(name: "isdeleted")]
        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        public bool IsVerified { get; set; } = false;

        [Column(name: "birthdate")]
        public DateOnly? BirthDate { get; set; }

        [NotMapped]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [NotMapped]

        public int VerificationCode { get; set; }

        public Role Role { get; set; }

        [Column(name: "roleid")]
        public int RoleId { get; set; }
    }
}
