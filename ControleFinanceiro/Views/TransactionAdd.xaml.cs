using System.Text;
using CommunityToolkit.Mvvm.Messaging;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    private ITransactionRepository _repository;
    public TransactionAdd(
        ITransactionRepository repository
        )
    {
        InitializeComponent();
        _repository = repository;
    }

    void CloseAddTransaction(System.Object sender, System.EventArgs e)
    {

        Navigation.PopModalAsync();

    }

    void onButtonClickedSave(System.Object sender, System.EventArgs e)
    {

        if (isValidData() == false)
            return;
        saveTransactionOnDatabase();
        Navigation.PopModalAsync();
        WeakReferenceMessenger.Default.Send<string>(string.Empty);
        App.Current.MainPage.DisplayAlert("Mensagem!", $"Registro realizado com sucesso!", "Ok"); 

    }

    private void saveTransactionOnDatabase()
    {

        Transaction transaction = new Transaction()
        {
            TransactionType = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expenses,
            Name = EntryName.Text,
            Date = DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text)
        };


        _repository.AddTransaction(transaction);
    }

    private bool isValidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }
        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }
        double result;
        if (!string.IsNullOrEmpty(EntryValue.Text) && !double.TryParse(EntryValue.Text, out result))
        {
            sb.AppendLine("O campo 'Valor' é inválido!");
            valid = false;
        }

        if (valid == false)
        {
            LabelError.IsVisible = true;
            LabelError.Text = sb.ToString();
        }

        return valid;
    }

}
