using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.Start.Entity.Entities
{
    public interface IPais : IIdentityEntity
    {
        string Nome { get; set; }
    }
}
