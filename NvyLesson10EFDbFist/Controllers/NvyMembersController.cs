
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NvyLesson10EFDbFist.Model;

public class NvyMembersController : Controller
{
    private readonly NvyK24cntt2Lesson10EfdbContext _context;

    public NvyMembersController(NvyK24cntt2Lesson10EfdbContext context)
    {
        _context = context;
    }

    // GET: NVYMEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.NvyMembers.ToListAsync());
    }

    // GET: NVYMEMBERS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nvymember = await _context.NvyMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (nvymember == null)
        {
            return NotFound();
        }

        return View(nvymember);
    }

    // GET: NVYMEMBERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NVYMEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NvyUserName,NvyPassword,NvyFullName,NvyEmail,NvyPhone,NvyStatus")] NvyMember nvymember)
    {
        if (ModelState.IsValid)
        {
            _context.Add(nvymember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(nvymember);
    }

    // GET: NVYMEMBERS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nvymember = await _context.NvyMembers.FindAsync(id);
        if (nvymember == null)
        {
            return NotFound();
        }
        return View(nvymember);
    }

    // POST: NVYMEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,NvyUserName,NvyPassword,NvyFullName,NvyEmail,NvyPhone,NvyStatus")] NvyMember nvymember)
    {
        if (id != nvymember.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(nvymember);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NvyMemberExists(nvymember.Id))
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
        return View(nvymember);
    }

    // GET: NVYMEMBERS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var nvymember = await _context.NvyMembers
            .FirstOrDefaultAsync(m => m.Id == id);
        if (nvymember == null)
        {
            return NotFound();
        }

        return View(nvymember);
    }

    // POST: NVYMEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var nvymember = await _context.NvyMembers.FindAsync(id);
        if (nvymember != null)
        {
            _context.NvyMembers.Remove(nvymember);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool NvyMemberExists(long? id)
    {
        return _context.NvyMembers.Any(e => e.Id == id);
    }
}
