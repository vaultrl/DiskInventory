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
            return View(diskhasborrowers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Borrowers = context.Borrower.OrderBy(b => b.Lname).ToList();
            ViewBag.Disk = context.Disk.OrderBy(d => d.CdName).ToList();
            DiskHasBorrower newcheckout = new DiskHasBorrower();
            newcheckout.BorrowDate = DateTime.Today;
            return View("Edit", newcheckout);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Borrowers = context.Borrower.OrderBy(b => b.Lname).ToList();
            ViewBag.Disks = context.Disk.OrderBy(d => d.CdName).ToList();
            var diskhasborrower = context.DiskHasBorrower.Find(id);
            return View(diskhasborrower);
        }
        [HttpPost]
        public IActionResult Edit(DiskHasBorrower diskHasBorrower)
        {
            if (ModelState.IsValid)
            {
                if (diskHasBorrower.BorrowerId == 0)
                {
                    context.Database.ExecuteSqlRaw("execute sp_ins_disk_has_borrower @p0, @p1, @p2, @p3",
                       parameters: new[] { diskHasBorrower.DiskId.ToString(), diskHasBorrower.BorrowerId.ToString(), diskHasBorrower.BorrowDate.ToString(), diskHasBorrower.ReturnDate.ToString() });
                }
                else
                {
                    context.Database.ExecuteSqlRaw("execute sp_upd_disk_has_borrower @p0, @p1, @p2, @p3, @p4",
                       parameters: new[] { diskHasBorrower.DiskHasBorrowerId.ToString(), diskHasBorrower.DiskId.ToString(), diskHasBorrower.BorrowerId.ToString(), diskHasBorrower.BorrowDate.ToString(), diskHasBorrower.ReturnDate.ToString() });
                    //@disk_has_borrower_id int, @disk_id int, @borrower_id int,
                   // @borrow_date datetime2, @return_date datetime2 = null
                }
                context.SaveChanges();
                return RedirectToAction("Index", "DiskHasBorrower");
            }
            else
            {
                ViewBag.Action = (diskHasBorrower.BorrowerId == 0) ? "Add" : "Edit";
                ViewBag.Borrowers = context.Borrower.OrderBy(b => b.Lname).ToList();
                ViewBag.Disks = context.Disk.OrderBy(d => d.CdName).ToList();
                return View(diskHasBorrower);
            }
        }
    }
}
