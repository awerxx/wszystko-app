namespace Carrington.Blake.Models;

public record CreateAccountRequest(
    string AccountNumber,
    string OwnerName,
    AccountType Type,
    decimal Balance,
    string Currency = "USD");

public record UpdateAccountRequest(
    string AccountNumber,
    string OwnerName,
    AccountType Type,
    decimal Balance,
    string Currency,
    bool IsActive);
