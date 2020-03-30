
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;

namespace ViaticosWeb.Controllers
{
    public class ExpensesTypeController : Controller
    {
        private readonly DataContext _context;

        public ExpensesTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: ExpensesType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpensesType.ToListAsync());
        }

        // GET: ExpensesType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTypeEntity = await _context.ExpensesType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }

            return View(expenseTypeEntity);
        }

        // GET: ExpensesType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpensesType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeExpense")] ExpenseTypeEntity expenseTypeEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseTypeEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseTypeEntity);
        }

        // GET: ExpensesType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTypeEntity = await _context.ExpensesType.FindAsync(id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }
            return View(expenseTypeEntity);
        }

        // POST: ExpensesType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeExpense")] ExpenseTypeEntity expenseTypeEntity)
        {
            if (id != expenseTypeEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseTypeEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTypeEntityExists(expenseTypeEntity.Id))
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
            return View(expenseTypeEntity);
        }

        // GET: ExpensesType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTypeEntity = await _context.ExpensesType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTypeEntity == null)
            {
                return NotFound();
            }

            return View(expenseTypeEntity);
        }

        // POST: ExpensesType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseTypeEntity = await _context.ExpensesType.FindAsync(id);
            _context.ExpensesType.Remove(expenseTypeEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseTypeEntityExists(int id)
        {
            return _context.ExpensesType.Any(e => e.Id == id);
        }
    }
}
