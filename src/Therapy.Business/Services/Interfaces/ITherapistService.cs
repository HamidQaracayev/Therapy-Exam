using Therapy.Core.Models;

namespace Therapy.Business.Services.Interfaces;

public interface ITherapistService
{
    Task CreateAsync(Therapist therapist);
    Task UpdateAsync(Therapist therapist);
    Task Delete(int id);

   Task<List<Therapist>> GetAll();
    Task<Therapist> GetById(int id);
}
