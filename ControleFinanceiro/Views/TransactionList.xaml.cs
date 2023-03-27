using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private ITransactionRepository _repository;

    public TransactionList(ITransactionRepository repository)
    {
        //Publisher - Subscribers
        /* 
        TransactionAdd -> Publisher > Cadastro.
        Subscribers -> TransacitonList (Cadastro).
         */
        this._repository = repository;
        InitializeComponent();
        RefreshData();

        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            RefreshData();
        });
    }



    private void RefreshData()
    {
        var items = _repository.GetAll();
        TransactionsCollectionView.ItemsSource = items;
        var totalIncome = items.Where(a => a.TransactionType == Models.TransactionType.Income).Sum(a => a.Value);
        var totalExpenses = items.Where(a => a.TransactionType == Models.TransactionType.Expenses).Sum(a => a.Value);
        var balance = totalIncome - totalExpenses;
        LabelIncome.Text = totalIncome.ToString("C");
        LabelExpenses.Text = totalExpenses.ToString("C");
        LabelBalance.Text = balance.ToString("C");
    }

    public void Transaction_Add(System.Object sender, System.EventArgs e)
    {
        var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(transactionAdd);
    }

    void Transaction_Edit(System.Object sender, System.EventArgs e)
    {
        var grid = (Grid)sender;
        var gesture = (TapGestureRecognizer)grid.GestureRecognizers[0];
        Transaction transaction = (Transaction)gesture.CommandParameter;
        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
        transactionEdit.SetTransactionToEdit(transaction);
        Navigation.PushModalAsync(transactionEdit);

    }

    private async void DeleteTransaction(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        bool result = await App.Current.MainPage.DisplayAlert("Excluir", "Tem certeza que deseja excluir?", "Sim", "Não");
        if (result)
        {
            Transaction transaction = (Transaction)e.Parameter;
            _repository.DeleteTransaction(transaction);
            RefreshData();
        }
    }
}
