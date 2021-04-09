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
        IRepository<SIG> sIGRepository;
        public SIGBusiness()
        {
            this.sIGRepository = new SIGRepository();
        }

        public async Task<SIG> AddSIG(SIG entity)
        {
            return await this.sIGRepository.Add(entity);
        }

        public async Task<List<SIG>> GetAllSIG()
        {
            return await this.sIGRepository.GetAll();
        }

        public async Task<SIG> GetSIGById(int id)
        {
            return await this.sIGRepository.GetById(id);
        }

        public async Task<SIG> RemoveSIG(SIG entity)
        {
            return await this.sIGRepository.Remove(entity);
        }

        public async Task<SIG> UpdateSIG(SIG entity)
        {
            return await this.sIGRepository.Update(entity);
        }
    }
}
