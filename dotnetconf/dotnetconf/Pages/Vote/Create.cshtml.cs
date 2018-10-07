using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotnetconf.Data;
using dotnetconf.Models;

namespace dotnetconf.Pages.Vote
{
    public class CreateModel : PageModel
    {
        private readonly dotnetconf.Data.ApplicationDbContext _context;

        public CreateModel(dotnetconf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SessionId"] = new SelectList(_context.Sessions, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Models.Vote Vote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Votes.Add(Vote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}