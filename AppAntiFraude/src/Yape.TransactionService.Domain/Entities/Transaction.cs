using System;
using System.Collections.Generic;
using System.Text;

namespace Yape.TransactionService.Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionExternalId { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid TargetAccountId { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
