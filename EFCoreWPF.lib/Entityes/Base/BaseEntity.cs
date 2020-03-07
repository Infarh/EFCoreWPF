using EFCoreWPF.Entityes.Base.Interfaces;

namespace EFCoreWPF.Entityes.Base
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
