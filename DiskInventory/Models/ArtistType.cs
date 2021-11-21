using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class ArtistType
    {
        public ArtistType()
        {
            Artist = new HashSet<Artist>();
        }

        public int ArtistTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Artist> Artist { get; set; }
    }
}
