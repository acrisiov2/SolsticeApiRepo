using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllContacts();
        TEntity GetContactById(long id);
        List<TEntity> GetAllContactsByStateOrAdress(string id);
        TEntity GetContactByEmailOrPhone(string id);
        TEntity PostNewContact(TEntity entity);
        TEntity Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}