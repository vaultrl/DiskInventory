using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class Disk
    {
        public Disk()
        {
            DiskArtist = new HashSet<DiskArtist>();
        }

        public int DiskId { get; set; }
        public int? DiskTypeId { get; set; }
        public int? DiskStatusId { get; set; }
        public int? GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CdName { get; set; }

        public virtual Status DiskStatus { get; set; }
        public virtual DiskType DiskType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<DiskArtist> DiskArtist { get; set; }
    }
}
