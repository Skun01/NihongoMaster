using System;
using System.Collections;
using NihongoMaster.Application.Interfaces;
using NihongoMaster.Infrastructure.Data;

namespace NihongoMaster.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;
    private Dictionary<string, object> _repositories;
    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<T> Repository<T>() where T : class
    {
        _repositories ??= [];

        var type = typeof(T).Name;

        // check key
        if (!_repositories.ContainsKey(type))
        {

            // create instance
            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(T)),
                _context
            );
            
            // save to dictionary
            if(repositoryInstance is not null)
                _repositories.Add(type, repositoryInstance);
        }
        
        return (IRepository<T>)_repositories[type];
    }
}
