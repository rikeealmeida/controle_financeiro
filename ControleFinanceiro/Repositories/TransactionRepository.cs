using System;
using ControleFinanceiro.Models;
using LiteDB;

namespace ControleFinanceiro.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;
        private readonly string collectionName = "transaction";
        public TransactionRepository(LiteDatabase database)
        {
            _database = database;

        }

        public List<Transaction> GetAll()
        {
            return _database
                 .GetCollection<Transaction>(collectionName)
                 .Query()
                 .OrderByDescending(a => a.Date)
                 .ToList();

        }
        public void AddTransaction(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Insert(transaction);
            col.EnsureIndex(a => a.Date);

        }
        public void UpdateTransaction(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Update(transaction);

        }

        public void DeleteTransaction(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Delete(transaction.Id);
        }
    }
}

