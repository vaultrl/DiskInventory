using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;
using Microsoft.EntityFrameworkCore;


namespace DiskInventory.Controllers
{
    public class DiskHasBorrowerController : Controller
    {
        private disk_inventoryjcContext context { get; set; }
        public DiskHasBorrowerController(disk_inventoryjcContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var diskhasborrowers = context.DiskHasBorrower.Include(d => d.Disk).
                Include(b => b.Borrower).ToList();
            return View();
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.ArtistTypes = context.Borrower.OrderBy(b => b.Lname).ToList();
            ViewBag.Disk = context.Disk.OrderBy(d => d.DiskArtist).ToList();
            DiskHasBorrower newcheckout = new DiskHasBorrower();
            newcheckout.BorrowDate = DateTime.Today;
            return View("Edit", newcheckout);
        }

}
}
