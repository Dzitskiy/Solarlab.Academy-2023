using AutoMapper;
using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Domain.Account;
using Board.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Board.Infrastucture.DataAccess.Contexts.Posts.Repository;

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
    public async Task<Guid> AddAsync(Account model, CancellationToken cancellation)
    {
        await _repository.AddAsync(model, cancellation);
        return model.Id;
    }

    /// <inheritdoc/>
    public Task<Account> FindById(Guid id, CancellationToken cancellation)
    {
        return _repository.GetByIdAsync(id, cancellation);  
    }

    /// <inheritdoc/>
    public async Task<Account> FindWhere(Expression<Func<Account, bool>> predicate, CancellationToken cancellation)
    {
        var data = _repository.GetAllFiltered(predicate);

        Account account = await data.Where(predicate).FirstOrDefaultAsync(cancellation);

        return account;
    }
}