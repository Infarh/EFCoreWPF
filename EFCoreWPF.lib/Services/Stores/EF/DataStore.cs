using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreWPF.Data;
using EFCoreWPF.Entityes.Base.Interfaces;
using EFCoreWPF.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWPF.Services.Stores.EF
{
    abstract class DataStore<T> : IDataStore<T> where T : class, IEntity
    {
        protected readonly Database _db;
        protected readonly DbSet<T> _Items;

        public virtual IQueryable<T> Items => _Items.AsQueryable();

        protected DataStore(Database db)
        {
            _db = db;
            _Items = db.Set<T>();
        }

        public virtual void Add(T item) => _Items.Add(item);

        public virtual T Get(int id) => Items.FirstOrDefault(i => i.Id == id);

        public abstract void Update(int id, T item);

        public void Remove(T item) => _db.Entry(item).State = EntityState.Deleted;

        public void SaveChanges() => _db.SaveChanges();
    }
}
