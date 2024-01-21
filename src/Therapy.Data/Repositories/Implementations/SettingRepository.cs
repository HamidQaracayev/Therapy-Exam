using Therapy.Core.Models;
using Therapy.Core.Repositories.Interfaces;
using Therapy.Data.DAL;

namespace Therapy.Data.Repositories.Implementations;

public class SettingRepository : GenericRepository<Settings>, ISettingRepository
{
    public SettingRepository(AppDbContext context) : base(context)
    {
    }
}
