using System;
using System.Collections.Generic;

#nullable disable

namespace Acadeflix.Models
{
    public partial class Content
    {
        public Content()
        {
            Casts = new HashSet<Cast>();
            CatalogFkIdParentNavigations = new HashSet<Catalog>();
            Genres = new HashSet<Genre>();
            InverseFkIdPreviousNavigation = new HashSet<Content>();
            Media = new HashSet<Media>();
            Openeds = new HashSet<Opened>();
            Preferreds = new HashSet<Preferred>();
        }

        public int PkIdContent { get; set; }
        public int? FkIdPrevious { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public int ContentType { get; set; }
        public TimeSpan Runtime { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual Content FkIdPreviousNavigation { get; set; }
        public virtual Catalog CatalogFkIdContentNavigation { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Catalog> CatalogFkIdParentNavigations { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Content> InverseFkIdPreviousNavigation { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public virtual ICollection<Opened> Openeds { get; set; }
        public virtual ICollection<Preferred> Preferreds { get; set; }
    }
}
