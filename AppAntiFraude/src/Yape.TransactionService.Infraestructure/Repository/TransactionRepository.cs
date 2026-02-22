using Microsoft.EntityFrameworkCore;
using Yape.TransactionService.Domain.Entities;
using Yape.TransactionService.Domain.Interfaces;
using Yape.TransactionService.Infraestructure.Persistance;

namespace Yape.TransactionService.Infraestructure.Repository
{
    public class TransactionRepository(TransactionDbContext context) : ITransactionRepository
    {
        public async Task<Transaction?> GetByExternalIdAsync(Guid transactionExternalId, CancellationToken cancellationToken)
        {
            return await context.Set<Transaction>()
                .FirstOrDefaultAsync(t => t.TransactionExternalId == transactionExternalId, cancellationToken);
        }

        public async Task SaveAsync(Transaction transaction, CancellationToken cancellationToken)
        {
            await context.Set<Transaction>().AddAsync(transaction, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        async Task ITransactionRepository.UpdateAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
