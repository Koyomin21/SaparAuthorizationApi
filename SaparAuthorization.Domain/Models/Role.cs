using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Models
{
    public class Role
    {
        [Column(name:"id")]
        public int ID { get; set; }

        [Column(name:"rolename")]
        public string RoleName { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
