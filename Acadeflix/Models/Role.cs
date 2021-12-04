using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Role
    {
        public Role()
        {
            Casts = new HashSet<Cast>();
        }

        public int PkIdRole { get; set; }
        public string RoleType { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }
    }
}
