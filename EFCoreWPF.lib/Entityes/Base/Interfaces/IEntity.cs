using System.ComponentModel.DataAnnotations;

namespace EFCoreWPF.Entityes.Base.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    public interface INamedEntity : IEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
