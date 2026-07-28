using System.Collections.Concurrent;
using Carrington.Blake.Models;

namespace Carrington.Blake.Services;

public class InMemoryAccountStore : IAccountStore
{
    private readonly ConcurrentDictionary<Guid, Account> _accounts = new();

    public InMemoryAccountStore()
    {
        Seed();
    }

    public IReadOnlyCollection<Account> GetAll() =>
        _accounts.Values.OrderBy(a => a.CreatedAt).ToList();

    public Account? GetById(Guid id) =>
        _accounts.GetValueOrDefault(id);

    public Account Create(CreateAccountRequest request)
    {
        var account = new Account
        {
            Id = Guid.NewGuid(),
            AccountNumber = request.AccountNumber,
            OwnerName = request.OwnerName,
            Type = request.Type,
            Balance = request.Balance,
            Currency = request.Currency,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };
        _accounts[account.Id] = account;
        return account;
    }

    public Account? Update(Guid id, UpdateAccountRequest request)
    {
        if (!_accounts.TryGetValue(id, out var account))
            return null;

        account.AccountNumber = request.AccountNumber;
        account.OwnerName = request.OwnerName;
        account.Type = request.Type;
        account.Balance = request.Balance;
        account.Currency = request.Currency;
        account.IsActive = request.IsActive;
        return account;
    }

    public bool Delete(Guid id) =>
        _accounts.TryRemove(id, out _);

    private void Seed()
    {
        var seedAccounts = new[]
        {
            new Account
            {
                Id = Guid.NewGuid(),
                AccountNumber = "CB-1000-0001",
                OwnerName = "Alice Johnson",
                Type = AccountType.Checking,
                Balance = 2450.75m,
                Currency = "USD",
                CreatedAt = DateTime.UtcNow.AddDays(-90)
            },
            new Account
            {
                Id = Guid.NewGuid(),
                AccountNumber = "CB-1000-0002",
                OwnerName = "Alice Johnson",
                Type = AccountType.Savings,
                Balance = 15000.00m,
                Currency = "USD",
                CreatedAt = DateTime.UtcNow.AddDays(-90)
            },
            new Account
            {
                Id = Guid.NewGuid(),
                AccountNumber = "CB-1000-0003",
                OwnerName = "Robert Miles",
                Type = AccountType.Checking,
                Balance = 310.20m,
                Currency = "EUR",
                CreatedAt = DateTime.UtcNow.AddDays(-30)
            },
            new Account
            {
                Id = Guid.NewGuid(),
                AccountNumber = "CB-1000-0004",
                OwnerName = "Eva Kowalska",
                Type = AccountType.Credit,
                Balance = -820.50m,
                Currency = "PLN",
                CreatedAt = DateTime.UtcNow.AddDays(-7),
                IsActive = false
            }
        };

        foreach (var account in seedAccounts)
            _accounts[account.Id] = account;
    }
}
