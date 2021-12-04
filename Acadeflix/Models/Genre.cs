using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Genre
    {
        public int PkIdGenre { get; set; }
        public int FkIdContent { get; set; }
        public string GenreType { get; set; }

        public virtual Content FkIdContentNavigation { get; set; }
    }
}
