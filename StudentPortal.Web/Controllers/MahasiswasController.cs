﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;

namespace StudentPortal.Web.Controllers
{
    public class MahasiswasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MahasiswasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mahasiswas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mahasiswas.ToListAsync());
        }

        // GET: Mahasiswas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            return View(mahasiswa);
        }

        // GET: Mahasiswas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mahasiswas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NIM,Nama,Jurusan,TanggalLahir")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mahasiswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswas.FindAsync(id);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return View(mahasiswa);
        }

        // POST: Mahasiswas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NIM,Nama,Jurusan,TanggalLahir")] Mahasiswa mahasiswa)
        {
            if (id != mahasiswa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mahasiswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MahasiswaExists(mahasiswa.Id))
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
            return View(mahasiswa);
        }

        // GET: Mahasiswas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mahasiswa = await _context.Mahasiswas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mahasiswa == null)
            {
                return NotFound();
            }

            return View(mahasiswa);
        }

        // POST: Mahasiswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mahasiswa = await _context.Mahasiswas.FindAsync(id);
            if (mahasiswa != null)
            {
                _context.Mahasiswas.Remove(mahasiswa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MahasiswaExists(int id)
        {
            return _context.Mahasiswas.Any(e => e.Id == id);
        }
    }
}
