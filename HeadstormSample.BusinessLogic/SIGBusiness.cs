using HeadstormSample.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.DataAccess;

namespace HeadstormSample.BusinessLogic
{
    public class SIGBusiness : ISIGBusiness
    {
        private IRepository<SIG> _sIGRepository;
        public SIGBusiness(IRepository<SIG> sIGRepository)
        {
            this._sIGRepository = sIGRepository;
        }

        public async Task<SIG> AddSIG(SIG entity)
        {
            return await this._sIGRepository.Add(entity);
        }

        public async Task<ICollection<SIG>> GetAllSIG()
        {
            return await this._sIGRepository.GetAll();
        }

        public async Task<SIG> GetSIGById(int id)
        {
            return await this._sIGRepository.GetById(id);
        }

        public async Task<SIG> RemoveSIG(SIG entity)
        {
            return await this._sIGRepository.Remove(entity);
        }

        public async Task<SIG> UpdateSIG(SIG entity)
        {
            return await this._sIGRepository.Update(entity);
        }
    }
}
