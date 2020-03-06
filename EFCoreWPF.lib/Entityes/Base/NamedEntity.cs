using System.ComponentModel.DataAnnotations;

namespace EFCoreWPF.Entityes.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}