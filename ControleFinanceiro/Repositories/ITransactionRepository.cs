using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories
{
    public interface ITransactionRepository
    {
        void AddTransaction(Transaction transaction);
        void DeleteTransaction(Transaction transaction);
        List<Transaction> GetAll();
        void UpdateTransaction(Transaction transaction);
    }
}