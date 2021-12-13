using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiskInventory.Models
{
    public partial class DiskHasBorrower
    {
        public int DiskHasBorrowerId { get; set; }
        public string BorrowStatus { get; set; }
        [Required]
        public int? DiskId { get; set; }
        [Required]
        public int BorrowerId { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Disk Disk { get; set; }
    }
}
