using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula04.RazorPages.Data;
using Aula04.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aula04.RazorPages.Pages.Events.Players
{
    public class Register : PageModel
    {
        private readonly AppDbContext _context;
public List<EventModel>? EventList { get; set; }
    public List<PlayerModel>? PlayerList { get; set; }

        public Register(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
    {
        EventList = await _context.Events!.ToListAsync();
        PlayerList = await _context.Players!.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int evento, int jogador)
    {
        var selectedEvent = await _context.Events!.Include(e => e.Players).FirstOrDefaultAsync(e => e.EventID ==evento);
        var selectedPlayer = await _context.Players!.FindAsync(jogador);

        if (selectedEvent == null || selectedPlayer == null)
        {
            return NotFound();
        }

        selectedEvent.Players!.Add(selectedPlayer);
        await _context.SaveChangesAsync();

        return RedirectToPage();
    }
    }
}