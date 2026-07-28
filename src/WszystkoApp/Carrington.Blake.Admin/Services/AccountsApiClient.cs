using Carrington.Blake.Admin.Models;

namespace Carrington.Blake.Admin.Services;

public class AccountsApiClient(HttpClient httpClient)
{
    public async Task<List<AccountDto>> GetAccountsAsync(CancellationToken cancellationToken = default) =>
        await httpClient.GetFromJsonAsync<List<AccountDto>>("api/accounts", cancellationToken) ?? [];
}
