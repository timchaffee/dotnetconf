using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dotnetconf.Data;
using dotnetconf.Models;

namespace dotnetconf.Pages.Vote
{
    public class IndexModel : PageModel
    {
        private readonly dotnetconf.Data.ApplicationDbContext _context;

        public IndexModel(dotnetconf.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Vote> Vote { get;set; }

        public async Task OnGetAsync()
        {
            Vote = await _context.Votes
                .Include(v => v.Session).ToListAsync();
        }
    }
}
