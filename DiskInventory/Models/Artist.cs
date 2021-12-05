using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class Artist
    {
        public Artist()
        {
            DiskArtist = new HashSet<DiskArtist>();
        }

        public int ArtistId { get; set; }
        [Required]
        public int? ArtistTypeId { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ArtistType ArtistType { get; set; }
        public virtual ICollection<DiskArtist> DiskArtist { get; set; }
    }
}
