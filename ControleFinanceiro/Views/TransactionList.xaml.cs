using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private TransactionAdd _transactionAdd;
    private TransactionEdit _transactionEdit;
    private ITransactionRepository _repository;

    public TransactionList(
        TransactionAdd transactionAdd, TransactionEdit transactionEdit, ITransactionRepository repository
        )
    {
        this._transactionAdd = transactionAdd;
        this._transactionEdit = transactionEdit;
        this._repository = repository;
        InitializeComponent();
        TransactionsCollectionView.ItemsSource = _repository.GetAll();
    }

    public void Transaction_Add(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(_transactionAdd);
    }

    void Transaction_Edit(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(_transactionEdit);

    }
}
