using dotnetconf.Data;
using dotnetconf.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetconf.Pages
{
    public class VideoSessionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signinmanager;

        public VideoSessionModel(ApplicationDbContext context, SignInManager<IdentityUser> signinmanager)
        {
            _context = context;
            _signinmanager = signinmanager;
        }

        public IList<Session> Sessions { get; set; }
        public int UserVoteCount { get; set; }
        //public string Message { get; set; }
        public async Task OnGetAsync()
        {
            await LoadData(false);
        }

        public async Task OnPostVoteAsync(int id)
        {
            if (_signinmanager.IsSignedIn(User))
            {
                string userID = User?.Claims?.Where(c => c.Issuer == "LOCAL AUTHORITY")?.First().Value;

                int currentVoteCount = _context
                .Votes
                .Where(u => u.UserId == userID)
                .Count();

                if (currentVoteCount < 10)
                {
                    Models.Vote v = new Models.Vote
                    {
                        SessionId = id,
                        UserId = userID
                    };

                    _context.Votes.Add(v);
                    await _context.SaveChangesAsync();
                }

                await LoadData(userID);
            }
        }
        public async Task OnPostRemoveAsync(int id)
        {
            if (_signinmanager.IsSignedIn(User))
            {
                string userID = User?.Claims?.Where(c => c.Issuer == "LOCAL AUTHORITY")?.First()?.Value;

                Models.Vote v = await _context.Votes.FindAsync(id, userID);
                _context.Votes.Remove(v);
                await _context.SaveChangesAsync();

                await LoadData(userID);
            }
        }

        public async Task OnPostSortVoteAsync()
        {
            await LoadData(true);
        }

        private async Task LoadData(bool sort)
        {
            await LoadData(User?.Claims?.Where(c => c.Issuer == "LOCAL AUTHORITY")?.FirstOrDefault()?.Value, sort);
        }

        private async Task LoadData(string userID, bool sort = false)
        {
            Sessions = await _context
                .Sessions
                .Include(x => x.Votes)
                .ToListAsync();
            UserVoteCount = _context
                .Votes
                .Where(v => v.UserId == userID)
                .Count();
            if (sort)
            {
                Sessions = Sessions.OrderByDescending(x => x.Votes.Count).ToList();
            }
        }
    }
}
