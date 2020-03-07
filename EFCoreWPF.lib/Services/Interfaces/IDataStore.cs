using System.Linq;

namespace EFCoreWPF.Services.Interfaces
{
    public interface IDataStore<T>
    {
        IQueryable<T> Items { get; }

        void Add(T item);

        T Get(int id);

        void Update(int id, T item);

        void Remove(T item);

        public void SaveChanges();
    }
}
