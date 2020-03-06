using System;
using System.Collections.Generic;
using System.Text;
using EFCoreWPF.Entityes.Base.Interfaces;

namespace EFCoreWPF.Entityes.Base
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
