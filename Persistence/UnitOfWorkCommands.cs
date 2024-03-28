using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Persistence.Entities;
using Shared.Kernal.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Persistence.Repositories.Interfaces;
using Persistence.Repositories;
using Domain.Entities;
using Persistence.Repositories.GreenHouseRepos;

namespace Persistence
{
    public interface IUnitOfWorkCommand
    {
        ICommandRepository<GreenHouse> GreenHouseCommandRepository { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
       
    }
    public class UnitOfWorkCommands : IUnitOfWorkCommand
    {
        private readonly ApplicationDbContext _dbcontext;

        public UnitOfWorkCommands(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            GreenHouseCommandRepository = new GreenHouseCommandRepository(_dbcontext);
        }

        public ICommandRepository<GreenHouse> GreenHouseCommandRepository { get; }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertEventsToOutboxMessages();
            //UpdateAuditableEntities();
            return _dbcontext.SaveChangesAsync(cancellationToken);
        }
        private void ConvertEventsToOutboxMessages()
        {
            var outboxMessages = _dbcontext.ChangeTracker
                .Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .SelectMany(aggregatorRoot =>
                {
                    var domainEvents = aggregatorRoot.GetDomainEvents();
                    aggregatorRoot.ClearDomainEvents();
                    return domainEvents;

                })
                .Select(domainEvent => new Outbox
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(domainEvent,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    })


                }).ToList();
            _dbcontext.Set<Outbox>().AddRange(outboxMessages);

        }

        //private void UpdateAuditableEntities()
        //{
        //    var entries = _dbcontext.ChangeTracker
        //    .Entries().Where(e => e.State == EntityState.Added || e.State ==EntityState.Modified);;

        //    foreach (var entry in entries)
        //    {
        //        entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;

        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
        //        }
        //    }

        //}

        //public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        //{
        //    return new Repository<TEntity>(_context);
        //}
    }
}
