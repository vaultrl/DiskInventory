using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class DiskController : Controller
    {
        private disk_inventoryjcContext context { get; set; }
        public DiskController(disk_inventoryjcContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            List<Disk> disks = context.Disk.OrderBy(c => c.CdName).ThenBy(c => c.ReleaseDate).ToList();
            return View(disks);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.DiskTypes = context.DiskType.OrderBy(t => t.Description).ToList();
            ViewBag.Statuses = context.Status.OrderBy(s => s.Description).ToList();
            ViewBag.Genres = context.Genre.OrderBy(g => g.Description).ToList();
            var disk = context.Disk.Find(id);
            return View(disk);
        }
    }
}
