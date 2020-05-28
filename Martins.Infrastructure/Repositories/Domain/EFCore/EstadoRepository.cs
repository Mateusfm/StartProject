using Martins.Infrastructure.Interfaces.Repositories.Domain;
using Martins.Start.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Martins.Infrastructure.Repositories.Domain.EFCore
{
    public class EstadoRepository : IEstadoRepository
    {
        public Task<IEstado> AddAsync(IEstado obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IEnumerable<IEstado> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IEstado>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEstado> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(IEstado obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveRangeAsync(IEnumerable<IEstado> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(IEstado obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRangeAsync(IEnumerable<IEstado> entities)
        {
            throw new NotImplementedException();
        }
    }
}
