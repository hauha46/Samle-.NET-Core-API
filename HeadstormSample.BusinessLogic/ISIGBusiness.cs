using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;

namespace HeadstormSample.BusinessLogic
{
    public interface ISIGBusiness
    {
        /// <summary>
        /// Get a SIG by the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the found SIG</returns>
        Task<SIG> GetSIGById(int id);
        /// <summary>
        /// Get all available SIG in the database
        /// </summary>
        /// <returns>Returns a list of SIG</returns>
        Task<ICollection<SIG>> GetAllSIG();
        /// <summary>
        /// Add a new SIG into the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the added SIG</returns>
        Task<SIG> AddSIG(SIG entity);
        /// <summary>
        /// Update a SIG with matching Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Rerturns the updated SIG</returns>
        Task<SIG> UpdateSIG(SIG entity);
        /// <summary>
        /// Remove a SIG from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the removed SIG</returns>
        Task<SIG> RemoveSIG(SIG entity);
    }
}
