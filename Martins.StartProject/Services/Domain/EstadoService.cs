using Martins.Infrastructure.Interfaces.Repositories.Domain;
using Martins.Start.Entity.Entities;
using Martins.StartProject.Interfaces.Services.Domain;
using Martins.StartProject.Services.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.StartProject.Services.Domain
{
    public class EstadoService : ServiceBase<IEstado>, IEstadoService
    {
        private readonly IEstadoRepository _repository;

        public EstadoService(IEstadoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
