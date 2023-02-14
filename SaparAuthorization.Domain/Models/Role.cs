using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Models
{
    public class Role
    {
        public int id { get; set; }
        public string roleName { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
