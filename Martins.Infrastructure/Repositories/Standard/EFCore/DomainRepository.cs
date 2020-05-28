using Martins.Infrastructure.Interfaces.Repositories.Domain.Standard;
using Martins.Start.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Martins.Infrastructure.Repositories.Standard.EFCore
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                         IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
