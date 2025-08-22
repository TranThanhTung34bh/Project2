using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangBanhNgot.Models;

namespace CuaHangBanhNgot.Controllers
{
    public class ChiTietHoaDonsController : Controller
    {
        private readonly CuaHangBanhNgotContext _context;

        public ChiTietHoaDonsController(CuaHangBanhNgotContext context)
        {
            _context = context;
        }

        // GET: ChiTietHoaDons
        public async Task<IActionResult> Index()
        {
            var cuaHangBanhNgotContext = _context.ChiTietHoaDons.Include(c => c.MaHdNavigation).Include(c => c.MaSpNavigation);
            return View(await cuaHangBanhNgotContext.ToListAsync());
        }

        // GET: ChiTietHoaDons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons
                .Include(c => c.MaHdNavigation)
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd");
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp");
            return View();
        }

        // POST: ChiTietHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHd,MaSp,SoLuong,DonGia,ThanhTien")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd", chiTietHoaDon.MaHd);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietHoaDon.MaSp);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd", chiTietHoaDon.MaHd);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietHoaDon.MaSp);
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHd,MaSp,SoLuong,DonGia,ThanhTien")] ChiTietHoaDon chiTietHoaDon)
        {
            if (id != chiTietHoaDon.MaHd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonExists(chiTietHoaDon.MaHd))
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
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd", chiTietHoaDon.MaHd);
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietHoaDon.MaSp);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons
                .Include(c => c.MaHdNavigation)
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(id);
            if (chiTietHoaDon != null)
            {
                _context.ChiTietHoaDons.Remove(chiTietHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHoaDonExists(string id)
        {
            return _context.ChiTietHoaDons.Any(e => e.MaHd == id);
        }
    }
}
