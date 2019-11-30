using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCourse1920_Nhom46.Models;

namespace NETCourse1920_Nhom46.Controllers
{
    public class LopHocPhansController : Controller
    {
        private readonly QuanLyDbContext _context;

        public LopHocPhansController(QuanLyDbContext context)
        {
            _context = context;
        }

        // GET: LopHocPhans
        public async Task<IActionResult> Index()
        {
            var quanLyDbContext = _context.LopHocPhans.Include(l => l.MonHoc);
            return View(await quanLyDbContext.ToListAsync());
        }

        // GET: LopHocPhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.MonHoc)
                .FirstOrDefaultAsync(m => m.MaLHP == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Create
        public IActionResult Create()
        {
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "MaMon");
            return View();
        }

        // POST: LopHocPhans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLHP,NamHoc,HocKy,MaMon,DiemGK,DiemCuoiKy")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "MaMon", lopHocPhan.MaMon);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "MaMon", lopHocPhan.MaMon);
            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLHP,NamHoc,HocKy,MaMon,DiemGK,DiemCuoiKy")] LopHocPhan lopHocPhan)
        {
            if (id != lopHocPhan.MaLHP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocPhanExists(lopHocPhan.MaLHP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMon"] = new SelectList(_context.MonHocs, "MaMon", "MaMon", lopHocPhan.MaMon);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.MonHoc)
                .FirstOrDefaultAsync(m => m.MaLHP == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            _context.LopHocPhans.Remove(lopHocPhan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocPhanExists(int id)
        {
            return _context.LopHocPhans.Any(e => e.MaLHP == id);
        }
    }
}
