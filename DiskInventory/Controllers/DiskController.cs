using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.DiskTypes = context.DiskType.OrderBy(t => t.Description).ToList();
            ViewBag.Statuses = context.Status.OrderBy(s => s.Description).ToList();
            ViewBag.Genres = context.Genre.OrderBy(g => g.Description).ToList();
            return View("Edit", new Disk());
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

        [HttpPost]
        public IActionResult Edit(Disk disk)
        {
            if (ModelState.IsValid)
            {
                if (disk.DiskId == 0)
                {
                    //@disk_type_id, @disk_status_id, @genre_id, @release_date, @cd_name
                    context.Database.ExecuteSqlRaw("execute sp_ins_disk @p0, @p1, @p2, @p3, @p4",
                         parameters: new[] { disk.DiskTypeId.ToString(),disk.DiskStatusId.ToString(), disk.GenreId.ToString(), disk.ReleaseDate.ToString(), disk.CdName});
                }
                else
                {
                    context.Disk.Update(disk);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Disk");
            }
            else
            {
                ViewBag.Action = (disk.DiskId == 0) ? "Add" : "Edit";
                ViewBag.DiskTypes = context.DiskType.OrderBy(t => t.Description).ToList();
                ViewBag.Statuses = context.Status.OrderBy(s => s.Description).ToList();
                ViewBag.Genres = context.Genre.OrderBy(g => g.Description).ToList();
                return View(disk);
            }
        }
    }
}
