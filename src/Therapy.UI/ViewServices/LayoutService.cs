using Microsoft.EntityFrameworkCore;
using Therapy.Core.Models;
using Therapy.Data.DAL;

namespace Therapy.UI.ViewServices;

public class LayoutService
{
    private readonly AppDbContext _context;

    public LayoutService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Settings>> GetSettings()
    {
        return await _context.Settings.ToListAsync();

    }
}
