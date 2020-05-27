using Martins.Infrastructure.Interfaces.Repositories.Domain;
using Martins.Start.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Martins.Infrastructure.Repositories.Domain.EFCore
{
    public class PaisRepository : IPaisRepository
    {
        public Task<IPais> AddAsync(IPais obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IEnumerable<IPais> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPais>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IPais> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(IPais obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveRangeAsync(IEnumerable<IPais> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(IPais obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRangeAsync(IEnumerable<IPais> entities)
        {
            throw new NotImplementedException();
        }
    }
}
