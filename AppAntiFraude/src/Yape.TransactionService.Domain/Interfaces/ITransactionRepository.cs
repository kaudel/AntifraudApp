using System;
using System.Collections.Generic;
using System.Text;
using Yape.TransactionService.Domain.Entities;

namespace Yape.TransactionService.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task SaveAsync(Transaction transaction, CancellationToken cancellationToken = default);
        Task<Transaction?> GetByExternalIdAsync(Guid transactionExternalId, CancellationToken cancellationToken = default);
        Task UpdateAsync(CancellationToken cancellationToken = default);
    }
}
