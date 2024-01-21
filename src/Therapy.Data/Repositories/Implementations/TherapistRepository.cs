using Therapy.Core.Models;
using Therapy.Core.Repositories.Interfaces;
using Therapy.Data.DAL;

namespace Therapy.Data.Repositories.Implementations;

public class TherapistRepository : GenericRepository<Therapist>, ITherapistRepository
{
    public TherapistRepository(AppDbContext context) : base(context)
    {
    }
}
