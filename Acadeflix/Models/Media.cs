using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Media
    {
        public int PkIdMedia { get; set; }
        public int FkIdContent { get; set; }
        public string MediaType { get; set; }
        public string MediaUrl { get; set; }

        public virtual Content FkIdContentNavigation { get; set; }
    }
}
