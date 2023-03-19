using System;
using LiteDB;

namespace ControleFinanceiro.Models
{
    public class Transaction
    {
        [BsonId]
        public int Id { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Value { get; set; }
    }

    public enum TransactionType { Income, Expenses }
}

