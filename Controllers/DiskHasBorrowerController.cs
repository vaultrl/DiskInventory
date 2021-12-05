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
        private disk_inventoryjwContext context { get; set; }
        public DiskHasBorrowerController(disk_inventoryjwContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var diskhasborrowers = context.DiskHasBorrowers.
                Include(d => d.Disk).OrderBy(d => d.Disk.DiskName).                 //Add sort here!!!
                Include(b => b.Borrower).ToList();
            return View(diskhasborrowers);
        }
        [HttpGet]
        public IActionResult Add()      //
        {
            ViewBag.Action = "Add";
            ViewBag.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            ViewBag.Disks = context.Disks.OrderBy(d=> d.DiskName).ToList();
            DiskHasBorrower newcheckout = new DiskHasBorrower();
            newcheckout.BorrowedDate = DateTime.Today;
            return View("Edit", newcheckout);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            ViewBag.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
            var diskhasborrower = context.DiskHasBorrowers.Find(id);
            return View(diskhasborrower);
        }
        [HttpPost]
        public IActionResult Edit(DiskHasBorrower diskHasBorrower)
        {
            if (ModelState.IsValid)
            {
                if (diskHasBorrower.DiskHasBorrowerId == 0)
                {
                    context.DiskHasBorrowers.Add(diskHasBorrower);
                }
                else
                {
                    context.DiskHasBorrowers.Update(diskHasBorrower);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "DiskHasBorrower");
            }
            else
            {
                ViewBag.Action = (diskHasBorrower.DiskHasBorrowerId == 0) ? "Add" : "Edit";
                ViewBag.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
                ViewBag.Disks = context.Disks.OrderBy(d => d.DiskName).ToList();
                return View(diskHasBorrower);
            }
        }
    }
}
