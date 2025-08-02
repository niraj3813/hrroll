using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRRoll.Data;

namespace HRRoll.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly HRRoll.Data.AppDbContext _context;

        public IndexModel(HRRoll.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<ClientMaster> ClientMaster { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ClientMaster = await _context.ClientMasters.ToListAsync();
        }
    }
}
