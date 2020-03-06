using System.ComponentModel.DataAnnotations;
using EFCoreWPF.Entityes.Base.Interfaces;

namespace EFCoreWPF.Entityes.Base
{
    public abstract class NamedEntity : BaseEntity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}