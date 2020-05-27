using Martins.Infrastructure.Interfaces.Repositories.Standard;
using Martins.Start.Entity.Entities;

namespace Martins.Infrastructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
