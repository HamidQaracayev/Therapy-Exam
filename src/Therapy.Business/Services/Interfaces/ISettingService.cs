using Therapy.Core.Models;

namespace Therapy.Business.Services.Interfaces;

public interface ISettingService
{
    Task Update(Settings settings);
    Task<List<Settings>> GetAll();
    Task<Settings> GetById(int id);
}
