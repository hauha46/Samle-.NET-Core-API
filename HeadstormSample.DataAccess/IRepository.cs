using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HeadstormSample.Model;

namespace HeadstormSample.DataAccess
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get the entity by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Get all available entities type T
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAll();
        /// <summary>
        /// Add a new entity into the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Add(T entity);
        /// <summary>
        /// Update information of an entity with matching Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Update(T entity);
        /// <summary>
        /// Remove an entity from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Remove(T entity); 
    }
}
