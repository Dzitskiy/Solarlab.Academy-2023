using System.Linq.Expressions;
using AutoMapper;
using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Account.Repository;

/// <inheritdoc cref="IAccountRepository"/>
public class AccountRepository : IAccountRepository
{
    private readonly IRepository<Domain.Account.Account> _repository;
    private readonly IMapper _mapper;

    public AccountRepository(IRepository<Domain.Account.Account> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<Guid> AddAsync(Domain.Account.Account model, CancellationToken cancellation)
    {
        await _repository.AddAsync(model, cancellation);
        return model.Id;
    }

    /// <inheritdoc/>
    public Task<Domain.Account.Account> FindById(Guid id, CancellationToken cancellation)
    {
        return _repository.GetByIdAsync(id, cancellation);  
    }

    /// <inheritdoc/>
    public async Task<Domain.Account.Account> FindWhere(Expression<Func<Domain.Account.Account, bool>> predicate, CancellationToken cancellation)
    {
        var data = _repository.GetAllFiltered(predicate);

        Domain.Account.Account account = await data.Where(predicate).FirstOrDefaultAsync(cancellation);

        return account;
    }
}