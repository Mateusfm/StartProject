using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.Start.Entity.Entities
{
    public interface IEstado : IIdentityEntity
    {
        string Nome { get; set; }
        string Sigla { get; set; }
        int PaisId { get; set; }
        IPais Pais { get; set; }
    }
}
