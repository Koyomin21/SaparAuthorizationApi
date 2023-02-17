using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Business.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsVerified { get; set; }

        public DateOnly BirthDate { get; set; }

        public DateTime CreateDate { get; set; }

        public int VerificationCode { get; set; }

        public RoleModel Role { get; set; }

    }
}
