using Carrington.Blake.Models;

namespace Carrington.Blake.Services;

public interface IAccountStore
{
    IReadOnlyCollection<Account> GetAll();
    Account? GetById(Guid id);
    Account Create(CreateAccountRequest request);
    Account? Update(Guid id, UpdateAccountRequest request);
    bool Delete(Guid id);
}
