namespace ControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
		InitializeComponent();
	}


    void CloseEditTransaction(System.Object sender, System.EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}
