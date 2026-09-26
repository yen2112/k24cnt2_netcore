
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenVanYen2410900091_exam.Models;
using NguyenVanYen2410900091_exam.Data;

public class NvyStudentsController : Controller
{
    private readonly NvyEmployeeDbContext _context;

    public NvyStudentsController(NvyEmployeeDbContext context)
    {
        _context = context;
    }

    // GET: HVTSTUDENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.HvtStudent.ToListAsync());
    }

    // GET: HVTSTUDENTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hvtstudent = await _context.HvtStudent
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hvtstudent == null)
        {
            return NotFound();
        }

        return View(hvtstudent);
    }

    // GET: HVTSTUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HVTSTUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,HvtName,HvtGender,HvtBirthDay,HvtEmail,HvtPhone,HvtActive")] nvyStudent hvtstudent)
    {
        if (ModelState.IsValid)
        {
            _context.Add(hvtstudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(hvtstudent);
    }

    // GET: HVTSTUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hvtstudent = await _context.HvtStudent.FindAsync(id);
        if (hvtstudent == null)
        {
            return NotFound();
        }
        return View(hvtstudent);
    }

    // POST: HVTSTUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,HvtName,HvtGender,HvtBirthDay,HvtEmail,HvtPhone,HvtActive")] nvyStudent hvtstudent)
    {
        if (id != hvtstudent.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(hvtstudent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HvtStudentExists(hvtstudent.Id))
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
        return View(hvtstudent);
    }

    // GET: HVTSTUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hvtstudent = await _context.HvtStudent
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hvtstudent == null)
        {
            return NotFound();
        }

        return View(hvtstudent);
    }

    // POST: HVTSTUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var hvtstudent = await _context.HvtStudent.FindAsync(id);
        if (hvtstudent != null)
        {
            _context.HvtStudent.Remove(hvtstudent);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HvtStudentExists(int? id)
    {
        return _context.HvtStudent.Any(e => e.Id == id);
    }
}
