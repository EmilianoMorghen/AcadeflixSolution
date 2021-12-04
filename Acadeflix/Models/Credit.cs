using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Credit
    {
        public Credit()
        {
            Casts = new HashSet<Cast>();
        }

        public int PkIdCredit { get; set; }
        public string Name { get; set; }
        public string Sirname { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }
    }
}
