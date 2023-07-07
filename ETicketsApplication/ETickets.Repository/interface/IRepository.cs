
using System;
using System.Collections.Generic;
using System.Text;

using ETickets.Domain;
using ETickets.Domain.DomainModels;

namespace ETickets.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid? id);
        void Remove(T entity);
        void SaveChnges();
        void Delete(Ticket ticket);
    }
}
