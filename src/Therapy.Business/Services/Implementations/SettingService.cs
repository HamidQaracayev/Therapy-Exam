using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Therapy.Business.CustomExceptions;
using Therapy.Business.Services.Interfaces;
using Therapy.Core.Models;
using Therapy.Core.Repositories.Interfaces;

namespace Therapy.Business.Services.Implementations
{

    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<List<Settings>> GetAll()
        {
            return await _settingRepository.GetAllAsync();
        }

        public async Task<Settings> GetById(int id)
        {
            return await _settingRepository.GetAsync(x=> x.Id == id);  
        }

        public async Task Update(Settings settings)
        {
            if (settings == null) throw new EntityIsNullException("Setting", "Setting not found");
            var existSetting = await _settingRepository.GetAsync(x=>x.Id == settings.Id && x.IsDeleted==false);
            if (existSetting == null) throw new EntityIsNullException("Setting", "Setting not found");
            existSetting.Value = settings.Value;
            existSetting.UpdateDate = DateTime.Now;
            await _settingRepository.CommitAsync();
        }
    }
}
