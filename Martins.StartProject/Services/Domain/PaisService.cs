using Martins.Infrastructure.Interfaces.Repositories.Domain;
using Martins.Infrastructure.Interfaces.Repositories.Standard;
using Martins.Start.Entity.Entities;
using Martins.StartProject.Interfaces.Services.Domain;
using Martins.StartProject.Services.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.StartProject.Services.Domain
{
    public class PaisService : ServiceBase<IPais>, IPaisService
    {
        private IPaisRepository _repository;
        public PaisService(IPaisRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
