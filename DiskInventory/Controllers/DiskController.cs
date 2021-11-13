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
    }
}
