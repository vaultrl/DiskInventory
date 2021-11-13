using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class DiskArtist
    {
        public int DiskArtistId { get; set; }
        public int? ArtistId { get; set; }
        public int? DiskId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Disk Disk { get; set; }
    }
}
