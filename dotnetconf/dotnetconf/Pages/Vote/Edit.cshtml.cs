using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnetconf.Data;
using dotnetconf.Models;

namespace dotnetconf.Pages.Vote
{
    public class EditModel : PageModel
    {
        private readonly dotnetconf.Data.ApplicationDbContext _context;

        public EditModel(dotnetconf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Vote Vote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vote = await _context.Votes
                .Include(v => v.Session).FirstOrDefaultAsync(m => m.SessionId == id);

            if (Vote == null)
            {
                return NotFound();
            }
           ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Description");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(Vote.SessionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VoteExists(int id)
        {
            return _context.Votes.Any(e => e.SessionId == id);
        }
    }
}
